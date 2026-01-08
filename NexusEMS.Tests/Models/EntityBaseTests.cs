using FluentAssertions;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class EntityBaseTests
{
    private readonly TestDataBuilder _testData;

    public EntityBaseTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void EntityBase_AllEntities_ShouldHaveId()
    {
        foreach (var user in _testData.Users)
        {
            user.Id.Should().NotBeEmpty();
        }

        foreach (var employee in _testData.Employees)
        {
            employee.Id.Should().NotBeEmpty();
        }

        foreach (var branch in _testData.Branches)
        {
            branch.Id.Should().NotBeEmpty();
        }
    }

    [Fact]
    public void EntityBase_AllEntities_ShouldHaveCreatedAt()
    {
        foreach (var user in _testData.Users)
        {
            user.CreatedAt.Should().NotBe(default(DateTime));
        }

        foreach (var employee in _testData.Employees)
        {
            employee.CreatedAt.Should().NotBe(default(DateTime));
        }
    }

    [Fact]
    public void EntityBase_AllEntities_ShouldHaveUniqueIds()
    {
        var userIds = _testData.Users.Select(u => u.Id).ToList();
        userIds.Should().OnlyHaveUniqueItems();

        var employeeIds = _testData.Employees.Select(e => e.Id).ToList();
        employeeIds.Should().OnlyHaveUniqueItems();

        var branchIds = _testData.Branches.Select(b => b.Id).ToList();
        branchIds.Should().OnlyHaveUniqueItems();
    }
}
