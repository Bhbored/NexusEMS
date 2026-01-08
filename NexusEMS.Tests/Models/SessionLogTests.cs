using FluentAssertions;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class SessionLogTests
{
    private readonly TestDataBuilder _testData;

    public SessionLogTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void SessionLog_ShouldHaveLogs()
    {
        _testData.SessionLogs.Should().NotBeEmpty();
        _testData.SessionLogs.Count.Should().BeGreaterThan(50);
    }

    [Fact]
    public void SessionLog_ShouldHaveUserRelationship()
    {
        var session = _testData.SessionLogs.First();
        
        session.UserId.Should().NotBeEmpty();
        var user = _testData.Users.FirstOrDefault(u => u.Id == session.UserId);
        user.Should().NotBeNull();
    }

    [Fact]
    public void SessionLog_ShouldHaveLoginAt()
    {
        foreach (var session in _testData.SessionLogs)
        {
            session.LoginAt.Should().NotBe(default(DateTime));
        }
    }

    [Fact]
    public void SessionLog_ShouldHaveActiveAndInactiveSessions()
    {
        var activeSessions = _testData.SessionLogs.Where(s => s.IsActive).ToList();
        var inactiveSessions = _testData.SessionLogs.Where(s => !s.IsActive).ToList();
        
        activeSessions.Should().NotBeEmpty();
        inactiveSessions.Should().NotBeEmpty();
    }

    [Fact]
    public void SessionLog_ShouldHaveSessionDuration()
    {
        var completedSessions = _testData.SessionLogs.Where(s => s.LogoutAt.HasValue).ToList();
        
        foreach (var session in completedSessions)
        {
            session.SessionDuration.Should().NotBeNull();
            session.SessionDuration!.Value.Should().BePositive();
        }
    }

    [Fact]
    public void SessionLog_ShouldHaveIpAddress()
    {
        var sessionsWithIp = _testData.SessionLogs.Where(s => !string.IsNullOrEmpty(s.IpAddress)).ToList();
        sessionsWithIp.Should().NotBeEmpty();
    }

    [Fact]
    public void SessionLog_ShouldHaveUserAgent()
    {
        var sessionsWithUserAgent = _testData.SessionLogs.Where(s => !string.IsNullOrEmpty(s.UserAgent)).ToList();
        sessionsWithUserAgent.Should().NotBeEmpty();
    }
}
