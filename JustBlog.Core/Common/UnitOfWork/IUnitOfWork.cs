using JustBlog.Core.Repositories;
using System;

namespace JustBlog.Core.Common.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IPageRepository pageRepository { get; }
        IPostRepository postRepository { get; }
        ICategoryRepository categoryRepository { get; }
        int Complete();
    }
}
