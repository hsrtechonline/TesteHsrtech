using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HsrTech.Domain.Interface.Service
{
    public interface IServiceBase<T> where T : class
    {
        void Add(params T[] items);
        void update(params T[] items);
        void Delete(params T[] items);
        void AddNoValidate(params T[] items);
        void UpdateNoValidate(params T[] items);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navProperties);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navProperties);        
        IList<T> GetAll();
        void Dispose();
    }
}