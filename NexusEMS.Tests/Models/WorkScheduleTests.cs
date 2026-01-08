using FluentAssertions;
using NexusEMS.Shared.Enums;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class WorkScheduleTests
{
    private readonly TestDataBuilder _testData;

    public WorkScheduleTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void WorkSchedule_ShouldHaveSchedules()
    {
        _testData.WorkSchedules.Should().NotBeEmpty();
    }

    [Fact]
    public void WorkSchedule_ShouldHaveDepartmentRelationship()
    {
        var schedule = _testData.WorkSchedules.First();
        
        schedule.DepartmentId.Should().NotBeEmpty();
        var department = _testData.Departments.FirstOrDefault(d => d.Id == schedule.DepartmentId);
        department.Should().NotBeNull();
    }

    [Fact]
    public void WorkSchedule_ShouldHaveCreatedByUser()
    {
        var schedule = _testData.WorkSchedules.First();
        
        schedule.CreatedByUserId.Should().NotBeEmpty();
        var user = _testData.Users.FirstOrDefault(u => u.Id == schedule.CreatedByUserId);
        user.Should().NotBeNull();
    }

    [Fact]
    public void WorkSchedule_ShouldHavePeriodDates()
    {
        foreach (var schedule in _testData.WorkSchedules)
        {
            schedule.PeriodStart.Should().NotBe(default(DateOnly));
            schedule.PeriodEnd.Should().NotBe(default(DateOnly));
            schedule.PeriodEnd.Should().BeAfter(schedule.PeriodStart);
        }
    }

    [Fact]
    public void WorkSchedule_ShouldHaveStatus()
    {
        foreach (var schedule in _testData.WorkSchedules)
        {
            schedule.Status.Should().BeOneOf(
                WorkScheduleStatus.Draft,
                WorkScheduleStatus.Submitted,
                WorkScheduleStatus.Approved,
                WorkScheduleStatus.Rejected,
                WorkScheduleStatus.Published
            );
        }
    }

    [Fact]
    public void WorkSchedule_ShouldHaveAssignments()
    {
        foreach (var schedule in _testData.WorkSchedules)
        {
            schedule.Assignments.Should().NotBeEmpty();
        }
    }

    [Fact]
    public void WorkSchedule_ShouldHaveApprovedByUser()
    {
        var approvedSchedules = _testData.WorkSchedules.Where(ws => ws.Status == WorkScheduleStatus.Approved).ToList();
        
        foreach (var schedule in approvedSchedules)
        {
            schedule.ApprovedByUserId.Should().NotBeNull();
        }
    }
}
