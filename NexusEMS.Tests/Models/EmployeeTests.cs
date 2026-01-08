using FluentAssertions;
using NexusEMS.Shared.Enums;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class EmployeeTests
{
    private readonly TestDataBuilder _testData;

    public EmployeeTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void Employee_ShouldHaveRequiredFields()
    {
        var employee = _testData.Employees.First();
        
        employee.FirstName.Should().NotBeEmpty();
        employee.LastName.Should().NotBeEmpty();
        employee.Email.Should().NotBeEmpty();
        employee.DepartmentId.Should().NotBeEmpty();
    }

    [Fact]
    public void Employee_ShouldHaveAbout200Employees()
    {
        _testData.Employees.Should().HaveCountGreaterThan(150);
        _testData.Employees.Should().HaveCountLessThan(250);
    }

    [Fact]
    public void Employee_ShouldHaveDepartmentRelationship()
    {
        var employee = _testData.Employees.First(e => e.DepartmentId != Guid.Empty);
        
        employee.DepartmentId.Should().NotBeEmpty();
        var department = _testData.Departments.FirstOrDefault(d => d.Id == employee.DepartmentId);
        department.Should().NotBeNull();
    }

    [Fact]
    public void Employee_ShouldHaveBranchRelationship()
    {
        var employee = _testData.Employees.First(e => e.BranchId.HasValue);
        
        employee.BranchId.Should().NotBeNull();
        var branch = _testData.Branches.FirstOrDefault(b => b.Id == employee.BranchId);
        branch.Should().NotBeNull();
    }

    [Fact]
    public void Employee_ShouldHaveUserRelationship()
    {
        var employee = _testData.Employees.First(e => e.AssignedToUserId.HasValue);
        
        employee.AssignedToUserId.Should().NotBeNull();
        var user = _testData.Users.FirstOrDefault(u => u.Id == employee.AssignedToUserId);
        user.Should().NotBeNull();
        user!.EmployeeProfileId.Should().Be(employee.Id);
    }

    [Fact]
    public void Employee_ShouldHaveAttendanceEvents()
    {
        var employee = _testData.Employees.First();
        var attendanceEvents = _testData.AttendanceEvents.Where(a => a.EmployeeProfileId == employee.Id).ToList();
        
        attendanceEvents.Should().NotBeEmpty();
    }

    [Fact]
    public void Employee_ShouldHaveWeeklyRatings()
    {
        var employee = _testData.Employees.First();
        var ratings = _testData.WeeklyRatings.Where(r => r.EmployeeProfileId == employee.Id).ToList();
        
        ratings.Should().NotBeEmpty();
    }

    [Fact]
    public void Employee_ShouldHaveSalaryPackages()
    {
        var employee = _testData.Employees.First(e => e.AssignedToUserId.HasValue);
        var packages = _testData.SalaryPackages.Where(p => p.EmployeeProfileId == employee.Id).ToList();
        
        packages.Should().NotBeEmpty();
    }

    [Fact]
    public void Employee_ShouldHaveSalarySlips()
    {
        var employee = _testData.Employees.First(e => e.AssignedToUserId.HasValue);
        var slips = _testData.SalarySlipSnapshots.Where(s => s.EmployeeProfileId == employee.Id).ToList();
        
        slips.Should().NotBeEmpty();
    }

    [Fact]
    public void Employee_ShouldHaveReportsToRelationship()
    {
        var employeesWithManager = _testData.Employees.Where(e => e.ReportsToEmployeeId.HasValue).ToList();
        
        employeesWithManager.Should().NotBeEmpty();
        foreach (var emp in employeesWithManager)
        {
            var manager = _testData.Employees.FirstOrDefault(e => e.Id == emp.ReportsToEmployeeId);
            manager.Should().NotBeNull();
        }
    }

    [Fact]
    public void Employee_ShouldHaveComplaintsCreated()
    {
        var employee = _testData.Employees.First();
        var complaints = _testData.ComplaintCases.Where(c => c.CreatedByEmployeeProfileId == employee.Id).ToList();
        
        complaints.Should().NotBeEmpty();
    }
}
