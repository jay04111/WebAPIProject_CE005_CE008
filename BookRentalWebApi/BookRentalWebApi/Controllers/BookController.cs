using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookRentalWebApi.Models;

namespace BookRentalWebApi.Controllers
{
    public class BookController : ApiController
    {
        BookStoreEntities db = new BookStoreEntities();
        [HttpGet]
        public IHttpActionResult Details(int id)
        {
            Book data = db.Books.Where(x => x.bid == id).SingleOrDefault();
            return Ok(data);
        }
        [HttpPut]
        public IHttpActionResult Update(Book b)
        {
            Book data = db.Books.Where(x => x.bid == b.bid).SingleOrDefault();
            data.bname = b.bname;
            data.stock = b.stock;
            data.price = b.price;
            db.SaveChanges();
            return Ok();

        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Book data = db.Books.Where(x => x.bid == id).SingleOrDefault();
            db.Books.Remove(data);
            db.SaveChanges();
            return Ok();

        }
    }
}
