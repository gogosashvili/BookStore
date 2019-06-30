using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Models.BookServise
{
    public class GetBooksFilterModel
    {
        public DealType DealType { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }
    }
}
