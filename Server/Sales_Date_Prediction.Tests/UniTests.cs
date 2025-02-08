using Moq;
using Xunit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales_Date_Prediction.API.Controllers;
using Sales_Date_Prediction.Domain.Entities;
using Sales_Date_Prediction.Domain.Shared;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Sales_Date_Prediction.AppWeb.Features.Customers.Queries.GetCustomers;
using Sales_Date_Prediction.AppWeb.Features.Employees.Queries.GetAllEmployees;
using Sales_Date_Prediction.AppWeb.Features.Order.Commands;
using Sales_Date_Prediction.AppWeb.Features.Order.Queries.GetOrders;
using Sales_Date_Prediction.AppWeb.Features.Order.Queries.GetOrdersByCustomer;
using Sales_Date_Prediction.Domain.DTOs;
using Sales_Date_Prediction.AppWeb.Features.Products.Queries.GetAllProducts;
using Sales_Date_Prediction.AppWeb.Features.SalesDatePrediction.Queries.GetAllSalesDatePrediction;
using Sales_Date_Prediction.AppWeb.Features.Shippers.Queries.GetAllShippers;

public class UniTests
{

    private readonly Mock<IMediator> _mediatorMock;
    private readonly OrdersController _controller;

    public UniTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new OrdersController(_mediatorMock.Object);
    }
    [Fact]
    public async Task GetCustomers_ShouldReturnResponse()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var controller = new CustomersController(mediatorMock.Object);

        mediatorMock
            .Setup(m => m.Send(It.IsAny<GetCustomersQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BaseResponse<IEnumerable<Customer>>());

        // Act
        var result = await controller.GetCustomers();

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetEmployee_ShouldReturnResponse()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var controller = new EmployeesController(mediatorMock.Object);

        mediatorMock
            .Setup(m => m.Send(It.IsAny<GetAllEmployeesQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BaseResponse<IEnumerable<Employee>>());

        // Act
        var result = await controller.GetCustomers();

        // Assert
        Assert.NotNull(result);
    }

 

    [Fact]
    public async Task GetOrders_ShouldReturnResponse()
    {
        // Arrange
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetOrdersQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BaseResponse<IEnumerable<Orders>>());

        // Act
        var result = await _controller.GetOrders();

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetOrdersByCustomer_ShouldReturnResponse()
    {
        // Arrange
        _mediatorMock
            .Setup(m => m.Send(It.IsAny<GetOrdersByCustomerQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BaseResponse<IEnumerable<OrdersByCustomerDTO>>());

        // Act
        var result = await _controller.GetOrdersByCustomer(1);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task PostNewOrder_ShouldReturnResponse()
    {
        // Arrange
        var command = new CreateOrderWithProductCommand();
        _mediatorMock
            .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BaseResponse<bool>());

        // Act
        var result = await _controller.PostNewOrder(command);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetProduct_ShouldReturnResponse()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var controller = new ProductsController(mediatorMock.Object);

        mediatorMock
            .Setup(m => m.Send(It.IsAny<GetAllProductsQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BaseResponse<IEnumerable<Product>>());

        // Act
        var result = await controller.GetProduct();

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetSalesDatePrediction_ShouldReturnResponse()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var controller = new SalesDatePredictionController(mediatorMock.Object);

        mediatorMock
            .Setup(m => m.Send(It.IsAny<GetAllSalesDatePredictionQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BaseResponse<IEnumerable<SalesDatePredictionDTO>>());

        // Act
        var result = await controller.GetSalesDatePrediction();

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetShipper_ShouldReturnResponse()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var controller = new ShippersController(mediatorMock.Object);

        mediatorMock
            .Setup(m => m.Send(It.IsAny<GetAllShippersQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new BaseResponse<IEnumerable<Shipper>>());

        // Act
        var result = await controller.GetShipper();

        // Assert
        Assert.NotNull(result);
    }
}
