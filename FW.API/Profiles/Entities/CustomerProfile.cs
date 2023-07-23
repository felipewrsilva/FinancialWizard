using AutoMapper;
using FW.API.ViewModels.RequestModels;
using FW.API.ViewModels.ResponseModels;
using FW.Domain.Entities;

namespace FW.API.Profiles.Entities
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerResponse>();
            CreateMap<CustomerRequest, Customer>();
        }
    }
}
