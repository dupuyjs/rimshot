using Songkick.Models;
using System.Threading.Tasks;

namespace Rimshot.Models
{
    public interface IDataService
    {
        Task<ContentResponse> GetEvents();
    }
}
