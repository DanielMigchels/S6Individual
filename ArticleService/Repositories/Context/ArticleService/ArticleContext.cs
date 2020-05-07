using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleService.Repositories.Context.ArticleService
{
    public class ArticleContext : IArticleContext
    {
        public void Delete(int id)
        {
            Article article = ArticleServiceContext.current.Article.Single(p => p.Id == id);
            ArticleServiceContext.current.Article.Remove(article);
            ArticleServiceContext.current.SaveChanges();
        }

        public IEnumerable<Article> Get()
        {
            return ArticleServiceContext.current.Article;
        }
        public Article Get(string url)
        {
            return ArticleServiceContext.current.Article.Single(p => p.URI == url);
        }

        public Article Get(int id)
        {
            return ArticleServiceContext.current.Article.Single(p => p.Id == id);
        }

        public IEnumerable<Article> GetSite(int siteId)
        {
            return ArticleServiceContext.current.Article.Where(p => p.SiteId == siteId);
        }

        public IEnumerable<Article> GetSite(int siteId, int page, int pageSize)
        {
            return ArticleServiceContext.current.Article.Where(p => p.SiteId == siteId).Skip(page * pageSize).Take(pageSize);
        }

        public void Post(Article value)
        {
            ArticleServiceContext.current.Article.Add(value);
            ArticleServiceContext.current.SaveChanges();
        }

        public void Put(int id, Article value)
        {
            Article article = ArticleServiceContext.current.Article.Single(p => p.Id == id);
            article.Id = id;
            ArticleServiceContext.current.SaveChanges();
        }
    }
}
