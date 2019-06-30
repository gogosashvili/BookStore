using BookStore.Domain;
using BookStore.Domain.Models;
using BookStore.Services.Models.GenreAdministrationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{

    public class GenreAdministrationService
    {
        private ApplicationDbContext _db;

        public GenreAdministrationService()
        {
            _db = new ApplicationDbContext();
        }
        
        public IEnumerable<GenreListItem> All()
        {
            var genres = _db.Genres.Select(m => new GenreListItem
            {
                Id = m.Id,
                Name = m.Name
            });

            return genres;
        }

        public GenreEditModel GetEditModel(int id)
        {
            if(id == 0)
            {
                return new GenreEditModel();
            }

            var genre = _db.Genres.Find(id);
            return new GenreEditModel
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        public void Save(GenreEditModel model)
        {
            if(model.Id == 0)
            {
                _db.Genres.Add(new Genre
                {
                    Id = model.Id,
                    Name = model.Name
                });
            }
            else
            {
                var genre = _db.Genres.Find(model.Id);
                genre.Name = model.Name;
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
