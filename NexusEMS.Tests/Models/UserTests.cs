using FluentAssertions;
using NexusEMS.Shared.Enums;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class UserTests
{
    private readonly TestDataBuilder _testData;

    public UserTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void User_ShouldHaveAdminUser()
    {
        var admin = _testData.Users.FirstOrDefault(u => u.Role == UserRole.Admin);
        
        admin.Should().NotBeNull();
        admin!.Username.Should().Be("admin");
        admin.Email.Should().Be("admin@nexusems.com");
        admin.Role.Should().Be(UserRole.Admin);
        admin.EmployeeProfile.Should().NotBeNull();
    }

    [Fact]
    public void User_ShouldHaveFiveBranchManagers()
    {
        var branchManagers = _testData.Users.Where(u => u.Role == UserRole.BranchManager).ToList();
        
        branchManagers.Should().HaveCount(5);
        branchManagers.All(bm => bm.BranchId.HasValue).Should().BeTrue();
        branchManagers.All(bm => bm.EmployeeProfile != null).Should().BeTrue();
    }

    [Fact]
    public void User_ShouldHaveDepartmentChiefs()
    {
        var chiefs = _testData.Users.Where(u => u.Role == UserRole.DepartmentChief).ToList();
        
        chiefs.Should().NotBeEmpty();
        chiefs.All(c => c.DepartmentId.HasValue).Should().BeTrue();
        chiefs.All(c => c.BranchId.HasValue).Should().BeTrue();
    }

    [Fact]
    public void User_ShouldHaveHRChiefs()
    {
        var hrChiefs = _testData.Users.Where(u => u.Role == UserRole.HumanResources).ToList();
        
        hrChiefs.Should().HaveCount(5);
        hrChiefs.All(hr => hr.DepartmentId.HasValue).Should().BeTrue();
        hrChiefs.All(hr => hr.BranchId.HasValue).Should().BeTrue();
    }

    [Fact]
    public void User_ShouldHaveAccountingChiefs()
    {
        var accountingChiefs = _testData.Users.Where(u => u.Role == UserRole.Accounting).ToList();
        
        accountingChiefs.Should().HaveCount(5);
        accountingChiefs.All(ac => ac.DepartmentId.HasValue).Should().BeTrue();
        accountingChiefs.All(ac => ac.BranchId.HasValue).Should().BeTrue();
    }

    [Fact]
    public void User_ShouldHaveManyEmployees()
    {
        var employees = _testData.Users.Where(u => u.Role == UserRole.Employee).ToList();
        
        employees.Should().NotBeEmpty();
        employees.Count.Should().BeGreaterThan(100);
    }

    [Fact]
    public void User_ShouldHaveSessionLogs()
    {
        var user = _testData.Users.First();
        var sessionLogs = _testData.SessionLogs.Where(s => s.UserId == user.Id).ToList();
        
        sessionLogs.Should().NotBeEmpty();
    }

    [Fact]
    public void User_ShouldHaveAuditLogs()
    {
        var user = _testData.Users.First();
        var auditLogs = _testData.AuditLogs.Where(a => a.ActorUserId == user.Id).ToList();
        
        auditLogs.Should().NotBeEmpty();
    }

    [Fact]
    public void User_HasRole_ShouldWorkWithPrimaryRole()
    {
        var user = new User { Role = UserRole.Accounting, SecondaryRole = null };
        
        user.HasRole(UserRole.Accounting).Should().BeTrue();
        user.HasRole(UserRole.Admin).Should().BeFalse();
    }

    [Fact]
    public void User_HasRole_ShouldWorkWithSecondaryRole()
    {
        var user = new User { Role = UserRole.Accounting, SecondaryRole = UserRole.DepartmentChief };
        
        user.HasRole(UserRole.Accounting).Should().BeTrue();
        user.HasRole(UserRole.DepartmentChief).Should().BeTrue();
        user.HasRole(UserRole.Admin).Should().BeFalse();
    }

    [Fact]
    public void User_HasAnyRole_ShouldReturnTrueForMatchingRole()
    {
        var user = new User { Role = UserRole.Accounting, SecondaryRole = UserRole.DepartmentChief };
        
        user.HasAnyRole(UserRole.Accounting, UserRole.HumanResources).Should().BeTrue();
        user.HasAnyRole(UserRole.BranchManager, UserRole.DepartmentChief).Should().BeTrue();
        user.HasAnyRole(UserRole.Admin, UserRole.Employee).Should().BeFalse();
    }
}
