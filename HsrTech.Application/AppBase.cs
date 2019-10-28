using HsrTech.Application.Interface;
using HsrTech.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HsrTech.Application
{
    public class AppBase<T> : IDisposable, IAppBase<T> where T : class
    {
        private readonly IServiceBase<T> _serviceBase;

        public AppBase(IServiceBase<T> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(params T[] items)
        {
            _serviceBase.Add(items);
        }

        public void AddNoValidate(params T[] items)
        {
            _serviceBase.AddNoValidate(items);
        }

        public void Delete(params T[] items)
        {
            _serviceBase.Delete(items);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

        public IList<T> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navProperties)
        {
            return _serviceBase.GetList(where, navProperties);
        }

        
        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navProperties)
        {
            return _serviceBase.GetSingle(where, navProperties);
        }      
        public void Update(params T[] items)
        {
            _serviceBase.update(items);
        }

        public void UpdateNoValidate(params T[] items)
        {
            _serviceBase.UpdateNoValidate(items);
        }
    }
}
