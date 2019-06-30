using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Models.BookServise
{

    public class BookItem
    {
        public int Id { get; set; }

        public string ImageName { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }
    }
}
