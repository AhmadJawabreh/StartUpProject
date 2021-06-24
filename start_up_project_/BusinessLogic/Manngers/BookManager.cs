using BusinessLogic.Mappers;
using Contract.Exceptions;
using Contract.BookExtraData;
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

        Task<BookResource> GetBookWithAuthorsAndPublisher(BookExtraData bookExtraData,  long Id);

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
                throw new InvalidArgumentException("Page Number must be more than 0.");
            }

            if (PageSize <= 10)
            {
                throw new InvalidArgumentException("Page Size must be more than 10.");
            }


            Func<Book, bool> expresion = bookFilter?.Name == null ? item => true : item => item.Name.Contains(bookFilter?.Name);
            List<Book> books = _unitOfWork.Books.GetAll(expresion, PageNumber, PageSize);
            return BookMapper.ToResources(books);
        }

        public async Task<BookResource> GetByIdAsync(long Id)
        {
            Book book = await _unitOfWork.Books.GetById(Id);
            if (book == null)
            {
                throw new NotFoundException("This Book does not found");
            }
            return BookMapper.ToResource(book);
        }

        public async Task<BookResource> InsertAsync(BookModel bookModel)
        {

            Book _book = _unitOfWork.Books.FirstOrDefalut(item => item.Name == bookModel?.Name);
            if (_book != null)
                throw new DubplicateDataException("Book Name already exist");


            Publisher publisher = _unitOfWork.Publishers.FirstOrDefalut(item => item.Id == bookModel?.PublisherId);
            if (publisher == null)
                throw new NotFoundException("Publisher does not exist ");

            // To DO:
            List<Author> authors = _unitOfWork.Athuors.GetAll(item => true, 1, 40);

            if (bookModel.AuthoIds != null) 
            {
                authors = authors.Where(item => bookModel.AuthoIds.Contains((int)item.Id)).ToList();
            }
            Book book = new Book() { Authors = authors };
            book = BookMapper.ToEntity(book, bookModel);
            await _unitOfWork.Books.Create(book);
            await this._unitOfWork.Save();
            return BookMapper.ToResource(book);
        }

        public async Task<BookResource> UpdateAsync(BookModel bookModel)
        {
            Book book = await _unitOfWork.Books.GetById(bookModel.Id);
            if (book == null)
                throw new NotFoundException("This Book does not found");


            Publisher publisher = _unitOfWork.Publishers.FirstOrDefalut(item => item.Id == bookModel?.PublisherId);
            if (publisher == null)
                throw new NotFoundException("Publisher does not exist ");

            List<Author> authors = _unitOfWork.Athuors.GetAll(item => true, 1, 40);
            if (bookModel.AuthoIds != null)
                book.Authors = authors.Where(item => bookModel.AuthoIds.Contains((int)item.Id)).ToList();
            

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
                throw new NotFoundException("This Book does not found");
            }
            _unitOfWork.Books.Delete(book);
            await this._unitOfWork.Save();
        }

        public async Task<BookResource> GetBookWithAuthorsAndPublisher(BookExtraData bookExtraData, long Id)
        {
            Book book = await _unitOfWork.Books.GetBookWithAuthorsAndPublisher(bookExtraData.Authors, bookExtraData.Publisher, Id);
            if (book == null)
            {
                throw new NotFoundException("This Book does not found");
            }
            return BookMapper.ToResource(book); ;
        }
    }
}
