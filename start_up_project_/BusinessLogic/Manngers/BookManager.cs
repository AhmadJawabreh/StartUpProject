using BusinessLogic.Mappers;
using Contract.Exceptions;
using Entities;
using Filters;
using Models;
using Repoistories;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic
{

    public interface IBookManager
    {
        List<BookResource> GetAll(BookFilter BookFilter, int PageNumber, int PageSize);
        Task<BookResource> GetByIdAsync(long Id);
        Task<BookResource> InsertAsync(BookModel bookModel);
        Task<BookResource> UpdateAsync(BookModel bookModel);
        Task Delete(long Id);
    }

    public class BookManager : IBookManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookManager(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public List<BookResource> GetAll(BookFilter bookFilter, int PageNumber, int PageSize)
        {
            if (PageNumber <= 0)
            {
                throw new PaginationInvalidArgumentException("Page Number must be more than 0.");
            }

            if (PageSize <= 10)
            {
                throw new PaginationInvalidArgumentException("Page Size must be more than 10.");
            }

            
            Func<Book, bool> expresion = item => item.Name.Contains(bookFilter?.Name);
            List<Book> books = _unitOfWork.Books.GetAll(expresion, PageNumber, PageSize);
            return BookMapper.ToResources(books);
        }

        public async Task<BookResource> GetByIdAsync(long Id)
        {
            Book book = await _unitOfWork.Books.GetById(Id);
            if (book == null)
            {
                 throw new ItemNotFoundException("This Book does not found");
            }
            return BookMapper.ToResource(book);
        }

        public async Task<BookResource> InsertAsync(BookModel bookModel)
        {

            Book _book = _unitOfWork.Books.FirstOrDefalut(item => item.Name == bookModel.Name);
            if (_book == null)
            {
                // To DO:
                List<Author> authors = _unitOfWork.Athuors.GetAll(null, 1, 40);

                if (bookModel.AuthoIds != null)
                    authors = authors.Where(item => bookModel.AuthoIds.Contains((int)item.Id)).ToList();
                Book book = new Book() { Authors = authors };
                book = BookMapper.ToEntity(book, bookModel);
                await _unitOfWork.Books.Create(book);
                await this._unitOfWork.Save();
                return BookMapper.ToResource(book);
            }
            else
            {
                throw new DubplicatedBookNameException("Book Name already exist");
            }
        }

        public async Task<BookResource> UpdateAsync(BookModel bookModel)
        {
            Book book = await _unitOfWork.Books.GetById(bookModel.Id);
            if (book == null)
            {
                throw new ItemNotFoundException("This Book does not found");
            }
            book = BookMapper.ToEntity(book, bookModel);
            _unitOfWork.Books.Update(book);
            await this._unitOfWork.Save();
            return BookMapper.ToResource(book);
        }

        public async Task Delete(long Id)
        {
            Book book = await _unitOfWork.Books.GetById(Id);
            if (book == null)
            {
                throw new ItemNotFoundException("This Book does not found");
            }
            _unitOfWork.Books.Delete(book);
            await this._unitOfWork.Save();
        }
    }
}

   
