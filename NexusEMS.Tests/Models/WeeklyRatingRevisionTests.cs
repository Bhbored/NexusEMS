using FluentAssertions;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class WeeklyRatingRevisionTests
{
    private readonly TestDataBuilder _testData;

    public WeeklyRatingRevisionTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void WeeklyRatingRevision_ShouldHaveRevisions()
    {
        _testData.WeeklyRatingRevisions.Should().NotBeEmpty();
    }

    [Fact]
    public void WeeklyRatingRevision_ShouldHaveWeeklyRatingRelationship()
    {
        var revision = _testData.WeeklyRatingRevisions.First();
        
        revision.WeeklyRatingId.Should().NotBeEmpty();
        var rating = _testData.WeeklyRatings.FirstOrDefault(r => r.Id == revision.WeeklyRatingId);
        rating.Should().NotBeNull();
    }

    [Fact]
    public void WeeklyRatingRevision_ShouldHaveScore()
    {
        foreach (var revision in _testData.WeeklyRatingRevisions)
        {
            revision.Score.Should().BeInRange(1, 5);
        }
    }

    [Fact]
    public void WeeklyRatingRevision_ShouldHaveComment()
    {
        var revisionsWithComments = _testData.WeeklyRatingRevisions.Where(r => !string.IsNullOrEmpty(r.Comment)).ToList();
        revisionsWithComments.Should().NotBeEmpty();
    }

    [Fact]
    public void WeeklyRatingRevision_ShouldHaveCreatedByUser()
    {
        var revision = _testData.WeeklyRatingRevisions.First();
        
        revision.CreatedByUserId.Should().NotBeEmpty();
        var user = _testData.Users.FirstOrDefault(u => u.Id == revision.CreatedByUserId);
        user.Should().NotBeNull();
    }
}
