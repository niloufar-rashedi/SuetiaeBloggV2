using System;
using System.Collections.Generic;
using System.Text;

namespace SuetiaeBlogg.Core.Models.Authors
{
    public class GetAuthorDto
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
