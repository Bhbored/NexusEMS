using FluentAssertions;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class SalaryConfigurationTests
{
    private readonly TestDataBuilder _testData;

    public SalaryConfigurationTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void SalaryConfiguration_ShouldHaveConfigurations()
    {
        _testData.SalaryConfigurations.Should().NotBeEmpty();
    }

    [Fact]
    public void SalaryConfiguration_ShouldHaveBranchRelationship()
    {
        var config = _testData.SalaryConfigurations.First();
        
        config.BranchId.Should().NotBeNull();
        var branch = _testData.Branches.FirstOrDefault(b => b.Id == config.BranchId);
        branch.Should().NotBeNull();
    }

    [Fact]
    public void SalaryConfiguration_ShouldHaveRequiredFields()
    {
        foreach (var config in _testData.SalaryConfigurations)
        {
            config.Name.Should().NotBeEmpty();
            config.BaseSalary.Should().BeGreaterThan(0);
        }
    }

    [Fact]
    public void SalaryConfiguration_ShouldHavePercentages()
    {
        foreach (var config in _testData.SalaryConfigurations)
        {
            config.HraPercentage.Should().BeGreaterThan(0);
            config.DaPercentage.Should().BeGreaterThan(0);
        }
    }

    [Fact]
    public void SalaryConfiguration_ShouldHaveMultipliers()
    {
        foreach (var config in _testData.SalaryConfigurations)
        {
            config.MarriedMultiplier.Should().BeGreaterThan(1);
            config.ChildMultiplier.Should().BeGreaterThan(0);
            config.PostGraduateMultiplier.Should().BeGreaterThan(1);
            config.PhdMultiplier.Should().BeGreaterThan(1);
        }
    }

    [Fact]
    public void SalaryConfiguration_ShouldHaveIsActiveFlag()
    {
        var activeConfigs = _testData.SalaryConfigurations.Where(c => c.IsActive).ToList();
        activeConfigs.Should().NotBeEmpty();
    }
}
