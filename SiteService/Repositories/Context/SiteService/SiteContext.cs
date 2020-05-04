using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteService.Repositories.Context.SiteService
{
    public class SiteContext : ISiteContext
    {
        public void Delete(int id)
        {
            Site site = SiteServiceContext.current.Site.Single(p => p.Id == id);
            SiteServiceContext.current.Site.Remove(site);
            SiteServiceContext.current.SaveChanges();
        }

        public IEnumerable<Site> Get()
        {
            return SiteServiceContext.current.Site;
        }

        public Site Get(int id)
        {
            return SiteServiceContext.current.Site.Single(p => p.Id == id);
        }

        public void Post(Site value)
        {
            SiteServiceContext.current.Site.Add(value);
            SiteServiceContext.current.SaveChanges();
        }

        public void Put(int id, Site value)
        {
            Site site = SiteServiceContext.current.Site.Single(p => p.Id == id);
            site.Id = id;
            SiteServiceContext.current.SaveChanges();
        }
    }
}
