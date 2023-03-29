namespace ProductShop;

using AutoMapper;

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
    }
}