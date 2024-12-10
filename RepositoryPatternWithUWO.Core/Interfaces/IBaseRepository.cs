using System;
using System.Linq.Expressions;
using RepositoryPatternWithUWO.Core.Consts;

namespace RepositoryPatternWithUWO.Core.Interfaces
{
	public interface IBaseRepository<T> where T:class
	{

		 Task<T> GetById(int id);

		IEnumerable<T> GetAll();

		T Find(Expression<Func<T, bool>> expression,string[] includes	=null);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> expression, string[] includes = null);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> expression,int? take ,int? skip, Expression<Func<T, object>> orderBy=null,
            string orderByDirection= OrdarBy.Ascending);

		T Add(T Item);

		IEnumerable<T> AddRange(IEnumerable<T> items);


		T Update(T item);

		void Delete(T item);

        void DeleteRange(IEnumerable<T> itmes);



        void Attach(T item);

		int Count();

        int Count(Expression<Func<T, bool>> expression);


    }

}

