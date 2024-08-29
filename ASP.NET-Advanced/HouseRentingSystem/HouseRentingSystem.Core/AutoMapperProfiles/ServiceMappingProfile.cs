namespace HouseRentingSystem.Core.AutoMapperProfiles;

using AutoMapper;
using Models.House;
using HouseRentingSystem.Infrastructure.Models;

public class ServiceMappingProfile : Profile
{
    public ServiceMappingProfile()
    {
        CreateMap<House, HouseServiceModel>()
            .ForMember(h => h.IsRented, 
                cfg => cfg.MapFrom(h => h.RenterId != null));

        CreateMap<House, HouseIndexServiceModel>();
        CreateMap<Category, HouseCategoryServiceModel>();
    }
}