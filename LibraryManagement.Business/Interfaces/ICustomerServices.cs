using System.Threading.Tasks;
using LibraryManagement.Business.Models;

namespace LibraryManagement.Business.Interfaces
{
    public interface ICustomerServices
    {
        Task CreateQueue(Customer data);
        Task<bool> CreateExchange(Customer data);

    }
}