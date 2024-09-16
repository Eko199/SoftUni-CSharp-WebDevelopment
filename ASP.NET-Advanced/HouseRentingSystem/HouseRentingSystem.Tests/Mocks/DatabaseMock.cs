namespace HouseRentingSystem.Tests.Mocks;

using Infrastructure;
using Microsoft.EntityFrameworkCore;

public static class DatabaseMock
{
    public static HouseRentingDbContext Instance
    {
        get
        {
            var dbContextOptions = new DbContextOptionsBuilder<HouseRentingDbContext>()
                .UseInMemoryDatabase("HouseRentingInMemoryDb" + DateTime.Now.Ticks)
                .Options;

            return new HouseRentingDbContext(dbContextOptions, false);
        }
    }
}