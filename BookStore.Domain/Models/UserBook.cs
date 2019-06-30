using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models
{
    public class UserBook
    {
        public UserBook()
        {
            Estimations = new Collection<UserBookEstimation>();
        }

        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }

        public string BookTitle { get; set; }

        public string AuthorName { get; set; }

        public ICollection<UserBookEstimation> Estimations { get; set; }
    }
}
