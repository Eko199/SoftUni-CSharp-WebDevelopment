namespace ProductShop;

using AutoMapper;

using DTOs.Export;
using DTOs.Import;
using Models;

public class ProductShopProfile : Profile
{
    public ProductShopProfile()
    {
        CreateMap<ImportUserDTO, User>();
        CreateMap<ImportProductDTO, Product>();
        CreateMap<ImportCategoryDTO, Category>();
        CreateMap<ImportCategoryProductDTO, CategoryProduct>();

        CreateMap<Product, ExportProductInRangeDTO>()
            .ForMember(dto => dto.Buyer, opt
                => opt.MapFrom(p => 
                    $"{p.Buyer.FirstName} {p.Buyer.LastName}"));

        CreateMap<Product, ExportProductDTO>();

        CreateMap<User, ExportUserSoldProductsDTO>()
            .ForMember(dto => dto.SoldProducts, opt
                => opt.MapFrom(u => u.ProductsSold.ToArray()));
    }
}