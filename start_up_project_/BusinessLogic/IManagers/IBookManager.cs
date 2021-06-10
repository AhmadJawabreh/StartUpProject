﻿using Filters;
using Models;
using Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.IManagers
{
    public interface IBookManager
    {
         List<BookResource> GetAll(BookFilter BookFilter, int PageNumber, int PageSize);
         Task<BookResource> GetByIdAsync(long Id);
         Task<BookResource> InsertAsync(BookModel bookModel);
         Task<BookResource> UpdateAsync(BookModel bookModel);
         Task Delete(long Id);
    }
}
