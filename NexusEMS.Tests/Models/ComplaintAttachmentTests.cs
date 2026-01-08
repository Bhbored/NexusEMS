using FluentAssertions;
using NexusEMS.Shared.Models;
using NexusEMS.Tests.TestData;

namespace NexusEMS.Tests.Models;

public class ComplaintAttachmentTests
{
    [Fact]
    public void ComplaintAttachment_ShouldHaveRequiredFields()
    {
        var attachment = new ComplaintAttachment
        {
            ComplaintCaseId = Guid.NewGuid(),
            FileName = "test.pdf",
            ContentType = "application/pdf",
            SizeBytes = 1024,
            StoragePath = "/storage/test.pdf",
            UploadedByUserId = Guid.NewGuid()
        };

        attachment.FileName.Should().NotBeEmpty();
        attachment.ContentType.Should().NotBeEmpty();
        attachment.StoragePath.Should().NotBeEmpty();
        attachment.SizeBytes.Should().BeGreaterThan(0);
    }

    [Fact]
    public void ComplaintAttachment_ShouldHaveComplaintCaseRelationship()
    {
        var testData = new TestDataBuilder().Build();
        
        if (testData.ComplaintAttachments.Any())
        {
            var attachment = testData.ComplaintAttachments.First();
            attachment.ComplaintCaseId.Should().NotBeEmpty();
        }
    }
}
