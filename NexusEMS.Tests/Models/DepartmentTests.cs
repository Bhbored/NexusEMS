using FluentAssertions;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class DepartmentTests
{
    private readonly TestDataBuilder _testData;

    public DepartmentTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void Department_ShouldHaveFiftyDepartments()
    {
        _testData.Departments.Should().HaveCount(50);
    }

    [Fact]
    public void Department_ShouldHaveTenPerBranch()
    {
        foreach (var branch in _testData.Branches)
        {
            var departments = _testData.Departments.Where(d => d.BranchId == branch.Id).ToList();
            departments.Should().HaveCount(10);
        }
    }

    [Fact]
    public void Department_ShouldHaveHRAndAccountingPerBranch()
    {
        foreach (var branch in _testData.Branches)
        {
            var departments = _testData.Departments.Where(d => d.BranchId == branch.Id).ToList();
            var hrDept = departments.FirstOrDefault(d => d.IsSystemDepartment && d.Name.Contains("Human Resources"));
            var accDept = departments.FirstOrDefault(d => d.IsSystemDepartment && d.Name.Contains("Accounting"));
            
            hrDept.Should().NotBeNull();
            accDept.Should().NotBeNull();
        }
    }

    [Fact]
    public void Department_ShouldHaveChief()
    {
        foreach (var department in _testData.Departments)
        {
            department.ChiefUserId.Should().NotBeNull();
            var chief = _testData.Users.FirstOrDefault(u => u.Id == department.ChiefUserId);
            chief.Should().NotBeNull();
        }
    }

    [Fact]
    public void Department_ShouldHaveBranchRelationship()
    {
        foreach (var department in _testData.Departments)
        {
            department.BranchId.Should().NotBeEmpty();
            var branch = _testData.Branches.FirstOrDefault(b => b.Id == department.BranchId);
            branch.Should().NotBeNull();
        }
    }

    [Fact]
    public void Department_ShouldHaveEmployees()
    {
        foreach (var department in _testData.Departments)
        {
            var employees = _testData.Employees.Where(e => e.DepartmentId == department.Id).ToList();
            employees.Should().NotBeEmpty();
        }
    }

    [Fact]
    public void Department_ShouldHaveWorkSchedules()
    {
        var department = _testData.Departments.First(d => !d.IsSystemDepartment);
        var schedules = _testData.WorkSchedules.Where(ws => ws.DepartmentId == department.Id).ToList();
        
        schedules.Should().NotBeEmpty();
    }

    [Fact]
    public void Department_ShouldHaveComplaintCases()
    {
        var department = _testData.Departments.First();
        var complaints = _testData.ComplaintCases.Where(c => c.DepartmentId == department.Id).ToList();
        
        complaints.Should().NotBeEmpty();
    }

    [Fact]
    public void Department_ShouldHaveAuditLogs()
    {
        var department = _testData.Departments.First();
        var auditLogs = _testData.AuditLogs.Where(a => a.DepartmentId == department.Id).ToList();
        
        auditLogs.Should().NotBeEmpty();
    }
}
