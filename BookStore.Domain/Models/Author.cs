using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models
{
    public class Author
    {
        public Author()
        {
            Books = new Collection<Book>();
        }

        public int Id { get; set; }

        public string Pseudonym { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }

        public string GetName()
        {
            return $"{FirstName} {LastName}(${Pseudonym})";
        }
    }
}
