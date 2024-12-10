using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUWO.Core.Consts;
using RepositoryPatternWithUWO.Core.Interfaces;

namespace RepositoryPatternWithUWO.EF.Repositores
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        protected ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add(T Item)
        {
            _dbContext.Set<T>().Add(Item);

            return Item;
            
           
        }


        public IEnumerable<T> AddRange(IEnumerable<T> items)
        {
            _dbContext.Set<T>().AddRange(items);

        

            return items;

        }
        public T Update(T item)
        {

            _dbContext.Set<T>().Update(item);
           

            return item;
        }

        public void Attach(T item)
        {
            _dbContext.Set<T>().Attach(item);
        }

        public int Count()
        {
            return _dbContext.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> expression)
        {

            return _dbContext.Set<T>().Count(expression);
        }

        public void Delete(T item)
        {
            _dbContext.Set<T>().Remove(item);

        
           
        }

        public T Find(Expression<Func<T, bool>> expression, string[] includes = null)
        {

            

            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null)
            {
                foreach (var incluse in includes)
                {
                    query = query.Include(incluse);
                }
            }


            return query.SingleOrDefault(expression);

        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null)
            {
                foreach (var incluse in includes)
                {
                    query = query.Include(incluse);
                }
            }

            return query.Where(expression).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> expression, int? take, int? skip, Expression<Func<T, object>> orderBy = null, string orderByDirection = "ASC")
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            if (skip.HasValue)
            {
                query = query.Take(skip.Value);
            }

            if (orderBy != null)
            {
                if (orderByDirection == OrdarBy.Ascending)
                {
                    query = query.OrderBy(orderBy);
                }
                else
                {
                    query = query.OrderByDescending(orderBy);
                }

              


            }

            return query.ToList();


        }
        public IEnumerable<T> GetAll()=> _dbContext.Set<T>().ToList();
   



        public async Task<T> GetById(int id) =>   await _dbContext.Set<T>().FindAsync(id);

        public void DeleteRange(IEnumerable<T> itmes)
        {
            _dbContext.Set<T>().RemoveRange(itmes);
         

        }
    }

}