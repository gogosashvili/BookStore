using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models
{
    public class UserBookEstimation
    {
        public int Id { get; set; }

        [ForeignKey("UserBook")]
        public int UserBookId { get; set; }

        public UserBook UserBook { get; set; }

        public int Score { get; set; }
    }
}
