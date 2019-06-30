using BookStore.Domain;
using BookStore.Domain.Models;
using BookStore.Services.Models.AuthorAdministrationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
   public  class AuthorAdministrationService
    {
        private ApplicationDbContext _db;

        public AuthorAdministrationService()
        {
            _db = new ApplicationDbContext();
        }

        public IEnumerable<AuthorListItem> All()
        {
            var genres = _db.Authors.Select(m => new AuthorListItem
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Pseudonym = m.Pseudonym
            });

            return genres;
        }

        public AuthorEditModel GetEditModel(int id)
        {
            if (id == 0)
            {
                return new AuthorEditModel();
            }

            var author = _db.Authors.Find(id);
            return new AuthorEditModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Pseudonym = author.Pseudonym
            };
        }

        public void Save(AuthorEditModel model)
        {
            if (model.Id == 0)
            {
                _db.Authors.Add(new Author
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Pseudonym = model.Pseudonym
                });
            }
            else
            {
                var author = _db.Authors.Find(model.Id);
                author.FirstName = model.FirstName;
                author.LastName = model.LastName;
                author.Pseudonym = model.Pseudonym;
            }

            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var genre = _db.Genres.Find(id);
            _db.Genres.Remove(genre);
            _db.SaveChanges();
        }
    }
}
