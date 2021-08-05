using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Business.Models;

namespace LibraryManagement.Business.Interfaces
{
    public interface IBookRepository : ILibraryManagementRepository<Book> 
    {

        Task FindByTheme(string theme);

    }
}
