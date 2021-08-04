using LibraryManagement.Business.Interfaces;
using LibraryManagement.Business.Models;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Infrastructure.Repository
{
    public class AddressRepository : LibraryManagementRepository<Address>, IAddressRepository
    {
        public AddressRepository(LibraryManagementContext context, ILogger<LibraryManagementRepository<Address>> logger)
         : base(context, logger) { }

    }
}