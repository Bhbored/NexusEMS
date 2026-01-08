using FluentAssertions;
using NexusEMS.Shared.Enums;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class SalaryPackageTests
{
    private readonly TestDataBuilder _testData;

    public SalaryPackageTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void SalaryPackage_ShouldHavePackagesForEmployees()
    {
        _testData.SalaryPackages.Should().NotBeEmpty();
        _testData.SalaryPackages.Count.Should().BeGreaterThan(100);
    }

    [Fact]
    public void SalaryPackage_ShouldHaveEmployeeRelationship()
    {
        var package = _testData.SalaryPackages.First();
        
        package.EmployeeProfileId.Should().NotBeEmpty();
        var employee = _testData.Employees.FirstOrDefault(e => e.Id == package.EmployeeProfileId);
        employee.Should().NotBeNull();
    }

    [Fact]
    public void SalaryPackage_ShouldHaveComponents()
    {
        var package = _testData.SalaryPackages.First();
        
        package.Components.Should().NotBeEmpty();
        package.Components.Count.Should().BeGreaterThan(5);
    }

    [Fact]
    public void SalaryPackage_ShouldHaveCreatedByUser()
    {
        var package = _testData.SalaryPackages.First();
        
        package.CreatedByUserId.Should().NotBeEmpty();
        var user = _testData.Users.FirstOrDefault(u => u.Id == package.CreatedByUserId);
        user.Should().NotBeNull();
    }

    [Fact]
    public void SalaryPackage_ShouldHaveEffectiveDates()
    {
        foreach (var package in _testData.SalaryPackages)
        {
            package.EffectiveFrom.Should().NotBe(default(DateOnly));
        }
    }

    [Fact]
    public void SalaryPackage_ShouldHaveCalculationMode()
    {
        var package = _testData.SalaryPackages.First();
        
        package.CalculationMode.Should().BeOneOf(
            SalaryCalculationMode.Auto,
            SalaryCalculationMode.Manual,
            SalaryCalculationMode.Mixed
        );
    }

    [Fact]
    public void SalaryPackage_Components_ShouldHaveEarningsAndDeductions()
    {
        var package = _testData.SalaryPackages.First();
        
        var earnings = package.Components.Where(c => !c.IsDeduction).ToList();
        var deductions = package.Components.Where(c => c.IsDeduction).ToList();
        
        earnings.Should().NotBeEmpty();
        deductions.Should().NotBeEmpty();
    }
}
