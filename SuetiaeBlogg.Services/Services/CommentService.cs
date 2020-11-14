using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Models.Comments;
using SuetiaeBlogg.Core.Services;

namespace SuetiaeBlogg.Services.Services
{
    public class CommentService : ICommentService
    {
        public Task<ServiceResponse<Comment>> CreateComment(AddCommentDto newComment)
        {
            throw new NotImplementedException();
        }

        
    }
}
