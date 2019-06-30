using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Models.BookAdministrationService
{
    public class BookListItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ConditionType { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }

        public string DealType { get; set; }

        public string Status { get; set; }

        public string ImageName { get; set; }
    }
}
