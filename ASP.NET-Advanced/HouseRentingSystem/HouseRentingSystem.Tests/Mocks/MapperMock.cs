namespace HouseRentingSystem.Tests.Mocks;

using AutoMapper;
using Core.AutoMapperProfiles;

public static class MapperMock
{
    public static IMapper Instance
    {
        get
        {
            var mapperConfiguration = new MapperConfiguration(config
                => config.AddProfile<ServiceMappingProfile>());

            return new Mapper(mapperConfiguration);
        }
    }
}