using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Services.Models.BookAdministrationService
{
    public class BookEditModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public IEnumerable<SelectListItem> Authors { get; set; } = Enumerable.Empty<SelectListItem>();


        [Required]
        public ConditionType ConditionType { get; set; }

        public IEnumerable<SelectListItem> ConditionTypes
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem{ Text = ConditionType.New.ToString(), Value = ConditionType.New.ToString() },
                    new SelectListItem{ Text = ConditionType.Used.ToString(), Value = ConditionType.Used.ToString() }
                };
            }
        }

        public decimal Price { get; set; }


        [Required]
        public DealType DealType { get; set; }

        public IEnumerable<SelectListItem> DealTypes
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem{ Text = DealType.Gift.ToString(), Value = DealType.Gift.ToString() },
                    new SelectListItem{ Text = DealType.Swap.ToString(), Value = DealType.Swap.ToString() },
                    new SelectListItem{ Text = DealType.Paid.ToString(), Value = DealType.Paid.ToString() }
                };
            }
        }


        [Required]
        public BookStatus Status { get; set; }

        public IEnumerable<SelectListItem> Statuses
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem{ Text = BookStatus.Active.ToString(), Value = BookStatus.Active.ToString() },
                    new SelectListItem{ Text = BookStatus.Sold.ToString(), Value = BookStatus.Sold.ToString() }
                };
            }
        }

        [Required]
        public int GenreId { get; set; }

        public IEnumerable<SelectListItem> Genres { get; set; } = Enumerable.Empty<SelectListItem>();

        public string UserId { get; set; }

        public List<string> ImageNames { get; set; } = new List<string>();
    }
}
