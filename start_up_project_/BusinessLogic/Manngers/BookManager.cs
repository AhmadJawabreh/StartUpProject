using BusinessLogic.IManagers;
using BusinessLogic.Mappers;
using Entities;
using Models;
using Repoistories;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace BusinessLogic
{
    public class BookManager : IBookManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookManager(IUnitOfWork unitOfWork) 
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<BookResource>> GetAllAsync()
        {
            try
            {
                IEnumerable<Book> Books = await _unitOfWork.Books.GetAll();
                return BookMapper.ToResources(Books);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        public async Task<BookResource> GetByIdAsync(long Id)
        {
            try
            {  
                Book book = await _unitOfWork.Books.GetById(Id);
                return BookMapper.ToResource(book);
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        public async Task<BookResource> InsertAsync(BookModel bookModel)
        {
            try
            {
                List<Author> authors = (List<Author>)  await _unitOfWork.Athuors.GetAll();
                authors = authors.Where(item => bookModel.AuthoIds.Contains((int)item.Id)).ToList();
                Book book = new Book() { Authors = authors};
                book = BookMapper.ToEntity(book, bookModel);
                await  _unitOfWork.Books.Insert(book);
                await  this._unitOfWork.Save();
                return BookMapper.ToResource(book); 
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }

        public async Task<BookResource> UpdateAsync(BookModel bookModel)
        {
            try
            {
                Book book =await  _unitOfWork.Books.GetById(bookModel.Id);
                book = BookMapper.ToEntity(book, bookModel);
                _unitOfWork.Books.Update(book);
                await this._unitOfWork.Save();
                return BookMapper.ToResource(book);

            }
            catch (Exception Error) 
            {
                throw Error;
            }
        }

        public async Task Delete(long Id)
        {
            try
            {
                await _unitOfWork.Books.Delete(Id);
                await this._unitOfWork.Save();
            }
            catch (Exception Error)
            {
                throw Error;
            }
        }
    }
}
