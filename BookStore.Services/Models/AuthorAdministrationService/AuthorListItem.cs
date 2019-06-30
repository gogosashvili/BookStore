﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Models.AuthorAdministrationService
{
    public class AuthorListItem
    {
        public int Id { get; set; }

        public string Pseudonym { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
