using BookStore.Domain;
using BookStore.Domain.Models;
using BookStore.Services.Models.BookServise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BookService
    {
        private ApplicationDbContext _db;

        public BookService()
        {
            _db = new ApplicationDbContext();
        }

        public HomePageModel GetHomePageModel()
        {
            var model = new HomePageModel
            {
                GiftBooks = _db.Books.Where(m => m.DealType == DealType.Gift).OrderByDescending(m => m.Id).Take(6).ToList().Select(m => new BookItem
                {
                    Author = m.Author.GetName(),
                    Id = m.Id,
                    ImageName = m.BookImages.FirstOrDefault().FileName,
                    Title = m.Title
                }),
                PaidBooks = _db.Books.Where(m => m.DealType == DealType.Paid).OrderByDescending(m => m.Id).Take(6).ToList().Select(m => new BookItem
                {
                    Author = m.Author.GetName(),
                    Id = m.Id,
                    ImageName = m.BookImages.FirstOrDefault().FileName,
                    Title = m.Title
                }),
                SwapBooks = _db.Books.Where(m => m.DealType == DealType.Swap).OrderByDescending(m => m.Id).Take(6).ToList().Select(m => new BookItem
                {
                    Author = m.Author.GetName(),
                    Id = m.Id,
                    ImageName = m.BookImages.FirstOrDefault().FileName,
                    Title = m.Title
                })
            };

            return model;
        }

        public IEnumerable<BookItem> GetBooks(GetBooksFilterModel request)
        {
            var books = _db.Books.Where(m => m.DealType == request.DealType);

            if (string.IsNullOrEmpty(request.Author))
            {
                request.Author = request.Author.ToLower().Trim();
                books = books.Where(m => (m.Author.FirstName + " " + m.Author.LastName + " " + m.Author.Pseudonym).ToLower().Contains(request.Author));
            }

            if (string.IsNullOrEmpty(request.Title))
            {
                request.Title = request.Title.ToLower().Trim();
                books = books.Where(m => m.Title.ToLower().Contains(request.Title));
            }

            return books.ToList().Select(m => new BookItem
            {
                Author = m.Author.GetName(),
                Id = m.Id,
                ImageName = m.BookImages.FirstOrDefault().FileName,
                Title = m.Title
            });
        }
    }
}
