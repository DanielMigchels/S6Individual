using SiteService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteService.Repositories.Context
{
    interface ISiteContext
    {
        public IEnumerable<Site> Get();
        public Site Get(int id);
        public void Post(Site value);
        public void Put(int id, Site value);
        public void Delete(int id);
    }
}
