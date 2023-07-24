using AutoMapper;
using FW.Domain.ValueObject;

namespace FW.API.Profiles.ValueObjects;

public class EmailProfile : Profile
{
    public EmailProfile()
    {
        CreateMap<Email, string>()
            .ConvertUsing(id => id.Value);
        CreateMap<string, Email>()
            .ConvertUsing(value => new Email(value));
    }
}
