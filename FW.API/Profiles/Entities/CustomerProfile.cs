using AutoMapper;
using FW.API.ViewModels.RequestModels;
using FW.API.ViewModels.ResponseModels;
using FW.Domain.Entities;
using FW.Domain.StrongTyped;
using FW.Domain.ValueObject;

namespace FW.API.Profiles.Entities;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerResponse>();
        CreateMap<CustomerRequest, Customer>()
            .ConstructUsing((src, context) => Customer.Create(new CustomerId(src.Id), src.Name, new Email(src.Email)));
    }
}
