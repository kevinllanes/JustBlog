using JustBlog.Core.Repositories;
using JustBlog.Data.Common.Repositories;
using JustBlog.Model;

namespace JustBlog.Data.Repositories
{
    public class PageRepository:Repository<Page>,IPageRepository
    {
        public PageRepository(JustBlogDbContext context) : base(context)
        {

        }
        public JustBlogDbContext JustBlogDbContext
            {
            get { return Context as JustBlogDbContext; }
        }
    }
}
