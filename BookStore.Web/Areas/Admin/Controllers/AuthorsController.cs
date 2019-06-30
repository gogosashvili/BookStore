using BookStore.Services;
using BookStore.Services.Models.AuthorAdministrationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Web.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AuthorsController : Controller
    {
        private AuthorAdministrationService _authorAdministrationService;

        public AuthorsController()
        {
            _authorAdministrationService = new AuthorAdministrationService();
        }

        // GET: Admin/Authors
        public ActionResult Index()
        {
            var authors = _authorAdministrationService.All();
            return View(authors);
        }

        // GET: Admin/Authors/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _authorAdministrationService.GetEditModel(id);
            return View(model);
        }

        // POST: Admin/Authors/Edit/5
        [HttpPost]
        public ActionResult Edit(AuthorEditModel model)
        {

            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.FirstName) && string.IsNullOrEmpty(model.LastName) && string.IsNullOrEmpty(model.Pseudonym))
                {
                    ModelState.AddModelError("", "Please fill at least one field");
                    return View(model);
                }

                _authorAdministrationService.Save(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Admin/Authors/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Authors/Delete/5
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
