using FluentAssertions;
using NexusEMS.Shared.Enums;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class SalaryChangeItemTests
{
    private readonly TestDataBuilder _testData;

    public SalaryChangeItemTests()
    {
        _testData = new TestDataBuilder().Build();
    }

    [Fact]
    public void SalaryChangeItem_ShouldHaveItems()
    {
        _testData.SalaryChangeItems.Should().NotBeEmpty();
    }

    [Fact]
    public void SalaryChangeItem_ShouldHaveSalaryChangeRequestRelationship()
    {
        var item = _testData.SalaryChangeItems.First();
        
        item.SalaryChangeRequestId.Should().NotBeEmpty();
        var request = _testData.SalaryChangeRequests.FirstOrDefault(r => r.Id == item.SalaryChangeRequestId);
        request.Should().NotBeNull();
    }

    [Fact]
    public void SalaryChangeItem_ShouldHaveComponentType()
    {
        foreach (var item in _testData.SalaryChangeItems)
        {
            item.ComponentType.Should().BeDefined();
        }
    }

    [Fact]
    public void SalaryChangeItem_ShouldHaveAction()
    {
        foreach (var item in _testData.SalaryChangeItems)
        {
            item.Action.Should().BeOneOf(
                SalaryChangeItemAction.AddOrUpdate,
                SalaryChangeItemAction.Remove
            );
        }
    }

    [Fact]
    public void SalaryChangeItem_ShouldHaveAmount()
    {
        var itemsWithAmount = _testData.SalaryChangeItems.Where(i => i.Amount.HasValue).ToList();
        itemsWithAmount.Should().NotBeEmpty();
    }

    [Fact]
    public void SalaryChangeItem_ShouldHaveSource()
    {
        foreach (var item in _testData.SalaryChangeItems)
        {
            item.Source.Should().BeOneOf(
                SalaryComponentSource.AutoRule,
                SalaryComponentSource.Manual,
                SalaryComponentSource.Imported
            );
        }
    }
}
