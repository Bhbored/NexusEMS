using NexusEMS.Shared.Models;
using NexusEMS.Web.Test;

namespace NexusEMS.Web.Services
{
    public class TestDataService
    {
        public List<User> GetUsers() => TestData.Users;
        public List<Employee> GetEmployees() => TestData.Employees;
        public List<Branch> GetBranches() => TestData.Branches;
        public List<Department> GetDepartments() => TestData.Departments;
        public List<Position> GetPositions() => TestData.Positions;
        public List<SalaryConfiguration> GetSalaryConfigurations() => TestData.SalaryConfigurations;
        public List<SalaryPackage> GetSalaryPackages() => TestData.SalaryPackages;
        public List<SalaryComponent> GetSalaryComponents() => TestData.SalaryComponents;
        public List<SalaryChangeRequest> GetSalaryChangeRequests() => TestData.SalaryChangeRequests;
        public List<SalaryChangeItem> GetSalaryChangeItems() => TestData.SalaryChangeItems;
        public List<PayrollRun> GetPayrollRuns() => TestData.PayrollRuns;
        public List<SalarySlipSnapshot> GetSalarySlipSnapshots() => TestData.SalarySlipSnapshots;
        public List<WeeklyRating> GetWeeklyRatings() => TestData.WeeklyRatings;
        public List<WeeklyRatingRevision> GetWeeklyRatingRevisions() => TestData.WeeklyRatingRevisions;
        public List<WorkSchedule> GetWorkSchedules() => TestData.WorkSchedules;
        public List<WorkScheduleAssignment> GetWorkScheduleAssignments() => TestData.WorkScheduleAssignments;
        public List<ComplaintCase> GetComplaintCases() => TestData.ComplaintCases;
        public List<ComplaintMessage> GetComplaintMessages() => TestData.ComplaintMessages;
        public List<ComplaintAttachment> GetComplaintAttachments() => TestData.ComplaintAttachments;
        public List<AttendanceEvent> GetAttendanceEvents() => TestData.AttendanceEvents;
        public List<SessionLog> GetSessionLogs() => TestData.SessionLogs;
        public List<AuditLog> GetAuditLogs() => TestData.AuditLogs;
    }
}
