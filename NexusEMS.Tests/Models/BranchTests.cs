using FluentAssertions;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class BranchTests
{
    private readonly TestDataBuilder _testData;

    public BranchTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void Branch_ShouldHaveFiveBranches()
    {
        _testData.Branches.Should().HaveCount(5);
    }

    [Fact]
    public void Branch_ShouldHaveManager()
    {
        foreach (var branch in _testData.Branches)
        {
            branch.ManagerUserId.Should().NotBeNull();
            var manager = _testData.Users.FirstOrDefault(u => u.Id == branch.ManagerUserId);
            manager.Should().NotBeNull();
            manager!.Role.Should().Be(Shared.Enums.UserRole.BranchManager);
        }
    }

    [Fact]
    public void Branch_ShouldHaveDepartments()
    {
        foreach (var branch in _testData.Branches)
        {
            var departments = _testData.Departments.Where(d => d.BranchId == branch.Id).ToList();
            departments.Should().HaveCount(10);
        }
    }

    [Fact]
    public void Branch_ShouldHaveEmployees()
    {
        foreach (var branch in _testData.Branches)
        {
            var employees = _testData.Employees.Where(e => e.BranchId == branch.Id).ToList();
            employees.Should().NotBeEmpty();
        }
    }

    [Fact]
    public void Branch_ShouldHaveUsers()
    {
        foreach (var branch in _testData.Branches)
        {
            var users = _testData.Users.Where(u => u.BranchId == branch.Id).ToList();
            users.Should().NotBeEmpty();
        }
    }

    [Fact]
    public void Branch_ShouldHaveComplaintCases()
    {
        var branch = _testData.Branches.First();
        var complaints = _testData.ComplaintCases.Where(c => c.BranchId == branch.Id).ToList();
        
        complaints.Should().NotBeEmpty();
    }

    [Fact]
    public void Branch_ShouldHaveAuditLogs()
    {
        var branch = _testData.Branches.First();
        var auditLogs = _testData.AuditLogs.Where(a => a.BranchId == branch.Id).ToList();
        
        auditLogs.Should().NotBeEmpty();
    }

    [Fact]
    public void Branch_ShouldHaveRequiredFields()
    {
        foreach (var branch in _testData.Branches)
        {
            branch.Name.Should().NotBeEmpty();
            branch.Code.Should().NotBeEmpty();
            branch.Location.Should().NotBeEmpty();
        }
    }
}
