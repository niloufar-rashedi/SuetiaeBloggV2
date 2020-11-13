using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuetiaeBlogg.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public void Save();
        public void Dispose(bool disposing);
        public new void Dispose();
        //Task<int> CommitAsync();


    }
}
