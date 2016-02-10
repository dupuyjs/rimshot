using Newtonsoft.Json;
using Songkick.Helper;
using Songkick.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace Songkick
{
    public class SimpleServiceClient : IDisposable
    {
        private HttpBaseProtocolFilter filter;
        private HttpClient httpClient;
        CancellationTokenSource cts;

        public SimpleServiceClient()
        {
            filter = new HttpBaseProtocolFilter();
            httpClient = new HttpClient(filter);
            cts = new CancellationTokenSource();
        }

        public void Cancel()
        {
            cts.Cancel();
            cts.Dispose();

            // Re-create the CancellationTokenSource.
            cts = new CancellationTokenSource();
        }

        public async Task<ContentResponse> GetWithRetryAsync(Uri baseUri, UriTemplate template, Dictionary<string, string> parameters)
        {
            Uri uri = template.BindByName(baseUri, parameters);
            string jsonContent = string.Empty;
            ContentResponse content = default(ContentResponse);

            var response = await InvokeWebOperationWithRetry<HttpResponseMessage>(async () =>
            {
                var httpResponse = await httpClient.GetAsync(uri).AsTask(cts.Token);
                httpResponse.EnsureSuccessStatusCode();
                return httpResponse;
            }
            );

            jsonContent = await response.Content.ReadAsStringAsync();

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;

            try
            {
                content = JsonConvert.DeserializeObject<ContentResponse>(jsonContent, settings);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return content;
        }

        private async static Task<T> InvokeWebOperationWithRetry<T>(Func<Task<T>> retriableOperation)
        {
            int baselineDelay = 1000;
            const int maxAttempts = 4;

            Random random = new Random();

            int attempt = 0;

            while (++attempt <= maxAttempts)
            {
                try
                {
                    return await retriableOperation();
                }
                catch (Exception ex)
                {
                    if (attempt == maxAttempts || !IsTransientException(ex))
                    {
                        throw;
                    }

                    int delay = baselineDelay + random.Next((int)(baselineDelay * 0.5), baselineDelay);

                    await Task.Delay(delay);

                    // Increment base-delay time
                    baselineDelay *= 2;
                }
            }

            // The logic above assures that this exception will never be thrown.
            throw new InvalidOperationException("This exception statement should never be thrown.");
        }

        private static bool IsTransientException(Exception ex)
        {
            return true;
            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (filter != null)
            {
                filter.Dispose();
                filter = null;
            }

            if (httpClient != null)
            {
                httpClient.Dispose();
                httpClient = null;
            }

            if (cts != null)
            {
                cts.Dispose();
                cts = null;
            }
        }
    }
}
