using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuetiaeBlogg.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository Posts { get; }
        ICategoryRepository Categories { get; }
        Task<int> CommitAsync();
    }
}
