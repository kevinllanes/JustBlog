using JustBlog.Core.Repositories;
using JustBlog.Data.Common.Repositories;
using JustBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Data.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(JustBlogDbContext context) : base(context)
        {

        }
        public JustBlogDbContext JustBlogDbContext
        {
            get { return Context as JustBlogDbContext; }
        }
    }
}
