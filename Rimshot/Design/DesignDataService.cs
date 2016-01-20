using Rimshot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rimshot.Design
{
    public class DesignDataService : IDataService
    {
        public Task<string> GetData()
        {
            return Task.FromResult("design");
        }
    }
}
