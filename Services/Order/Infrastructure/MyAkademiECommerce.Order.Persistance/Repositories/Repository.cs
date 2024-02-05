using Microsoft.EntityFrameworkCore;
using MyAkademiECommerce.Order.Application.Features.Interfaces;
using MyAkademiECommerce.Order.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyAkademiECommerce.Order.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OrderContext _context;

        public Repository(OrderContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();  
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsnyc()
        {
           return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsnyc(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetOrderByFilter(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task UpdateAsync(T entity)
        {
           _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
