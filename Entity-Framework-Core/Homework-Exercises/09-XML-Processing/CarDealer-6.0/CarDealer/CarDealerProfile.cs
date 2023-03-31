namespace CarDealer;

using System.Globalization;

using AutoMapper;

using DTOs.Export;
using DTOs.Import;
using Models;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        CreateMap<ImportSupplierDTO, Supplier>();
        CreateMap<ImportPartDTO, Part>();

        CreateMap<ImportCustomerDTO, Customer>()
            .ForMember(c => c.BirthDate, opt
                => opt.MapFrom(dto => DateTime.Parse(dto.BirthDate, CultureInfo.InvariantCulture)));

        CreateMap<ImportSaleDTO, Sale>();
        CreateMap<Car, ExportCarWithDistanceDTO>();
        CreateMap<Car, ExportCarFromMakeDTO>();

        CreateMap<Supplier, ExportLocalSupplierDTO>()
            .ForMember(dto => dto.PartsCount, opt
                => opt.MapFrom(s => s.Parts.Count));

        CreateMap<Part, ExportCarPartDTO>();

        CreateMap<Car, ExportCarWithPartsDTO>()
            .ForMember(dto => dto.Parts, opt
                => opt.MapFrom(c => c.PartsCars
                    .Select(pc => pc.Part)
                    .OrderByDescending(p => p.Price)));

        CreateMap<Car, ExportSaleCarDTO>();
    }
}