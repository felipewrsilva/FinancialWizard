using AutoMapper;
using FW.Domain.StrongTyped;

namespace FW.API.Profiles.ValueObjects;

public class CustomerIdProfile : Profile
{
    public CustomerIdProfile()
    {
        CreateMap<CustomerId, Guid>()
            .ConvertUsing(id => id.Value);
        CreateMap<Guid, CustomerId>()
            .ConvertUsing(value => new CustomerId(value));
    }
}
