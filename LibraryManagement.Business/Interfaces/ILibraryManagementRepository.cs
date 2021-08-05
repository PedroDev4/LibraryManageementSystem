using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagement.Business.Models;

namespace LibraryManagement.Business.Interfaces
{
    public interface ILibraryManagementRepository<T> : IDisposable where T : Entity
    {
                
        Task<bool> Insert(T entity);
        Task Delete(int id);
        Task Update(T entity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll(T entity);
    }
}