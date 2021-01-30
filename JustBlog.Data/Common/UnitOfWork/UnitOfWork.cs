using JustBlog.Core.Common.UnitOfWork;
using JustBlog.Core.Repositories;
using JustBlog.Data.Repositories;

namespace JustBlog.Data.Common.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private JustBlogDbContext _context;
        public UnitOfWork(JustBlogDbContext context)
        {
            _context = context;
            pageRepository = new PageRepository(_context);
            postRepository = new PostRepository(_context);
            categoryRepository = new CategoryRepository(_context);
           
        }

        public IPageRepository pageRepository { get; private set; }
        public IPostRepository postRepository { get; private set; }
        public ICategoryRepository categoryRepository { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
