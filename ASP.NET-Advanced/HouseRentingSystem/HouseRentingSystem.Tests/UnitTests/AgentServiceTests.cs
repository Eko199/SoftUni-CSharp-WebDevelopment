namespace HouseRentingSystem.Tests.UnitTests;

using Core.Models.Agent;
using Core.Services;
using Core.Services.Contracts.Agent;
using Infrastructure.Models;

[TestFixture]
public class AgentServiceTests : UnitTestsBase
{
    private IAgentService agentService;

    [OneTimeSetUp]
    public void SetUp() => agentService = new AgentService(repo);

    [Test]
    public async Task GetAgentId_ShouldReturnCorrectUserIdAsync()
    {
        var agentId = await agentService.GetAgentIdAsync(Agent.UserId);
        Assert.That(agentId, Is.EqualTo(Agent.Id));
    }

    [Test]
    public async Task ExistsById_ShouldReturnTrueWithValidIdAsync()
    {
        Assert.That(await agentService.ExistsByIdAsync(Agent.UserId));
    }

    [Test]
    public async Task AgentWithPhoneNumberExists_ShouldReturnTrueWithValidData()
    {
        Assert.That(await agentService.AgentWithPhoneNumberExistsAsync(Agent.PhoneNumber));
    }

    [Test]
    public async Task CreateAgent_ShouldWorkCorrectly()
    {
        int agentsCountBefore = repo.All<Agent>().Count();

        await agentService.CreateAsync(Agent.UserId + "1", new BecomeAgentFormModel { PhoneNumber = Agent.PhoneNumber });

        int agentsCountAfter = repo.All<Agent>().Count();
        int? newAgentId = await agentService.GetAgentIdAsync(Agent.UserId + "1");
        Agent? newAgent = await repo.FindAsync<Agent>(newAgentId);

        Assert.That(agentsCountAfter, Is.EqualTo(agentsCountBefore + 1));
        Assert.That(newAgentId, Is.Not.Null);
        Assert.That(newAgent, Is.Not.Null);
        Assert.That(newAgent.UserId, Is.EqualTo(Agent.UserId + "1"));
        Assert.That(newAgent.PhoneNumber, Is.EqualTo(Agent.PhoneNumber));
    }
}