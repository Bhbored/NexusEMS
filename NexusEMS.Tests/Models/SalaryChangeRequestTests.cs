using FluentAssertions;
using NexusEMS.Shared.Enums;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class SalaryChangeRequestTests
{
    private readonly TestDataBuilder _testData;

    public SalaryChangeRequestTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void SalaryChangeRequest_ShouldHaveRequests()
    {
        _testData.SalaryChangeRequests.Should().NotBeEmpty();
    }

    [Fact]
    public void SalaryChangeRequest_ShouldHaveEmployeeRelationship()
    {
        var request = _testData.SalaryChangeRequests.First();
        
        request.EmployeeProfileId.Should().NotBeEmpty();
        var employee = _testData.Employees.FirstOrDefault(e => e.Id == request.EmployeeProfileId);
        employee.Should().NotBeNull();
    }

    [Fact]
    public void SalaryChangeRequest_ShouldHaveStatus()
    {
        foreach (var request in _testData.SalaryChangeRequests)
        {
            request.Status.Should().BeOneOf(
                SalaryChangeStatus.Draft,
                SalaryChangeStatus.Submitted,
                SalaryChangeStatus.Approved,
                SalaryChangeStatus.Rejected,
                SalaryChangeStatus.Applied
            );
        }
    }

    [Fact]
    public void SalaryChangeRequest_ShouldHaveRequestedByUser()
    {
        var request = _testData.SalaryChangeRequests.First();
        
        request.RequestedByUserId.Should().NotBeEmpty();
        var user = _testData.Users.FirstOrDefault(u => u.Id == request.RequestedByUserId);
        user.Should().NotBeNull();
    }

    [Fact]
    public void SalaryChangeRequest_ShouldHaveItems()
    {
        foreach (var request in _testData.SalaryChangeRequests)
        {
            request.Items.Should().NotBeEmpty();
        }
    }

    [Fact]
    public void SalaryChangeRequest_ShouldHaveEffectiveFrom()
    {
        foreach (var request in _testData.SalaryChangeRequests)
        {
            request.EffectiveFrom.Should().NotBe(default(DateOnly));
        }
    }

    [Fact]
    public void SalaryChangeRequest_ShouldHaveReviewedByUser()
    {
        var approvedRequests = _testData.SalaryChangeRequests.Where(r => r.Status == SalaryChangeStatus.Approved).ToList();
        
        foreach (var request in approvedRequests)
        {
            request.ReviewedByUserId.Should().NotBeNull();
        }
    }
}
