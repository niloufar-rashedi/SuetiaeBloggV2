using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SuetiaeBlogg.Core.Models
{
        public class Author
        {
            [Key]
            public int AuthorId { get; set; }
            [Required]
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Username { get; set; }
            public byte[] PasswordHash { get; set; }
            public byte[] PasswordSalt { get; set; }
    }
}
