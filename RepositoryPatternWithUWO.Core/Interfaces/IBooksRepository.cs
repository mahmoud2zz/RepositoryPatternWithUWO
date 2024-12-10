using System;
using RepositoryPatternWithUWO.Core.Models;

namespace RepositoryPatternWithUWO.Core.Interfaces
{
	public interface IBooksRepository:IBaseRepository<Book>
	{
		IEnumerable<Book> GetAllBooks();

	
	}
}

