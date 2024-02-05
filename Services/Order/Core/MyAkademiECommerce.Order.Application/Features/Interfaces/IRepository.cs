using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyAkademiECommerce.Order.Application.Features.Interfaces
{
   public  interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsnyc();
        Task<T> GetByIdAsnyc(int id);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T> GetOrderByFilter(Expression<Func<T, bool>> filter);
    }
}
