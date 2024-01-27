using AutoMapper;
using CustomerPurchaseRecord.Entities.DbSet;
using CustomerPurchaseRecord.Entities.Dtos.Responses;

namespace CustomerPurchaseRecord.API.MappingProfiles;

public class DomainToResponse : Profile
{
    public DomainToResponse()
    {
        CreateMap<Customer, GetCustomerDto>()
            .ForMember(
                destination => destination.CustomerId,
                option => option.MapFrom(src => src.Id))
            .ForMember(
                destination => destination.TransactionDetails,
                option => option.MapFrom(src => src.TransactionDetails));

        CreateMap<TransactionDetails, GetTransactionDetailDto>();
    }
}
