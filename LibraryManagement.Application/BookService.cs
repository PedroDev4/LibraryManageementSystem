using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Business.Dto;
using LibraryManagement.Business.Interfaces;
using LibraryManagement.Business.Models;
using AutoMapper;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        public readonly IMapper _mapper;
        private readonly IBus _bus;
        private readonly ILogger<BookService> _logger;
        private readonly IPublishEndpoint _publisher;

        public BookService(IBookRepository repository, IMapper mapper, IBus bus, ILogger<BookService> logger, IPublishEndpoint publisher) {

            _repository = repository;
            _mapper = mapper;
            _bus = bus;
            _logger = logger;
            _publisher = publisher;

        }

        public async Task<bool> CreateBook(BookDTO bookDTO) {

            bool result = false;

            try {

                var book = _mapper.Map<Book>(bookDTO);

                var bookExists = await _repository.GetById(book.Id);

                if (bookExists != null) {

                     result = true;
                     throw new Exception("Book already exists");         
                }

                result = await _repository.Insert(book);

                bookDTO = _mapper.Map<BookDTO>(book);

                await _publisher.Publish<Customer>(bookDTO);

            } catch (Exception exc) {
            
                _logger.LogInformation(exc.Message);
                result = true;          
            }

            return result;
        }

        public Task CreateQueue(Book book) {

            throw new NotImplementedException();
        }


    }
}
