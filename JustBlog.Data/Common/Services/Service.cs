using JustBlog.Core.Common.Repositories;
using JustBlog.Core.Common.UnitOfWork;
using JustBlog.Service.Common;
using System;
using System.Collections.Generic;

namespace JustBlog.Data.Common.Services
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        IUnitOfWork _unitOfWork;
        IRepository<TEntity> _repository;

        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Add(entity);
            _unitOfWork.Complete();
        }

        public TEntity FindById(int id)
        {
            return _repository.FindById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Remove(entity);
            _unitOfWork.Complete();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Update(entity);
            _unitOfWork.Complete();
        }
    }
}
