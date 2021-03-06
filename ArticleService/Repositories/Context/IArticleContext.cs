﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleService.Repositories.Context
{
    public interface IArticleContext
    {
        public IEnumerable<Article> Get();
        public Article Get(string url);
        public IEnumerable<Article> GetSite(int siteId);
        public IEnumerable<Article> GetSite(int siteId, int page, int pageSize);
        public Article Get(int id);
        public void Post(Article value);
        public void Put(int id, Article value);
        public void Delete(int id);
    }
}
