using JustBlog.Core.Repositories;
using JustBlog.Data.Common.Repositories;
using JustBlog.Model;

namespace JustBlog.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(JustBlogDbContext context) : base(context)
        {

        }
        public JustBlogDbContext JustBlogDbContext
        {
            get { return Context as JustBlogDbContext; }
        }
    }
}
