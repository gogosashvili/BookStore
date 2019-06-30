using BookStore.Services;
using BookStore.Services.Models.BookAdministrationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.IO;

namespace BookStore.Web.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    public class BooksController : Controller
    {
        private BookAdministrationService _bookAdministrationService;

        public BooksController()
        {
            _bookAdministrationService = new BookAdministrationService();
        }

        public ActionResult Index()
        {
            var model = _bookAdministrationService.All();
            return View(model);
        }


        // GET: Admin/Books/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _bookAdministrationService.GetEditModel(id);
            return View(model);
        }

        // POST: Admin/Books/Edit/5
        [HttpPost]
        public ActionResult Edit(BookEditModel model, HttpPostedFileBase[] Images )
        {
            model.UserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                if(model.Id == 0)
                {
                    UploadFiles(model, Images);
                }
         
                _bookAdministrationService.Save(model);
                return RedirectToAction("Index");
            }

            _bookAdministrationService.AppendData(model);
            return View(model);
        }

        public void UploadFiles(BookEditModel model, HttpPostedFileBase[] images)
        {
            if(images != null)
            {
                foreach (HttpPostedFileBase file in images)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Guid.NewGuid().ToString() + "" + Path.GetExtension(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + InputFileName);
                        file.SaveAs(ServerSavePath);
                        model.ImageNames.Add(InputFileName);
                    }
                }
            }
        }


        // POST: Admin/Books/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
