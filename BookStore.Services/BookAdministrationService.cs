using BookStore.Domain;
using BookStore.Domain.Models;
using BookStore.Services.Models.BookAdministrationService;
using BookStore.Services.Models.GenreAdministrationService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace BookStore.Services
{
    public class BookAdministrationService
    {
        private ApplicationDbContext _db;

        public BookAdministrationService()
        {
            _db = new ApplicationDbContext();
        }

        public IEnumerable<BookListItem> All()
        {

            var books = _db.Books.Select(m => new BookListItem
            {
                Id = m.Id,
                Author = m.Author.FirstName + " " + m.Author.LastName + "(" + m.Author.Pseudonym + ")",
                ConditionType = m.ConditionType.ToString(),
                Genre = m.Genre.Name,
                DealType = m.DealType.ToString(),
                ImageName = m.BookImages.FirstOrDefault().FileName,
                Price = m.Price,
                Status = m.Status.ToString(),
                Title = m.Title
            });

            return books;
        }

        public BookEditModel GetEditModel(int id)
        {
            var model = new BookEditModel();
            AppendData(model);

            if (id == 0)
            {
                return model;
            }

            var book = _db.Books.Find(id);
            model.Id = book.Id;
            model.AuthorId = book.AuthorId;
            model.ConditionType = book.ConditionType;
            model.DealType = book.DealType;
            model.GenreId = book.GenreId;
            model.Price = book.Price;
            model.Status = book.Status;
            model.Title = book.Title;
            model.ImageNames = book.BookImages.Select(x => x.FileName).ToList();
            return model;
        }

        public void Save(BookEditModel model)
        {
            if (model.Id == 0)
            {
                _db.Books.Add(new Book
                {
                    AuthorId = model.AuthorId,
                    ConditionType = model.ConditionType,
                    DealType = model.DealType,
                    GenreId = model.GenreId,
                    Price = model.Price,
                    Status = model.Status,
                    Title = model.Title,
                    UserdId = model.UserId,
                    BookImages = model.ImageNames.Select(x => new BookImage
                    {
                        FileName = x
                    }).ToList()
                });
            }
            else
            {
                var book = _db.Books.Find(model.Id);
                book.AuthorId = model.AuthorId;
                book.ConditionType = model.ConditionType;
                book.DealType = model.DealType;
                book.GenreId = model.GenreId;
                book.Price = model.Price;
                book.Status = model.Status;
                book.Title = model.Title;
                book.UserdId = model.UserId;
            }
            _db.SaveChanges();
        }


        public void AppendData(BookEditModel model)
        {
            model.Genres = _db.Genres.ToList().Select(m => new SelectListItem
            {
                Text = m.Name,
                Value = m.Id.ToString()
            });

            model.Authors = _db.Authors.ToList().Select(m => new SelectListItem
            {
                Text = m.GetName(),
                Value = m.Id.ToString()
            });

        }
    }
}
