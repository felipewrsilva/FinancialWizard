using AutoMapper;
using FW.Domain.ValueObject;

namespace FW.API.Profiles.ValueObjects;

public class PhoneProfile : Profile
{
    public PhoneProfile()
    {
        CreateMap<Phone, string>()
            .ConvertUsing(id => id.Value);
        CreateMap<string, Phone>()
            .ConvertUsing(value => new Phone(value));
    }
}
