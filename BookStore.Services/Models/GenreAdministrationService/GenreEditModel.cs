using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Models.GenreAdministrationService
{
    public class GenreEditModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
