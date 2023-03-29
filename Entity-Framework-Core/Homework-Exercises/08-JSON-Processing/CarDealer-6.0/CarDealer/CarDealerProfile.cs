namespace CarDealer;

using AutoMapper;

using DTOs.Import;
using Models;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        CreateMap<ImportSupplierDTO, Supplier>();
        CreateMap<ImportPartDTO, Part>();
        CreateMap<ImportCustomerDTO, Customer>();
        CreateMap<ImportSaleDTO, Sale>();
    }
}