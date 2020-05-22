using System;
using Microsoft.EntityFrameworkCore;


namespace aspnet_api_heroku.Models
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(DbContextOptions<ArticleContext> options)
            : base(options)
        {
        }

        public DbSet<ArticleItem> ArticleItems { get; set; }
    }
}
