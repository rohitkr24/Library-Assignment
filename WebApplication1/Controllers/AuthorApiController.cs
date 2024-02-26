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
    public class AuthorApiController : ApiController
    {
        StudentdetailsEntities db = new StudentdetailsEntities();
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetAuthors()
        {
            List<Author> list = db.Authors.ToList();
            return Ok(list);
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetAuthorsById(int id)
        {
            var auth = db.Authors.Where(model => model.id == id).FirstOrDefault();
            return Ok(auth);
        }
        [System.Web.Http.HttpPost]
        public IHttpActionResult AuthInsert(Author a)
        {
            db.Authors.Add(a);
            db.SaveChanges();
            return Ok("Author inserted successfully.");
        }

    }
}
