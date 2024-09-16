namespace HouseRentingSystem.Tests.IntegrationsTests;

using Controllers;
using Core.Services.Contracts.House;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class HomeControllerTests
{
    private HomeController homeController;

    [OneTimeSetUp]
    public void SetUp() => homeController = new HomeController(new Mock<IHouseService>().Object);

    [Test]
    public void Error_ShouldReturnCorrectView()
    {
        const int statusCode = 500;

        IActionResult result = homeController.Error(statusCode);

        Assert.That(result as ViewResult, Is.Not.Null);
    }

    [OneTimeTearDown]
    public void TearDown() => homeController.Dispose();
}