using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rimshot.Model
{
    class DataService : IDataService
    {
        public Task<string> GetData()
        {
            return Task.FromResult("item");
        }
    }
}
