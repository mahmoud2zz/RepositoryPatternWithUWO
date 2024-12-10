using System;
using RepositoryPatternWithUWO.Core.Models;

namespace RepositoryPatternWithUWO.Core.Interfaces
{
	public interface IUintOfWork:IDisposable
	{
        IBaseRepository<Author> Authors { get; }

       IBaseRepository<Book> Books { get; }

        int Complete();



    }
}

