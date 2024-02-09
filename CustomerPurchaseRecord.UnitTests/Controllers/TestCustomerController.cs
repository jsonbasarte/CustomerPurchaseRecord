using CustomerPurchaseRecord.DataService.Repositories.Interface;
using CustomerPurchaseRecord.Entities.Dtos.Responses;
using CustomerPurchaseRecord.UnitTests.Fixtures;
using Moq;
using AutoMapper;
using CustomerPurchaseRecord.Entities.DbSet;
using CustomerPurchaseRecord.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using CustomerPurchaseRecord.DataService.Repositories;
using CustomerPurchaseRecord.DataService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Castle.Core.Resource;
using System.Net;
using CustomerPurchaseRecord.Entities.Dtos.Requests;


namespace CustomerPurchaseRecord.UnitTests.Controllers;

public class TestCustomerController
{

    [Fact]
    public async Task InvokeController_GeAllCustomer()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        mockUnitOfWork.Setup(x => x.Customers.GetAll());

        var mapperMock = new Mock<IMapper>();

        var customerController = new CustomerController(mockUnitOfWork.Object, mapperMock.Object);


        // Act
        var result = (OkObjectResult)await customerController.GetAll();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        mockUnitOfWork.Verify(x => x.Customers.GetAll(), Times.Once);
        var model = Assert.IsAssignableFrom<IEnumerable<GetCustomerDto>>(result.Value);
        Assert.Equal(2, model.Count);
    }

    [Fact]
    public async Task InvokeController_SearchCustomerByName()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        mockUnitOfWork.Setup(x => x.Customers.SearchByCustomerName("test"));

        var mapperMock = new Mock<IMapper>();

        var customerController = new CustomerController(mockUnitOfWork.Object, mapperMock.Object);

        // Act
        var result = (OkObjectResult)await customerController.SearchCustomerByName("test");

        // Assert
        result.Should().BeOfType<OkObjectResult>();

        mockUnitOfWork.Verify(x => x.Customers.SearchByCustomerName("test"), Times.Once);
    }

    [Fact]
    public async Task InvokeController_CreateCustomer()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        mockUnitOfWork.Setup(x => x.Customers.Add(new Customer { Address = "wew", FirstName = "we", LastName = "s" }));

        var mapperMock = new Mock<IMapper>();

        var param = new CreateCustomerDto { Address = "wew", Firstname = "we", Lastname = "s" };

        var customerController = new CustomerController(mockUnitOfWork.Object, mapperMock.Object);

        // Act
        var result = (OkObjectResult)await customerController.Create(param);

        // Assert
        result.Should().BeOfType<OkObjectResult>();
    }


}
