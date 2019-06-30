using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }

        [ForeignKey("Parent")]
        public int? ParnetId { get; set; }

        public Comment Parent { get; set; }
    }
}
