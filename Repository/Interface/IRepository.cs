using Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> AsyncSave(T entity);
        Task<T> AsyncGetById(long id);
        void AsyncRemove(T entity);
        Task<T> AsyncUpdate(T entity);

        T Save(T entity);
        IEnumerable<T> GetAll();
        T GetById(long id);
        void Remove(T entity);
        T Update(T entity);
        IEnumerable<Model.POCO.Customers> WithPaging(int page, int pageSize);
    }
}
