using SuetiaeBlogg.Core.Models;
using System.Collections.Generic;

namespace SuetiaeBlogg.Services.Services
{
    public interface IAuthorService
    {
        Author Authenticate(string username, string password);
        Author Create(Author author, string password);
        void Delete(int id);
        IEnumerable<Author> GetAll();
        Author GetById(int id);
        void Update(Author userParam, string password = null);
    }
}