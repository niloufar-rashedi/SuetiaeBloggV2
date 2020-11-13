using System;
using System.Threading.Tasks;
using SuetiaeBlogg.Core.Models;
using SuetiaeBlogg.Core.Repositories;
using SuetiaeBlogg.Data.Repositories;

namespace SuetiaeBlogg.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SuetiaeBloggDbContext _context;

        private IRepository<Post> postRepository;
        private IRepository<Author> authorRepository;
        public IRepository<Comment> commentRepository;
        public IRepository<Category> categoryRepository;
        public IRepository<Tag> tagRepository;
        public IRepository<PostCategories> postCategoriesRepository;
        public IRepository<PostTags> postTagsRepository;
        public IRepository<Post> PostRepository
        {
            get
            {

                if (this.postRepository == null)
                {
                    this.postRepository = new Repository<Post>(_context);
                }
                return postRepository;
            }
        }
        public IRepository<Author> AuthorRepository
        {
            get
            {

                if (this.authorRepository == null)
                {
                    this.authorRepository = new Repository<Author>(_context);
                }
                return authorRepository;
            }
        }
        public IRepository<Comment> CommentRepository
        {
            get
            {

                if (this.commentRepository == null)
                {
                    this.commentRepository = new Repository<Comment>(_context);
                }
                return commentRepository;
            }
        }
        public IRepository<Category> CategoryRepository
        {
            get
            {

                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new Repository<Category>(_context);
                }
                return categoryRepository;
            }
        }

        public IRepository<Tag> TagRepository
        {
            get
            {

                if (this.tagRepository == null)
                {
                    this.tagRepository = new Repository<Tag>(_context);
                }
                return tagRepository;
            }
        }

        public IRepository<PostCategories> PostCategoriesRepository
        {
            get
            {

                if (this.postCategoriesRepository == null)
                {
                    this.postCategoriesRepository = new Repository<PostCategories>(_context);
                }
                return postCategoriesRepository;
            }
        }

        public IRepository<PostTags> PostTagsRepository
        {
            get
            {

                if (this.postTagsRepository == null)
                {
                    this.postTagsRepository = new Repository<PostTags>(_context);
                }
                return postTagsRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
