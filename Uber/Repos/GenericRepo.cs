
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Uber.Models;

namespace Uber.Repos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext context;
        public GenericRepo(AppDbContext context)
        {
            this.context = context;
        }
        public async Task Add(T item)
        {
            await context.Set<T>().AddAsync(item);
        }

        public void Delete(T item)
        {
            context.Set<T>().Remove(item);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetPaged(int PageNumber, int PageSize)
        {
            return await context.Set<T>().Skip((PageNumber-1)*PageSize).Take(PageSize).ToListAsync();
        }

        public void Update(T item)
        {
            context.Set<T>().Update(item);
        }
    }
}
