using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUWO.Core.Interfaces;
using RepositoryPatternWithUWO.Core.Models;
using RepositoryPatternWithUWO.EF;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RepositoryPatternWithUWO.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {

        private readonly IUintOfWork _uintOfWork;

        public AuthorsController(IUintOfWork uintOfWork)
        {
            _uintOfWork = uintOfWork;
        }




        //private readonly IBaseRepository<Author> _baseRepository;

        //public AuthorsController(IBaseRepository<Author> baseRepository)
        //{
        //    _baseRepository = baseRepository;
        //}



        // GET: api/values
        [HttpGet("GetById")]
        public IActionResult GetById()
        {
            return Ok(_uintOfWork.Authors.GetById(1));
        }

        // GET api/values/5
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_uintOfWork.Authors.GetAll());
        }




        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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

