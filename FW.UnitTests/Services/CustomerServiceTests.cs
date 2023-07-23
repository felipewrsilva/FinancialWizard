using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using FW.API.ViewModels.ResponseModels;
using FW.Application.Services;
using FW.Domain.Entities;
using FW.Domain.StrongTyped;
using FW.Infrastructure.Interfaces;

namespace FW.UnitTests.Services;

public class CustomerServiceTests
{
    [TestFixture]
    public class UserServiceTests
    {
        private const string CustomerName = "customerName";
        private const string CustomerEmail = "customerEmail";

        private ICustomerRepository _customerRepositoryMock;
        private IMapper _mapperMock;
        private CustomerService _customerService;

        [SetUp]
        public void Setup()
        {
            _customerRepositoryMock = Mock.Of<ICustomerRepository>();
            _mapperMock = Mock.Of<IMapper>();
            _customerService = new CustomerService(_customerRepositoryMock);
        }

        [Test]
        public async Task GetByIdAsync_WithExistingCustomer_ShouldReturnCustomerResponse()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            CustomerId customerId = new(id);
            Customer customer = Customer.Create(new CustomerId(id), CustomerName, new Email(CustomerEmail));
            CustomerResponse customerResponse = new(id, CustomerName, CustomerEmail);

            Mock.Get(_customerRepositoryMock).Setup(repo => repo.GetByIdAsync(customerId)).ReturnsAsync(customer);
            Mock.Get(_mapperMock).Setup(mapper => mapper.Map<CustomerResponse>(customer)).Returns(customerResponse);

            // Act
            var result = await _customerService.GetByIdAsync(customerId);

            // Assert
            result.Should().BeEquivalentTo(customer);
        }
    }
}
