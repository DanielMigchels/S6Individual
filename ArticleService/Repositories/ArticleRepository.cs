using Models;
using ArticleService.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleService.Repositories
{
    public class ArticleRepository
    {
        IArticleContext context = new Context.ArticleService.ArticleContext();

        public IEnumerable<Article> Get() => context.Get();
        public Article Get(int id) => context.Get(id);
        public void Post(Article value) => context.Post(value);
        public void Put(int id, Article value) => context.Put(id, value);
        public void Delete(int id) => context.Delete(id);
    }
}
