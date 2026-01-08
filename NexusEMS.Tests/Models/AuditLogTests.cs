using FluentAssertions;
using NexusEMS.Shared.Enums;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class AuditLogTests
{
    private readonly TestDataBuilder _testData;

    public AuditLogTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void AuditLog_ShouldHaveLogs()
    {
        _testData.AuditLogs.Should().NotBeEmpty();
    }

    [Fact]
    public void AuditLog_ShouldHaveActorUser()
    {
        var auditLog = _testData.AuditLogs.First();
        
        auditLog.ActorUserId.Should().NotBeEmpty();
        var user = _testData.Users.FirstOrDefault(u => u.Id == auditLog.ActorUserId);
        user.Should().NotBeNull();
    }

    [Fact]
    public void AuditLog_ShouldHaveAction()
    {
        foreach (var auditLog in _testData.AuditLogs)
        {
            auditLog.Action.Should().BeOneOf(
                AuditAction.Create,
                AuditAction.Update,
                AuditAction.Delete,
                AuditAction.Approve,
                AuditAction.Reject,
                AuditAction.Apply
            );
        }
    }

    [Fact]
    public void AuditLog_ShouldHaveEntityType()
    {
        foreach (var auditLog in _testData.AuditLogs)
        {
            auditLog.EntityType.Should().NotBeEmpty();
        }
    }

    [Fact]
    public void AuditLog_ShouldHaveHierarchyFields()
    {
        var auditLogsWithDept = _testData.AuditLogs.Where(a => a.DepartmentId.HasValue).ToList();
        var auditLogsWithBranch = _testData.AuditLogs.Where(a => a.BranchId.HasValue).ToList();
        var auditLogsWithEmployee = _testData.AuditLogs.Where(a => a.EmployeeId.HasValue).ToList();
        
        auditLogsWithDept.Should().NotBeEmpty();
        auditLogsWithBranch.Should().NotBeEmpty();
        auditLogsWithEmployee.Should().NotBeEmpty();
    }

    [Fact]
    public void AuditLog_ShouldHaveJsonFields()
    {
        var auditLogsWithOldValues = _testData.AuditLogs.Where(a => !string.IsNullOrEmpty(a.OldValuesJson)).ToList();
        var auditLogsWithNewValues = _testData.AuditLogs.Where(a => !string.IsNullOrEmpty(a.NewValuesJson)).ToList();
        
        auditLogsWithOldValues.Should().NotBeEmpty();
        auditLogsWithNewValues.Should().NotBeEmpty();
    }
}
