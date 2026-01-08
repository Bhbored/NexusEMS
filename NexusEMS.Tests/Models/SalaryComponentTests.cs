using FluentAssertions;
using NexusEMS.Shared.Enums;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class SalaryComponentTests
{
    private readonly TestDataBuilder _testData;

    public SalaryComponentTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void SalaryComponent_ShouldHaveManyComponents()
    {
        _testData.SalaryComponents.Should().NotBeEmpty();
        _testData.SalaryComponents.Count.Should().BeGreaterThan(500);
    }

    [Fact]
    public void SalaryComponent_ShouldHaveSalaryPackageRelationship()
    {
        var component = _testData.SalaryComponents.First();
        
        component.SalaryPackageId.Should().NotBeEmpty();
        var package = _testData.SalaryPackages.FirstOrDefault(p => p.Id == component.SalaryPackageId);
        package.Should().NotBeNull();
    }

    [Fact]
    public void SalaryComponent_ShouldHaveType()
    {
        foreach (var component in _testData.SalaryComponents)
        {
            component.Type.Should().BeDefined();
        }
    }

    [Fact]
    public void SalaryComponent_ShouldHaveAmount()
    {
        foreach (var component in _testData.SalaryComponents)
        {
            component.Amount.Should().BeGreaterThanOrEqualTo(0);
        }
    }

    [Fact]
    public void SalaryComponent_ShouldHaveIsDeductionFlag()
    {
        var earnings = _testData.SalaryComponents.Where(c => !c.IsDeduction).ToList();
        var deductions = _testData.SalaryComponents.Where(c => c.IsDeduction).ToList();
        
        earnings.Should().NotBeEmpty();
        deductions.Should().NotBeEmpty();
    }

    [Fact]
    public void SalaryComponent_ShouldHaveSource()
    {
        foreach (var component in _testData.SalaryComponents)
        {
            component.Source.Should().BeOneOf(
                SalaryComponentSource.AutoRule,
                SalaryComponentSource.Manual,
                SalaryComponentSource.Imported
            );
        }
    }

    [Fact]
    public void SalaryComponent_ShouldHaveCurrency()
    {
        foreach (var component in _testData.SalaryComponents)
        {
            component.Currency.Should().NotBeEmpty();
        }
    }
}
