using AutoMapper;
using CustomersApp.Common.Models;
using CustomersApp.Database.Entities;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        
        CreateMap<Customer, CustomerDto>()
            .ForPath(m => m.Address.City, c => c.MapFrom(s => s.Address.City))
            .ForPath(m => m.Address.Street, c => c.MapFrom(s => s.Address.Street))
            .ForPath(m => m.Address.Country, c => c.MapFrom(s => s.Address.Country))
            .ForPath(m => m.Address.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

        CreateMap<CustomerDto, Customer>()
            .ForMember(r => r.Address, c => c.MapFrom(dto => new Address()
            {
                City = dto.Address.City,
                PostalCode = dto.Address.PostalCode,
                Street = dto.Address.Street,
                Country = dto.Address.Country
            }));

        CreateMap<CustomerDto, Customer>()
            .ForMember(m => m.Id, c => c.Ignore())
            .ForMember(m => m.Address, c => c.MapFrom(dto => new Address()
            {
                City = dto.Address.City,
                PostalCode = dto.Address.PostalCode,
                Street = dto.Address.Street,
                Country = dto.Address.Country
            }));





    }
}