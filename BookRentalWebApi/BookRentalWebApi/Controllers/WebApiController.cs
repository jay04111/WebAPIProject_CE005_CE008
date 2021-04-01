using BookRentalWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookRental.Controllers
{
    public class WebApiController : ApiController
    {
            BookStoreEntities db = new BookStoreEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetData()
        {
            List<Book> list = db.Books.ToList();
            return Ok(list);
        }
       [System.Web.Http.HttpPost]
        public IHttpActionResult Insert(Book b)
        {
            db.Books.Add(b);
            db.SaveChanges();
            return Ok();
        }
    }
}
