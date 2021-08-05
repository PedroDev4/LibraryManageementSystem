using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagement.Business.Interfaces;
using LibraryManagement.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Infrastructure.Repository
{
    public class LibraryManagementRepository<T> : ILibraryManagementRepository<T> where T : Entity
    {
        protected readonly LibraryManagementContext _context;
        protected readonly ILogger<LibraryManagementRepository<T>> _logger;

        public LibraryManagementRepository(LibraryManagementContext context, ILogger<LibraryManagementRepository<T>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Delete(int id)
        {
            try
            {
                var entity = await GetById(id);

                _context.Set<T>().Remove(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
            }
        }

        public void Dispose()
        {
            try
            {
                _context?.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAll(T entity)
        {
            IEnumerable<T> entities = null;

            try
            {
                entities = await _context
                    .Set<T>()
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
            }
            return entities;
        }

        public async Task<T> GetById(int id)
        {
            T entity = null;

            try
            {
                entity = await _context
                    .Set<T>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
            }

            return entity;
        }


        public async Task<bool> Insert(T entity)
        {
            bool isExpection = false;
            try
            {
                _context.Set<T>().Add(entity);

                await _context.SaveChangesAsync();
                
                
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
                isExpection = true;
            }
            return isExpection;

        }

        public async Task Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
            }
        }
    }
}
