using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class BookApiController : ApiController
    {
        StudentdetailsEntities db = new StudentdetailsEntities();
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetBooks()
        {
            List<Book> list = db.Books.ToList();
            return Ok(list);
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetBooksByAuthorId(int id)
        {
            var book = db.Books.Where(model => model.author_id == id);
            return Ok(book);
        }
        [System.Web.Http.HttpPost]
        public IHttpActionResult BookInsert(Book b)
        {
            var existingBook = db.Books.FirstOrDefault(x => x.book_name == b.book_name && x.author_id == b.author_id);

            if (existingBook != null)
            {
                return BadRequest("Book with same name and author already exists.");
            }
            else
            {
                db.Books.Add(b);
                db.SaveChanges();
                return Ok("Book inserted successfully.");
            }
        }
    }
}
