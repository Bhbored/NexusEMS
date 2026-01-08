using FluentAssertions;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class WorkScheduleAssignmentTests
{
    private readonly TestDataBuilder _testData;

    public WorkScheduleAssignmentTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void WorkScheduleAssignment_ShouldHaveAssignments()
    {
        _testData.WorkScheduleAssignments.Should().NotBeEmpty();
        _testData.WorkScheduleAssignments.Count.Should().BeGreaterThan(1000);
    }

    [Fact]
    public void WorkScheduleAssignment_ShouldHaveWorkScheduleRelationship()
    {
        var assignment = _testData.WorkScheduleAssignments.First();
        
        assignment.WorkScheduleId.Should().NotBeEmpty();
        var schedule = _testData.WorkSchedules.FirstOrDefault(ws => ws.Id == assignment.WorkScheduleId);
        schedule.Should().NotBeNull();
    }

    [Fact]
    public void WorkScheduleAssignment_ShouldHaveEmployeeRelationship()
    {
        var assignment = _testData.WorkScheduleAssignments.First();
        
        assignment.EmployeeId.Should().NotBeEmpty();
        var employee = _testData.Employees.FirstOrDefault(e => e.Id == assignment.EmployeeId);
        employee.Should().NotBeNull();
    }

    [Fact]
    public void WorkScheduleAssignment_ShouldHaveDate()
    {
        foreach (var assignment in _testData.WorkScheduleAssignments)
        {
            assignment.Date.Should().NotBe(default(DateOnly));
        }
    }

    [Fact]
    public void WorkScheduleAssignment_ShouldHaveTimeSlots()
    {
        var assignmentsWithTime = _testData.WorkScheduleAssignments.Where(a => a.StartTime.HasValue && a.EndTime.HasValue).ToList();
        assignmentsWithTime.Should().NotBeEmpty();
    }

    [Fact]
    public void WorkScheduleAssignment_ShouldHaveIsDayOffFlag()
    {
        var dayOffAssignments = _testData.WorkScheduleAssignments.Where(a => a.IsDayOff).ToList();
        dayOffAssignments.Should().NotBeEmpty();
    }
}
