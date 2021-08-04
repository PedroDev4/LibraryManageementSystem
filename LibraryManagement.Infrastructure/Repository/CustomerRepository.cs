using LibraryManagement.Business.Interfaces;
using LibraryManagement.Business.Models;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Infrastructure.Repository
{
    public class CustomerRepository : LibraryManagementRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LibraryManagementContext context, ILogger<LibraryManagementRepository<Customer>> logger)
         : base(context, logger) { }

    }
}