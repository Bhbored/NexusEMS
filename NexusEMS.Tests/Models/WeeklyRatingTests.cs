using FluentAssertions;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class WeeklyRatingTests
{
    private readonly TestDataBuilder _testData;

    public WeeklyRatingTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void WeeklyRating_ShouldHaveRatings()
    {
        _testData.WeeklyRatings.Should().NotBeEmpty();
    }

    [Fact]
    public void WeeklyRating_ShouldHaveEmployeeRelationship()
    {
        var rating = _testData.WeeklyRatings.First();
        
        rating.EmployeeProfileId.Should().NotBeEmpty();
        var employee = _testData.Employees.FirstOrDefault(e => e.Id == rating.EmployeeProfileId);
        employee.Should().NotBeNull();
    }

    [Fact]
    public void WeeklyRating_ShouldHaveWeekStartDate()
    {
        foreach (var rating in _testData.WeeklyRatings)
        {
            rating.WeekStartDate.Should().NotBe(default(DateOnly));
        }
    }

    [Fact]
    public void WeeklyRating_ShouldHaveCreatedByUser()
    {
        var rating = _testData.WeeklyRatings.First();
        
        rating.CreatedByUserId.Should().NotBeEmpty();
        var user = _testData.Users.FirstOrDefault(u => u.Id == rating.CreatedByUserId);
        user.Should().NotBeNull();
    }

    [Fact]
    public void WeeklyRating_ShouldHaveRevisions()
    {
        foreach (var rating in _testData.WeeklyRatings)
        {
            rating.Revisions.Should().NotBeEmpty();
        }
    }

    [Fact]
    public void WeeklyRating_ShouldHaveIsFinalizedFlag()
    {
        var finalizedRatings = _testData.WeeklyRatings.Where(r => r.IsFinalized).ToList();
        finalizedRatings.Should().NotBeEmpty();
    }
}
