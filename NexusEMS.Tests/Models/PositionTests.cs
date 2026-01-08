using FluentAssertions;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class PositionTests
{
    private readonly TestDataBuilder _testData;

    public PositionTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void Position_ShouldHavePositions()
    {
        _testData.Positions.Should().NotBeEmpty();
    }

    [Fact]
    public void Position_ShouldHaveRequiredFields()
    {
        foreach (var position in _testData.Positions)
        {
            position.Title.Should().NotBeEmpty();
        }
    }

    [Fact]
    public void Position_ShouldHaveSalaryRanges()
    {
        var positionsWithRanges = _testData.Positions.Where(p => p.SalaryRangeMin.HasValue && p.SalaryRangeMax.HasValue).ToList();
        
        foreach (var position in positionsWithRanges)
        {
            position.SalaryRangeMax.Should().BeGreaterThan(position.SalaryRangeMin!.Value);
        }
    }

    [Fact]
    public void Position_ShouldHaveBaseSalary()
    {
        var positionsWithBase = _testData.Positions.Where(p => p.BaseSalary.HasValue).ToList();
        positionsWithBase.Should().NotBeEmpty();
    }
}
