using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Comments;

namespace SuetiaeBlogg.Core.Services
{
    public interface ICommentService
    {
        public Task<ServiceResponse<Comment>> CreateComment(AddCommentDto newComment);
    }
}
