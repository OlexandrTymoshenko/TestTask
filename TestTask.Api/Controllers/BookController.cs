using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TestTask.Management.Interfaces;
using TestTask.Models;

namespace TestTask.Api.Controllers
{
    [RoutePrefix("api/Book")]
    public class BookController : ApiController
    {
        private IBookManager _bookManager;
        public BookController(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }

        [Route("Get")]
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookManager.GetAll();
        }

        [Route("SearchByAuthorTitle")]
        [HttpGet]
        public IEnumerable<Book> SearchByAuthorTitle(string searchPattern)
        {
            if (!string.IsNullOrEmpty(searchPattern))
            {
                return _bookManager.SearchByAuthorTitle(searchPattern);
            }
            return _bookManager.GetAll();
        }

        [Route("Create")]
        [HttpPost]
        public IHttpActionResult Create([FromUri]Book book)
        {
            if(book ==null) ModelState.AddModelError("exception", new Exception("all fields are required"));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _bookManager.Create(book);
            return Ok();
        }

        [Route("Update")]
        [HttpPut]
        public IHttpActionResult Update([FromUri]Book book)
        {
            if (book == null) ModelState.AddModelError("exception", new Exception("all fields are required"));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _bookManager.Update(book);
            return Ok();
        }

        [Route("Delete")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            if (id != Guid.Empty)
            _bookManager.Remove(id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bookManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}