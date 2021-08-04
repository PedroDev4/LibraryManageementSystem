using AutoMapper;
using LibraryManagement.Business.Dto;
using LibraryManagement.Business.Models;

namespace LibraryManagement.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}