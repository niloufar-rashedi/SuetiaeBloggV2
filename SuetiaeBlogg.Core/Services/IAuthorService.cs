using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Authors;
using SuetiaeBlogg.Core.Models.Posts;

namespace SuetiaeBlogg.Core.Services
{
    public interface IAuthorService
    {
        public Task<ServiceResponse<IEnumerable<GetPostDto>>> FindPostsByAuthorId(int authorId);
        public Task<ServiceResponse<IEnumerable<GetAuthorDto>>> GetAllAuthors();
        Author Authenticate(string username, string password);
        Author Create(Author author, string password);
        void Delete(int id);
        IEnumerable<Author> GetAll();
        Author GetById(int id);
        void Update(Author userParam, string password = null);


    }
}
