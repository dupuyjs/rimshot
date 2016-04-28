﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Echonest;
using Echonest.Models;
using Microsoft.Rest;

namespace Echonest
{
    public static partial class ArtistItemsExtensions
    {
        /// <param name='operations'>
        /// Reference to the Echonest.IArtistItems.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        public static ArtistItem GetArtistItemById(this IArtistItems operations, string id)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IArtistItems)s).GetArtistItemByIdAsync(id);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the Echonest.IArtistItems.
        /// </param>
        /// <param name='id'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<ArtistItem> GetArtistItemByIdAsync(this IArtistItems operations, string id, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<Echonest.Models.ArtistItem> result = await operations.GetArtistItemByIdWithOperationResponseAsync(id, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        
        /// <param name='operations'>
        /// Reference to the Echonest.IArtistItems.
        /// </param>
        public static IList<ArtistItem> GetArtistItems(this IArtistItems operations)
        {
            return Task.Factory.StartNew((object s) => 
            {
                return ((IArtistItems)s).GetArtistItemsAsync();
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        
        /// <param name='operations'>
        /// Reference to the Echonest.IArtistItems.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<IList<ArtistItem>> GetArtistItemsAsync(this IArtistItems operations, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Microsoft.Rest.HttpOperationResponse<System.Collections.Generic.IList<Echonest.Models.ArtistItem>> result = await operations.GetArtistItemsWithOperationResponseAsync(cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }
}