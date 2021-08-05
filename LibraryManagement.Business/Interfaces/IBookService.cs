using LibraryManagement.Business.Models;
using LibraryManagement.Business.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Business.Interfaces
{
    public interface IBookService
    {

        Task CreateQueue(Book book);
        Task<bool> CreateBook(BookDTO bookDTO);

    }
}
