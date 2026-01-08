using NexusEMS.Tests.TestData;
using NexusEMS.Shared.Models;

namespace NexusEMS.Web.Services
{
    public class TestDataService
    {
        private readonly TestDataBuilder _builder;

        public TestDataService()
        {
            _builder = new TestDataBuilder().Build();
        }

        public List<User> GetUsers() => _builder.Users;
        public List<Employee> GetEmployees() => _builder.Employees;
        public List<Branch> GetBranches() => _builder.Branches;
        public List<Department> GetDepartments() => _builder.Departments;
        public List<Position> GetPositions() => _builder.Positions;
        public List<SalaryConfiguration> GetSalaryConfigurations() => _builder.SalaryConfigurations;
        public List<SalaryPackage> GetSalaryPackages() => _builder.SalaryPackages;
        public List<SalaryComponent> GetSalaryComponents() => _builder.SalaryComponents;
        public List<SalaryChangeRequest> GetSalaryChangeRequests() => _builder.SalaryChangeRequests;
        public List<SalaryChangeItem> GetSalaryChangeItems() => _builder.SalaryChangeItems;
        public List<PayrollRun> GetPayrollRuns() => _builder.PayrollRuns;
        public List<SalarySlipSnapshot> GetSalarySlipSnapshots() => _builder.SalarySlipSnapshots;
        public List<WeeklyRating> GetWeeklyRatings() => _builder.WeeklyRatings;
        public List<WeeklyRatingRevision> GetWeeklyRatingRevisions() => _builder.WeeklyRatingRevisions;
        public List<WorkSchedule> GetWorkSchedules() => _builder.WorkSchedules;
        public List<WorkScheduleAssignment> GetWorkScheduleAssignments() => _builder.WorkScheduleAssignments;
        public List<ComplaintCase> GetComplaintCases() => _builder.ComplaintCases;
        public List<ComplaintMessage> GetComplaintMessages() => _builder.ComplaintMessages;
        public List<ComplaintAttachment> GetComplaintAttachments() => _builder.ComplaintAttachments;
        public List<AttendanceEvent> GetAttendanceEvents() => _builder.AttendanceEvents;
        public List<SessionLog> GetSessionLogs() => _builder.SessionLogs;
        public List<AuditLog> GetAuditLogs() => _builder.AuditLogs;
    }
}
