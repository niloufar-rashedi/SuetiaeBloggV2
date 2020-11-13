using System.Threading.Tasks;
using SuetiaeBlogg.Core.Repositories;
using SuetiaeBlogg.Data.Repositories;

namespace SuetiaeBlogg.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SuetiaeBloggDbContext _context;

        public IPostRepository Posts { get; }
        public IAuthorRepository Authors { get; }
        public ICommentRepository Comments { get; }
        public ICategoryRepository Categories { get; }
        public ITagRepository Tags { get; }
        public IPostCategoriesRepository PostCategories { get; }
        public IPostTagsRepository PostTags { get; set; }
        
       


        public UnitOfWork(SuetiaeBloggDbContext context)
        {
            this._context = context;
            this.Posts = new PostRepository(_context);
            this.Categories = new CategoryRepository(_context);
            this.PostCategories = new PostCategoriesRepository(_context);
        }

        //public IPostRepository Posts => _postRepository = _postRepository ?? new PostRepository(_context);

        //public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);



        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
