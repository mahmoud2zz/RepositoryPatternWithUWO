using System;
using RepositoryPatternWithUWO.Core.Interfaces;
using RepositoryPatternWithUWO.Core.Models;
using RepositoryPatternWithUWO.EF.Repositores;

namespace RepositoryPatternWithUWO.EF
{
	public class UintOfWork	: IUintOfWork
    {

        private readonly ApplicationDbContext _dbContext;

        public IBaseRepository<Author> Authors { get; private set; }

        public IBaseRepository<Book> Books { get; private set; }

       

        public UintOfWork(ApplicationDbContext dbContext)
        {
           
            
            _dbContext = dbContext;
            Authors = new BaseRepository<Author>(dbContext);
            Books = new BaseRepository<Book>(dbContext);
        }


        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

