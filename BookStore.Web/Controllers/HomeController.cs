using BookStore.Domain.Models;
using BookStore.Services;
using BookStore.Services.Models.BookServise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private BookService _bookService;

        public HomeController()
        {
            _bookService = new BookService();
        }

        public ActionResult Index()
        {
            var model = _bookService.GetHomePageModel();
            return View(model);
        }

        public ActionResult Search(GetBooksFilterModel request)
        {
            var model =  _bookService.GetBooks(request);
            return View(model);
        }
    }
}