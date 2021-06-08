using Models;
using Resources;
using System;
using System.Collections.Generic;

namespace BusinessLogic.IManagers
{
    public interface IBookManager
    {
        public List<BookResource> GetAll();
        public BookResource GetById(long Id);
        public void Insert(BookModel bookModel);
        public void Update(BookModel bookModel);
        public void Delete(long Id);
    }
}
