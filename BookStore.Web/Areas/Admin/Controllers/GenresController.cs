using BookStore.Services;
using BookStore.Services.Models.GenreAdministrationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GenresController : Controller
    {
        private GenreAdministrationService _genreAdministrationService;

        public GenresController()
        {
            _genreAdministrationService = new GenreAdministrationService();
        }

        // GET: Admin/Genres
        public ActionResult Index()
        {
            var genres = _genreAdministrationService.All();
            return View(genres);
        }

        // GET: Admin/Genres/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _genreAdministrationService.GetEditModel(id);
            return View(model);
        }

        // POST: Admin/Genres/Edit/5
        [HttpPost]
        public ActionResult Edit(GenreEditModel model)
        {

            _genreAdministrationService.Save(model);
            return RedirectToAction("Index");
        }

        // GET: Admin/Genres/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Genres/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
