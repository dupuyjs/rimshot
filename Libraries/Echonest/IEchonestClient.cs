using Echonest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Echonest
{
    public interface IEchonestClient
    {
        Task<ContentResponse> GetProfile(string artistId);

        Task<ContentResponse> GetBiographies(string artistId);
    }
}
