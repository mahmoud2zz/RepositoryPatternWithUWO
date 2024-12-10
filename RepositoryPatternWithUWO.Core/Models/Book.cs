using System;
namespace RepositoryPatternWithUWO.Core.Models
{
	public class Book
	{

		public int Id { set; get; }

		public string Title { set; get; }

		public int AuthorId { set; get; }

		public Author Author { set; get; }

	

	}
}

