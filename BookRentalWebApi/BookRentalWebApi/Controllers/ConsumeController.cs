using BookRentalWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace BookRentalWebApi.Controllers
{
    public class ConsumeController : Controller
    {
        HttpClient hc = new HttpClient();
        // GET: Consume
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Display()
        {
            List<Book> list = new List<Book>();
            hc.BaseAddress = new Uri("https://localhost:44394/Api/WebApi/GetData");
            var consume = hc.GetAsync("GetData");
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Book>>();
                list = display.Result;
            }
            return View(list);
        }
        [HttpGet]
        public ActionResult SendData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendData(Book b)
        {
            hc.BaseAddress = new Uri("https://localhost:44394/Api/WebApi/Insert");
            var consume = hc.PostAsJsonAsync("Insert", b);
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Display");
            }
            else
            {
                return HttpNotFound();
            }


        }

        public ActionResult BookDetail(int id)
        {
            Book data = new Book();
            hc.BaseAddress = new Uri("https://localhost:44394/Api/Book/Details");
            var consume = hc.GetAsync("Details?id=" + id.ToString());
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Book>();
                display.Wait();
                data = display.Result;
            }
            return View(data);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            Book data = null;
            hc.BaseAddress = new Uri("https://localhost:44394/Api/Book/Update");
            var consume = hc.GetAsync("Update?id=" + id.ToString());
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Book>();
                display.Wait();
                data = display.Result;
            }
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Book b)
        {
            hc.BaseAddress = new Uri("https://localhost:44394/Api/Book/Update");
            var consume = hc.PutAsJsonAsync<Book>("Update",b);
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Display");
            }
            return View();
        }
        public ActionResult DeleteData(int id)
        {
            Book data = new Book();
            hc.BaseAddress = new Uri("https://localhost:44394/Api/Book/Delete");
            var consume = hc.DeleteAsync("Delete?id=" + id.ToString());
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Display");
            }
            return View();
        }

    }
}
