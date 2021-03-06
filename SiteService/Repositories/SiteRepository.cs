﻿using Models;
using SiteService.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteService.Repositories
{
    public class SiteRepository
    {
        ISiteContext context = new Context.SiteService.SiteContext();

        public IEnumerable<Site> Get() => context.Get();
        public IEnumerable<Site> Get(int Page, int PageSize) => context.Get(Page, PageSize);
        public Site Get(int id) => context.Get(id);
        public Site Get(string domainName) => context.Get(domainName);
        public void Post(Site value) => context.Post(value);
        public void Put(int id, Site value) => context.Put(id, value);
        public void Delete(int id) => context.Delete(id);
    }
}
