using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models
{
    public class Book
    {
        public Book()
        {
            BookImages = new Collection<BookImage>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public ConditionType ConditionType { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public decimal Price { get; set; }

        public DealType DealType { get; set; }

        public BookStatus Status { get; set; }

        public virtual ICollection<BookImage> BookImages { get; set; }

        [ForeignKey("User")]
        public string UserdId { get; set; }

        public User User { get; set; }
    }

    public enum BookStatus
    {
        Active = 1,
        Sold = 2
    }

    public enum ConditionType
    {
        New = 1,
        Used = 2
    }

    public enum DealType
    {
        Gift = 1,
        Swap = 2,
        Paid = 3
    }
}
