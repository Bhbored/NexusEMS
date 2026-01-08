using FluentAssertions;
using NexusEMS.Shared.Enums;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class AttendanceEventTests
{
    private readonly TestDataBuilder _testData;

    public AttendanceEventTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void AttendanceEvent_ShouldHaveEvents()
    {
        _testData.AttendanceEvents.Should().NotBeEmpty();
        _testData.AttendanceEvents.Count.Should().BeGreaterThan(100);
    }

    [Fact]
    public void AttendanceEvent_ShouldHaveEmployeeRelationship()
    {
        var event_ = _testData.AttendanceEvents.First();
        
        event_.EmployeeProfileId.Should().NotBeEmpty();
        var employee = _testData.Employees.FirstOrDefault(e => e.Id == event_.EmployeeProfileId);
        employee.Should().NotBeNull();
    }

    [Fact]
    public void AttendanceEvent_ShouldHaveTimestamp()
    {
        foreach (var event_ in _testData.AttendanceEvents)
        {
            event_.TimestampUtc.Should().NotBe(default(DateTime));
        }
    }

    [Fact]
    public void AttendanceEvent_ShouldHaveEventType()
    {
        foreach (var event_ in _testData.AttendanceEvents)
        {
            event_.EventType.Should().BeOneOf(
                AttendanceEventType.CheckIn,
                AttendanceEventType.CheckOut,
                AttendanceEventType.BreakStart,
                AttendanceEventType.BreakEnd
            );
        }
    }

    [Fact]
    public void AttendanceEvent_ShouldHaveVerificationMethod()
    {
        foreach (var event_ in _testData.AttendanceEvents)
        {
            event_.VerificationMethod.Should().BeOneOf(
                VerificationMethod.Manual,
                VerificationMethod.QR,
                VerificationMethod.FaceRecognition,
                VerificationMethod.NFC
            );
        }
    }

    [Fact]
    public void AttendanceEvent_ShouldHaveCheckInAndCheckOut()
    {
        var checkIns = _testData.AttendanceEvents.Where(e => e.EventType == AttendanceEventType.CheckIn).ToList();
        var checkOuts = _testData.AttendanceEvents.Where(e => e.EventType == AttendanceEventType.CheckOut).ToList();
        
        checkIns.Should().NotBeEmpty();
        checkOuts.Should().NotBeEmpty();
    }
}
