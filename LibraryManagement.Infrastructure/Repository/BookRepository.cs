using LibraryManagement.Business.Models;
using LibraryManagement.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Infrastructure.Repository
{
    class BookRepository : LibraryManagementRepository<Book>, IBookRepository
    {

        public BookRepository(LibraryManagementContext context, ILogger<LibraryManagementRepository<Book>> logger) : base(context, logger) {
            
        }

        public Task FindByTheme(string theme)
        {
            throw new NotImplementedException();
        }
    }
}
