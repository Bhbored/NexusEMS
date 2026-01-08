using FluentAssertions;
using NexusEMS.Shared.Enums;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class PayrollRunTests
{
    private readonly TestDataBuilder _testData;

    public PayrollRunTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void PayrollRun_ShouldHaveRuns()
    {
        _testData.PayrollRuns.Should().NotBeEmpty();
    }

    [Fact]
    public void PayrollRun_ShouldHavePeriodDates()
    {
        foreach (var payrollRun in _testData.PayrollRuns)
        {
            payrollRun.PeriodStart.Should().NotBe(default(DateOnly));
            payrollRun.PeriodEnd.Should().NotBe(default(DateOnly));
            payrollRun.PeriodEnd.Should().BeAfter(payrollRun.PeriodStart);
        }
    }

    [Fact]
    public void PayrollRun_ShouldHaveStatus()
    {
        foreach (var payrollRun in _testData.PayrollRuns)
        {
            payrollRun.Status.Should().BeOneOf(
                PayrollRunStatus.Draft,
                PayrollRunStatus.Finalized,
                PayrollRunStatus.Paid
            );
        }
    }

    [Fact]
    public void PayrollRun_ShouldHaveCreatedByUser()
    {
        var payrollRun = _testData.PayrollRuns.First();
        
        payrollRun.CreatedByUserId.Should().NotBeEmpty();
        var user = _testData.Users.FirstOrDefault(u => u.Id == payrollRun.CreatedByUserId);
        user.Should().NotBeNull();
    }

    [Fact]
    public void PayrollRun_ShouldHaveSalarySlips()
    {
        foreach (var payrollRun in _testData.PayrollRuns)
        {
            payrollRun.SalarySlips.Should().NotBeEmpty();
        }
    }

    [Fact]
    public void PayrollRun_ShouldHaveFinalizedDate()
    {
        var finalizedRuns = _testData.PayrollRuns.Where(pr => pr.Status == PayrollRunStatus.Finalized).ToList();
        
        foreach (var payrollRun in finalizedRuns)
        {
            payrollRun.FinalizedAtUtc.Should().NotBeNull();
        }
    }
}
