using AutoMapper;
using CustomerPurchaseRecord.Entities.DbSet;
using CustomerPurchaseRecord.Entities.Dtos.Requests;

namespace CustomerPurchaseRecord.API.MappingProfiles;

public class RequestToDomain : Profile
{
    public RequestToDomain()
    {
        CreateMap<CreateCustomerDto, Customer>()
            .ForMember(
                des => des.FirstName,
                option => option.MapFrom(src => src.Firstname))
            .ForMember(
                des => des.LastName,
                option => option.MapFrom(src => src.Lastname));
    }
}
