using FluentAssertions;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class ComplaintMessageTests
{
    private readonly TestDataBuilder _testData;

    public ComplaintMessageTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void ComplaintMessage_ShouldHaveMessages()
    {
        _testData.ComplaintMessages.Should().NotBeEmpty();
    }

    [Fact]
    public void ComplaintMessage_ShouldHaveComplaintCaseRelationship()
    {
        var message = _testData.ComplaintMessages.First();
        
        message.ComplaintCaseId.Should().NotBeEmpty();
        var complaint = _testData.ComplaintCases.FirstOrDefault(c => c.Id == message.ComplaintCaseId);
        complaint.Should().NotBeNull();
    }

    [Fact]
    public void ComplaintMessage_ShouldHaveAuthorUser()
    {
        var message = _testData.ComplaintMessages.First();
        
        message.AuthorUserId.Should().NotBeEmpty();
        var user = _testData.Users.FirstOrDefault(u => u.Id == message.AuthorUserId);
        user.Should().NotBeNull();
    }

    [Fact]
    public void ComplaintMessage_ShouldHaveBody()
    {
        foreach (var message in _testData.ComplaintMessages)
        {
            message.Body.Should().NotBeEmpty();
        }
    }

    [Fact]
    public void ComplaintMessage_ShouldHaveIsInternalFlag()
    {
        var internalMessages = _testData.ComplaintMessages.Where(m => m.IsInternal).ToList();
        var publicMessages = _testData.ComplaintMessages.Where(m => !m.IsInternal).ToList();
        
        publicMessages.Should().NotBeEmpty();
    }
}
