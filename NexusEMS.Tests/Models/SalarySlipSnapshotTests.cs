using FluentAssertions;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class SalarySlipSnapshotTests
{
    private readonly TestDataBuilder _testData;

    public SalarySlipSnapshotTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void SalarySlipSnapshot_ShouldHaveSnapshots()
    {
        _testData.SalarySlipSnapshots.Should().NotBeEmpty();
        _testData.SalarySlipSnapshots.Count.Should().BeGreaterThan(100);
    }

    [Fact]
    public void SalarySlipSnapshot_ShouldHavePayrollRunRelationship()
    {
        var snapshot = _testData.SalarySlipSnapshots.First();
        
        snapshot.PayrollRunId.Should().NotBeEmpty();
        var payrollRun = _testData.PayrollRuns.FirstOrDefault(pr => pr.Id == snapshot.PayrollRunId);
        payrollRun.Should().NotBeNull();
    }

    [Fact]
    public void SalarySlipSnapshot_ShouldHaveEmployeeRelationship()
    {
        var snapshot = _testData.SalarySlipSnapshots.First();
        
        snapshot.EmployeeProfileId.Should().NotBeEmpty();
        var employee = _testData.Employees.FirstOrDefault(e => e.Id == snapshot.EmployeeProfileId);
        employee.Should().NotBeNull();
    }

    [Fact]
    public void SalarySlipSnapshot_ShouldHaveFinancialAmounts()
    {
        foreach (var snapshot in _testData.SalarySlipSnapshots)
        {
            snapshot.Gross.Should().BeGreaterThan(0);
            snapshot.TotalDeductions.Should().BeGreaterThanOrEqualTo(0);
            snapshot.NetPaid.Should().BeGreaterThan(0);
            snapshot.NetPaid.Should().Be(snapshot.Gross - snapshot.TotalDeductions);
        }
    }

    [Fact]
    public void SalarySlipSnapshot_ShouldHaveCurrency()
    {
        foreach (var snapshot in _testData.SalarySlipSnapshots)
        {
            snapshot.Currency.Should().NotBeEmpty();
        }
    }

    [Fact]
    public void SalarySlipSnapshot_ShouldHaveSnapshotJson()
    {
        foreach (var snapshot in _testData.SalarySlipSnapshots)
        {
            snapshot.SnapshotJson.Should().NotBeEmpty();
        }
    }
}
