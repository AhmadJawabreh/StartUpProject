﻿using Data;
using Entities;
namespace Repoistories
{
    public class UnitOfWork : IBookManager
    {
        private readonly ApplicationDbContext _context;
        public IRepository<Publisher> _publishers;
        public IRepository<Book> _books;
        public IRepository<Author> _authors;


        public UnitOfWork(ApplicationDbContext context) 
        {
            this._context = context;
        }


        public IRepository<Publisher> Publishers
        {
            get
            {
                return _publishers ?? (_publishers = new BaseRepository<Publisher>(_context));
            }
        }

        public IRepository<Book> Books 
        {
            get
            {
                return _books ?? (_books = new BaseRepository<Book>(_context));
            }
        
        }
        public IRepository<Author> Athuors
        {
          get 
            {
                return _authors ?? (_authors = new BaseRepository<Author>(_context));
            }

        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
