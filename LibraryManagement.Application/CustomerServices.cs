using System;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagement.Business.Dto;
using LibraryManagement.Business.Interfaces;
using LibraryManagement.Business.Models;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace LibraryManagement.Application
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;
        private readonly IBus _bus;
        private readonly ILogger<CustomerServices> _logger;
        private readonly IPublishEndpoint _publisher;

        public CustomerServices(ICustomerRepository repo, IMapper mapper, IBus bus, ILogger<CustomerServices> logger, IPublishEndpoint publisher)
        {
            _repo = repo;
            _mapper = mapper;
            _bus = bus;
            _logger = logger;
            _publisher = publisher;
        }

        public async Task CreateQueue(Customer data)
        {
            try
            {
                var customerDto = _mapper.Map<CustomerDto>(data);

                Uri uri = new Uri("rabbitmq://localhost/sendNewCustomerQueue");

                var endPoint = await _bus.GetSendEndpoint(uri);

                await endPoint.Send<Customer>(data);

                await _repo.Insert(data);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public async Task CreateExchange(Customer data)
        {
            try
            {
                await _repo.Insert(data);

                await _publisher.Publish<Customer>(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}