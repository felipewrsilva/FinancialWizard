using AutoMapper;
using FW.API.ViewModels.RequestModels;
using FW.API.ViewModels.ResponseModels;
using FW.Domain.Entities;
using FW.Domain.ValueObject;

namespace FW.API.Profiles.Entities;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerResponse>();
        CreateMap<CustomerCreateRequest, Customer>()
            .ConstructUsing((src, context) => Customer.Create(src.Name, new Email(src.Email)));
        CreateMap<CustomerUpdateRequest, Customer>()
            .ConstructUsing((src, context) => Customer.Create(src.Id, src.Name, new Email(src.Email), new Phone(src.Phone)));
    }
}
