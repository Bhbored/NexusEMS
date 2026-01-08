using FluentAssertions;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class AddressTests
{
    [Fact]
    public void Address_ShouldBeUsedInEmployees()
    {
        var testData = new TestDataBuilder().Build();
        
        var employeesWithAddress = testData.Employees.Where(e => e.Address != null).ToList();
        employeesWithAddress.Should().NotBeEmpty();
    }

    [Fact]
    public void Address_ShouldHaveRequiredFields()
    {
        var address = new Address
        {
            Street = "123 Main St",
            City = "New York",
            State = "NY",
            PostalCode = "10001",
            Country = "USA"
        };

        address.Street.Should().NotBeEmpty();
        address.City.Should().NotBeEmpty();
        address.State.Should().NotBeEmpty();
        address.PostalCode.Should().NotBeEmpty();
        address.Country.Should().NotBeEmpty();
    }
}
