using System;
using System.Text.Json.Serialization;

namespace RepositoryPatternWithUWO.Core.Models
{
	public class Author
	{
		public  int Id { set; get; }

		public string Name { set; get; }
        [JsonIgnore] 
        public List<Book> Books { set; get; }


	
	}
}

