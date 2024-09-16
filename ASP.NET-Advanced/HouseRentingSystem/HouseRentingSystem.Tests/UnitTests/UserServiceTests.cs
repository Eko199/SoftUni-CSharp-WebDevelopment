namespace HouseRentingSystem.Tests.UnitTests;

using Core.Services;
using Core.Services.Contracts.ApplicationUser;
using Infrastructure.Models;

public class UserServiceTests : UnitTestsBase
{
    private IApplicationUserService userService;

    [OneTimeSetUp]
    public void SetUp() => userService = new ApplicationUserService(repo);

    [Test]
    public async Task UserHasRents_ShouldReturnTrueWithValidData()
    {
        Assert.That(await userService.UserHasRentsAsync(Renter.Id));
    }

    [Test]
    public async Task GetFullName_ShouldReturnCorrectResult()
    {
        string? renterFullName = await userService.GetFullNameAsync(Renter.Id);

        Assert.That(renterFullName, Is.Not.Null);
        Assert.That(renterFullName, Is.EqualTo($"{Renter.FirstName} {Renter.LastName}"));
    }

    [Test]
    public async Task GetAll_ShouldReturnCorrectUsersAndAgents()
    {
        var users = (await userService.GetAllAsync()).ToList();

        int usersCount = repo.All<ApplicationUser>().Count();

        int agentsCount = repo.All<Agent>().Count();
        var agents = users.Where(u => u.IsAgent).ToList();

        var agent = agents.FirstOrDefault(a => a.Email == Agent.User.Email);

        Assert.That(users, Has.Count.EqualTo(usersCount));
        Assert.That(agents, Has.Count.EqualTo(agentsCount));
        Assert.That(agent, Is.Not.Null);
        Assert.That(agent.PhoneNumber, Is.EqualTo(Agent.PhoneNumber));
    }
}