using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Repositories;
using SuetiaeBlogg.Core.Services;

namespace SuetiaeBlogg.Services.Services
{
    public class PostService: IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Task<ServiceResponse<Post>> CreatePost(Post newPost)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<Task> DeletePost(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<IEnumerable<Post>>> GetAllWithCategories()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Post>> GetPostById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<IEnumerable<Post>>> GetPostsByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<Task> UpdatePost(Post postToBeUpdated, Post post)
        {
            throw new NotImplementedException();
        }
    }
}
