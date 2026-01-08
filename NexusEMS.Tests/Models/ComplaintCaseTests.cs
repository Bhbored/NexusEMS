using FluentAssertions;
using NexusEMS.Shared.Enums;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class ComplaintCaseTests
{
    private readonly TestDataBuilder _testData;

    public ComplaintCaseTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void ComplaintCase_ShouldHaveComplaints()
    {
        _testData.ComplaintCases.Should().NotBeEmpty();
    }

    [Fact]
    public void ComplaintCase_ShouldHaveCreatedByEmployee()
    {
        var complaint = _testData.ComplaintCases.First();
        
        complaint.CreatedByEmployeeProfileId.Should().NotBeEmpty();
        var employee = _testData.Employees.FirstOrDefault(e => e.Id == complaint.CreatedByEmployeeProfileId);
        employee.Should().NotBeNull();
    }

    [Fact]
    public void ComplaintCase_ShouldHaveDepartmentRelationship()
    {
        var complaint = _testData.ComplaintCases.First();
        
        complaint.DepartmentId.Should().NotBeEmpty();
        var department = _testData.Departments.FirstOrDefault(d => d.Id == complaint.DepartmentId);
        department.Should().NotBeNull();
    }

    [Fact]
    public void ComplaintCase_ShouldHaveBranchRelationship()
    {
        var complaint = _testData.ComplaintCases.First();
        
        complaint.BranchId.Should().NotBeNull();
    }

    [Fact]
    public void ComplaintCase_ShouldHaveRequiredFields()
    {
        foreach (var complaint in _testData.ComplaintCases)
        {
            complaint.Subject.Should().NotBeEmpty();
            complaint.Description.Should().NotBeEmpty();
        }
    }

    [Fact]
    public void ComplaintCase_ShouldHaveStatus()
    {
        foreach (var complaint in _testData.ComplaintCases)
        {
            complaint.Status.Should().BeOneOf(
                ComplaintStatus.Submitted,
                ComplaintStatus.InReview,
                ComplaintStatus.WaitingOnEmployee,
                ComplaintStatus.Resolved,
                ComplaintStatus.Rejected
            );
        }
    }

    [Fact]
    public void ComplaintCase_ShouldHaveMessages()
    {
        foreach (var complaint in _testData.ComplaintCases)
        {
            complaint.Messages.Should().NotBeEmpty();
        }
    }

    [Fact]
    public void ComplaintCase_ShouldHaveTarget()
    {
        foreach (var complaint in _testData.ComplaintCases)
        {
            complaint.Target.Should().BeOneOf(
                ComplaintTarget.HR,
                ComplaintTarget.DepartmentChief,
                ComplaintTarget.Both
            );
        }
    }
}
