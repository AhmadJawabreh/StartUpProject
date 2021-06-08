using BusinessLogic.IManagers;
using BusinessLogic.Mappers;
using Entities;
using Models;
using Repoistories;
using Resources;
using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    class BookManager : IBookManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookManager(IUnitOfWork unitOfWork) 
        {
            this._unitOfWork = unitOfWork;
        }

        public List<BookResource> GetAll()
        {
            try
            {
                IEnumerable<Book> Books = _unitOfWork.Books.GetAll();
                return BookMapper.ConvertToListOfBookResources(Books);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        public BookResource GetById(long Id)
        {
            try
            {  
                Book book = _unitOfWork.Books.GetById(Id);
                return BookMapper.ConvertToBookResource(book);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        public void Insert(BookModel bookModel)
        {
            try
            {
                Book book = BookMapper.ConvertToBook(bookModel);
                _unitOfWork.Books.Insert(book);
                this._unitOfWork.Save();          
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        public void Update(BookModel bookModel)
        {
            try
            {
                Book book = BookMapper.ConvertToBook(bookModel);
                _unitOfWork.Books.Update(book);
                this._unitOfWork.Save();
            }
            catch (Exception Error) 
            {
                throw Error;
            }
        }

        public void Delete(long Id)
        {
            try
            {
                _unitOfWork.Books.Delete(Id);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }
    }
}
