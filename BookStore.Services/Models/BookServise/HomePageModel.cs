using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Models.BookServise
{
    public class HomePageModel
    {
        public IEnumerable<BookItem> GiftBooks { get; set; } = Enumerable.Empty<BookItem>();

        public IEnumerable<BookItem> PaidBooks { get; set; } = Enumerable.Empty<BookItem>();

        public IEnumerable<BookItem> SwapBooks { get; set; } = Enumerable.Empty<BookItem>();
    }
}
