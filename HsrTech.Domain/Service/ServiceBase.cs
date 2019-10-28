using HsrTech.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HsrTech.Domain.Interface.Service
{
    public class ServiceBase<T> : IDisposable, IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public void Add(params T[] items)
        {
            _repository.Add(items);
        }

        public void AddNoValidate(params T[] items)
        {
            _repository.AddNoValidate(items);
        }

        public void Delete(params T[] items)
        {
            _repository.Delete(items);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IList<T> GetAll()
        {
            return _repository.GetAll();
        }

        public IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navProperties)
        {
            return _repository.GetList(where, navProperties);
        }       

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navProperties)
        {
            return _repository.GetSingle(where, navProperties);
        }

        public void update(params T[] items)
        {
            _repository.Update(items);
        }

        public void UpdateNoValidate(params T[] items)
        {
            _repository.UpdateNoValidate(items);
        }
    }
}
