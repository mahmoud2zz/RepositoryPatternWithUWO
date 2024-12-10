using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUWO.Core.Interfaces;
using RepositoryPatternWithUWO.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RepositoryPatternWithUWO.Api.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        //private readonly IBaseRepository<Book> _baseRepository;

        private readonly IUintOfWork _uintOfWork;

        public BooksController(IUintOfWork uintOfWork)
        {
            _uintOfWork = uintOfWork;
        }

        //public BooksController(IBaseRepository<Book> baseRepository)
        //{
        //    _baseRepository = baseRepository;
        //}

        [HttpGet]
        public IActionResult ById()
        {
        
            return Ok(_uintOfWork.Books.GetById(1));
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_uintOfWork.Books.GetAll());
        }

        [HttpGet("GetAllByName")]
       
          

        

        [HttpGet("GetByName")]
        public IActionResult GetAllByName()
        {  
            return Ok(_uintOfWork.Books.FindAll(b => b.Title == "atomic habits", new[] { "Author" }));

        }

        [HttpGet("GetOrderBy")]
        public IActionResult GetByOrder()
        {

            return Ok(_uintOfWork.Books.FindAll(b => b.Title == "atomic habits",null,null,b=>b.Id));

        }

        // POST api/values
        [HttpPost("AddItem")]
        public IActionResult Post()
        {
            var book = _uintOfWork.Books.Add(new Book() { Title = "clean code", AuthorId = 3 });
            _uintOfWork.Complete();
            return Ok(book);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}

