using ArticleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleService.Repositories.Context
{
    public interface IArticleContext
    {
        public IEnumerable<Article> Get();
        public Article Get(int id);
        public void Post(Article value);
        public void Put(int id, Article value);
        public void Delete(int id);
    }
}
