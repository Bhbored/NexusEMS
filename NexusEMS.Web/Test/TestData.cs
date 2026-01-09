using NexusEMS.Shared.Models;
using NexusEMS.Shared.Enums;

namespace NexusEMS.Web.Test;

public static class TestData
{
    // Positions
    public static List<Position> Positions = new()
    {
        new Position { Title = "Administrator", Description = "System Administrator", BaseSalary = 120000 },
        new Position { Title = "Branch Manager", Description = "Manages a branch", BaseSalary = 100000 },
        new Position { Title = "Department Chief", Description = "Leads a department", BaseSalary = 80000 },
        new Position { Title = "HR Manager", Description = "Human Resources Manager", BaseSalary = 70000 },
        new Position { Title = "Accountant", Description = "Finance and Accounting", BaseSalary = 70000 },
        new Position { Title = "Senior Engineer", Description = "Senior Software Engineer", BaseSalary = 90000 },
        new Position { Title = "Engineer", Description = "Software Engineer", BaseSalary = 70000 },
        new Position { Title = "Junior Engineer", Description = "Junior Software Engineer", BaseSalary = 50000 }
    };

    // Users
    public static List<User> Users = new()
    {
        new User { Username = "admin", Email = "admin@nexusems.com", PasswordHash = "Admin123!", Role = UserRole.Admin, IsOnline = false },
        new User { Username = "bm1", Email = "bm1@nexusems.com", PasswordHash = "Manager123!", Role = UserRole.BranchManager, IsOnline = false },
        new User { Username = "bm2", Email = "bm2@nexusems.com", PasswordHash = "Manager123!", Role = UserRole.BranchManager, IsOnline = false },
        new User { Username = "bm3", Email = "bm3@nexusems.com", PasswordHash = "Manager123!", Role = UserRole.BranchManager, IsOnline = false },
        new User { Username = "bm4", Email = "bm4@nexusems.com", PasswordHash = "Manager123!", Role = UserRole.BranchManager, IsOnline = false },
        new User { Username = "bm5", Email = "bm5@nexusems.com", PasswordHash = "Manager123!", Role = UserRole.BranchManager, IsOnline = false },
        new User { Username = "chief1_eng", Email = "chief1_eng@nexusems.com", PasswordHash = "Chief123!", Role = UserRole.DepartmentChief, IsOnline = false },
        new User { Username = "chief1_mkt", Email = "chief1_mkt@nexusems.com", PasswordHash = "Chief123!", Role = UserRole.DepartmentChief, IsOnline = false },
        new User { Username = "chief2_eng", Email = "chief2_eng@nexusems.com", PasswordHash = "Chief123!", Role = UserRole.DepartmentChief, IsOnline = false },
        new User { Username = "chief2_mkt", Email = "chief2_mkt@nexusems.com", PasswordHash = "Chief123!", Role = UserRole.DepartmentChief, IsOnline = false },
        new User { Username = "hr1", Email = "hr1@nexusems.com", PasswordHash = "HR123!", Role = UserRole.HumanResources, IsOnline = false },
        new User { Username = "hr2", Email = "hr2@nexusems.com", PasswordHash = "HR123!", Role = UserRole.HumanResources, IsOnline = false },
        new User { Username = "acc1", Email = "acc1@nexusems.com", PasswordHash = "Acc123!", Role = UserRole.Accounting, IsOnline = false },
        new User { Username = "acc2", Email = "acc2@nexusems.com", PasswordHash = "Acc123!", Role = UserRole.Accounting, IsOnline = false },
        new User { Username = "emp001", Email = "emp001@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp002", Email = "emp002@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp003", Email = "emp003@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp004", Email = "emp004@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp005", Email = "emp005@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp006", Email = "emp006@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp007", Email = "emp007@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp008", Email = "emp008@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp009", Email = "emp009@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp010", Email = "emp010@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp011", Email = "emp011@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp012", Email = "emp012@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp013", Email = "emp013@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp014", Email = "emp014@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp015", Email = "emp015@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp016", Email = "emp016@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp017", Email = "emp017@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp018", Email = "emp018@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp019", Email = "emp019@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false },
        new User { Username = "emp020", Email = "emp020@nexusems.com", PasswordHash = "Emp123!", Role = UserRole.Employee, IsOnline = false }
    };

    // Branches
    public static List<Branch> Branches = new()
    {
        new Branch { Name = "North Branch", Code = "BR001", Location = "New York", Budget = 1000000, ContactNumber = "+1-555-001", ManagerUserId = Users[1].Id },
        new Branch { Name = "South Branch", Code = "BR002", Location = "Los Angeles", Budget = 1200000, ContactNumber = "+1-555-002", ManagerUserId = Users[2].Id },
        new Branch { Name = "East Branch", Code = "BR003", Location = "Chicago", Budget = 1400000, ContactNumber = "+1-555-003", ManagerUserId = Users[3].Id },
        new Branch { Name = "West Branch", Code = "BR004", Location = "Houston", Budget = 1600000, ContactNumber = "+1-555-004", ManagerUserId = Users[4].Id },
        new Branch { Name = "Central Branch", Code = "BR005", Location = "Phoenix", Budget = 1800000, ContactNumber = "+1-555-005", ManagerUserId = Users[5].Id }
    };

    // Departments
    public static List<Department> Departments = new()
    {
        new Department { Name = "Engineering - North", Code = "ENG01", BranchId = Branches[0].Id, ChiefUserId = Users[6].Id, Budget = 200000, IsSystemDepartment = false },
        new Department { Name = "Marketing - North", Code = "MKT01", BranchId = Branches[0].Id, ChiefUserId = Users[7].Id, Budget = 180000, IsSystemDepartment = false },
        new Department { Name = "HR - North", Code = "HR01", BranchId = Branches[0].Id, ChiefUserId = Users[10].Id, Budget = 150000, IsSystemDepartment = true },
        new Department { Name = "Accounting - North", Code = "ACC01", BranchId = Branches[0].Id, ChiefUserId = Users[12].Id, Budget = 180000, IsSystemDepartment = true },
        new Department { Name = "Engineering - South", Code = "ENG02", BranchId = Branches[1].Id, ChiefUserId = Users[8].Id, Budget = 220000, IsSystemDepartment = false },
        new Department { Name = "Marketing - South", Code = "MKT02", BranchId = Branches[1].Id, ChiefUserId = Users[9].Id, Budget = 190000, IsSystemDepartment = false },
        new Department { Name = "HR - South", Code = "HR02", BranchId = Branches[1].Id, ChiefUserId = Users[11].Id, Budget = 160000, IsSystemDepartment = true },
        new Department { Name = "Accounting - South", Code = "ACC02", BranchId = Branches[1].Id, ChiefUserId = Users[13].Id, Budget = 190000, IsSystemDepartment = true }
    };

    // Employees
    public static List<Employee> Employees = new()
    {
        new Employee { FirstName = "System", LastName = "Admin", Email = "admin@nexusems.com", Phone = "+1234567890", Gender = Gender.Male, EmployeeCode = "ADM001", EducationLevel = EducationLevel.PhD, DateOfBirth = new DateTime(1980, 1, 1), IsMarried = true, NumberOfChildren = 2, HireDate = new DateTime(2020, 1, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, DepartmentId = Departments[0].Id, PositionId = Positions[0].Id, AssignedToUserId = Users[0].Id },
        new Employee { FirstName = "Branch", LastName = "Manager1", Email = "bm1@nexusems.com", Phone = "+1234567891", Gender = Gender.Male, EmployeeCode = "BM001", EducationLevel = EducationLevel.Master, DateOfBirth = new DateTime(1985, 1, 1), IsMarried = true, NumberOfChildren = 1, HireDate = new DateTime(2021, 1, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[0].Id, DepartmentId = Departments[0].Id, PositionId = Positions[1].Id, AssignedToUserId = Users[1].Id },
        new Employee { FirstName = "Branch", LastName = "Manager2", Email = "bm2@nexusems.com", Phone = "+1234567892", Gender = Gender.Female, EmployeeCode = "BM002", EducationLevel = EducationLevel.Master, DateOfBirth = new DateTime(1986, 1, 1), IsMarried = false, NumberOfChildren = 0, HireDate = new DateTime(2021, 1, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[1].Id, DepartmentId = Departments[4].Id, PositionId = Positions[1].Id, AssignedToUserId = Users[2].Id },
        new Employee { FirstName = "Branch", LastName = "Manager3", Email = "bm3@nexusems.com", Phone = "+1234567893", Gender = Gender.Male, EmployeeCode = "BM003", EducationLevel = EducationLevel.Master, DateOfBirth = new DateTime(1987, 1, 1), IsMarried = true, NumberOfChildren = 1, HireDate = new DateTime(2021, 1, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[2].Id, DepartmentId = Departments[0].Id, PositionId = Positions[1].Id, AssignedToUserId = Users[3].Id },
        new Employee { FirstName = "Branch", LastName = "Manager4", Email = "bm4@nexusems.com", Phone = "+1234567894", Gender = Gender.Female, EmployeeCode = "BM004", EducationLevel = EducationLevel.Master, DateOfBirth = new DateTime(1988, 1, 1), IsMarried = true, NumberOfChildren = 2, HireDate = new DateTime(2021, 1, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[3].Id, DepartmentId = Departments[0].Id, PositionId = Positions[1].Id, AssignedToUserId = Users[4].Id },
        new Employee { FirstName = "Branch", LastName = "Manager5", Email = "bm5@nexusems.com", Phone = "+1234567895", Gender = Gender.Male, EmployeeCode = "BM005", EducationLevel = EducationLevel.Master, DateOfBirth = new DateTime(1989, 1, 1), IsMarried = false, NumberOfChildren = 0, HireDate = new DateTime(2021, 1, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[4].Id, DepartmentId = Departments[0].Id, PositionId = Positions[1].Id, AssignedToUserId = Users[5].Id },
        new Employee { FirstName = "Engineering", LastName = "Chief1", Email = "chief1_eng@nexusems.com", Phone = "+1234567896", Gender = Gender.Male, EmployeeCode = "DC101", EducationLevel = EducationLevel.Master, DateOfBirth = new DateTime(1988, 6, 1), IsMarried = true, NumberOfChildren = 1, HireDate = new DateTime(2021, 6, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[0].Id, DepartmentId = Departments[0].Id, PositionId = Positions[2].Id, AssignedToUserId = Users[6].Id },
        new Employee { FirstName = "Marketing", LastName = "Chief1", Email = "chief1_mkt@nexusems.com", Phone = "+1234567897", Gender = Gender.Female, EmployeeCode = "DC102", EducationLevel = EducationLevel.Master, DateOfBirth = new DateTime(1989, 6, 1), IsMarried = true, NumberOfChildren = 1, HireDate = new DateTime(2021, 6, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[0].Id, DepartmentId = Departments[1].Id, PositionId = Positions[2].Id, AssignedToUserId = Users[7].Id },
        new Employee { FirstName = "Engineering", LastName = "Chief2", Email = "chief2_eng@nexusems.com", Phone = "+1234567898", Gender = Gender.Male, EmployeeCode = "DC201", EducationLevel = EducationLevel.Master, DateOfBirth = new DateTime(1990, 6, 1), IsMarried = false, NumberOfChildren = 0, HireDate = new DateTime(2021, 6, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[1].Id, DepartmentId = Departments[4].Id, PositionId = Positions[2].Id, AssignedToUserId = Users[8].Id },
        new Employee { FirstName = "Marketing", LastName = "Chief2", Email = "chief2_mkt@nexusems.com", Phone = "+1234567899", Gender = Gender.Female, EmployeeCode = "DC202", EducationLevel = EducationLevel.Master, DateOfBirth = new DateTime(1991, 6, 1), IsMarried = true, NumberOfChildren = 2, HireDate = new DateTime(2021, 6, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[1].Id, DepartmentId = Departments[5].Id, PositionId = Positions[2].Id, AssignedToUserId = Users[9].Id },
        new Employee { FirstName = "HR", LastName = "Manager1", Email = "hr1@nexusems.com", Phone = "+1234567900", Gender = Gender.Female, EmployeeCode = "HR01", EducationLevel = EducationLevel.Master, DateOfBirth = new DateTime(1987, 3, 1), IsMarried = true, NumberOfChildren = 1, HireDate = new DateTime(2021, 3, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[0].Id, DepartmentId = Departments[2].Id, PositionId = Positions[3].Id, AssignedToUserId = Users[10].Id },
        new Employee { FirstName = "HR", LastName = "Manager2", Email = "hr2@nexusems.com", Phone = "+1234567901", Gender = Gender.Female, EmployeeCode = "HR02", EducationLevel = EducationLevel.Master, DateOfBirth = new DateTime(1988, 3, 1), IsMarried = false, NumberOfChildren = 0, HireDate = new DateTime(2021, 3, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[1].Id, DepartmentId = Departments[6].Id, PositionId = Positions[3].Id, AssignedToUserId = Users[11].Id },
        new Employee { FirstName = "Accountant", LastName = "Chief1", Email = "acc1@nexusems.com", Phone = "+1234567902", Gender = Gender.Male, EmployeeCode = "ACC01", EducationLevel = EducationLevel.Master, DateOfBirth = new DateTime(1986, 2, 1), IsMarried = true, NumberOfChildren = 2, HireDate = new DateTime(2021, 2, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[0].Id, DepartmentId = Departments[3].Id, PositionId = Positions[4].Id, AssignedToUserId = Users[12].Id },
        new Employee { FirstName = "Accountant", LastName = "Chief2", Email = "acc2@nexusems.com", Phone = "+1234567903", Gender = Gender.Male, EmployeeCode = "ACC02", EducationLevel = EducationLevel.Master, DateOfBirth = new DateTime(1987, 2, 1), IsMarried = true, NumberOfChildren = 1, HireDate = new DateTime(2021, 2, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[1].Id, DepartmentId = Departments[7].Id, PositionId = Positions[4].Id, AssignedToUserId = Users[13].Id },
        new Employee { FirstName = "John", LastName = "Smith", Email = "emp001@nexusems.com", Phone = "+1234567904", Gender = Gender.Male, EmployeeCode = "EMP001", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1992, 1, 1), IsMarried = false, NumberOfChildren = 0, HireDate = new DateTime(2022, 1, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[0].Id, DepartmentId = Departments[0].Id, PositionId = Positions[6].Id, AssignedToUserId = Users[14].Id },
        new Employee { FirstName = "Jane", LastName = "Doe", Email = "emp002@nexusems.com", Phone = "+1234567905", Gender = Gender.Female, EmployeeCode = "EMP002", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1993, 2, 1), IsMarried = true, NumberOfChildren = 1, HireDate = new DateTime(2022, 1, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[0].Id, DepartmentId = Departments[0].Id, PositionId = Positions[6].Id, AssignedToUserId = Users[15].Id },
        new Employee { FirstName = "Michael", LastName = "Johnson", Email = "emp003@nexusems.com", Phone = "+1234567906", Gender = Gender.Male, EmployeeCode = "EMP003", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1994, 3, 1), IsMarried = false, NumberOfChildren = 0, HireDate = new DateTime(2022, 1, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[0].Id, DepartmentId = Departments[0].Id, PositionId = Positions[7].Id, AssignedToUserId = Users[16].Id },
        new Employee { FirstName = "Sarah", LastName = "Williams", Email = "emp004@nexusems.com", Phone = "+1234567907", Gender = Gender.Female, EmployeeCode = "EMP004", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1995, 4, 1), IsMarried = false, NumberOfChildren = 0, HireDate = new DateTime(2022, 1, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[0].Id, DepartmentId = Departments[0].Id, PositionId = Positions[7].Id, AssignedToUserId = Users[17].Id },
        new Employee { FirstName = "David", LastName = "Brown", Email = "emp005@nexusems.com", Phone = "+1234567908", Gender = Gender.Male, EmployeeCode = "EMP005", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1996, 5, 1), IsMarried = true, NumberOfChildren = 1, HireDate = new DateTime(2022, 1, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[0].Id, DepartmentId = Departments[0].Id, PositionId = Positions[5].Id, AssignedToUserId = Users[18].Id },
        new Employee { FirstName = "Emily", LastName = "Davis", Email = "emp006@nexusems.com", Phone = "+1234567909", Gender = Gender.Female, EmployeeCode = "EMP006", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1992, 6, 1), IsMarried = false, NumberOfChildren = 0, HireDate = new DateTime(2022, 2, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[0].Id, DepartmentId = Departments[1].Id, PositionId = Positions[6].Id, AssignedToUserId = Users[19].Id },
        new Employee { FirstName = "Robert", LastName = "Miller", Email = "emp007@nexusems.com", Phone = "+1234567910", Gender = Gender.Male, EmployeeCode = "EMP007", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1993, 7, 1), IsMarried = true, NumberOfChildren = 1, HireDate = new DateTime(2022, 2, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[0].Id, DepartmentId = Departments[1].Id, PositionId = Positions[6].Id, AssignedToUserId = Users[20].Id },
        new Employee { FirstName = "Jessica", LastName = "Wilson", Email = "emp008@nexusems.com", Phone = "+1234567911", Gender = Gender.Female, EmployeeCode = "EMP008", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1994, 8, 1), IsMarried = false, NumberOfChildren = 0, HireDate = new DateTime(2022, 2, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[0].Id, DepartmentId = Departments[1].Id, PositionId = Positions[7].Id, AssignedToUserId = Users[21].Id },
        new Employee { FirstName = "William", LastName = "Moore", Email = "emp009@nexusems.com", Phone = "+1234567912", Gender = Gender.Male, EmployeeCode = "EMP009", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1995, 9, 1), IsMarried = false, NumberOfChildren = 0, HireDate = new DateTime(2022, 2, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[0].Id, DepartmentId = Departments[1].Id, PositionId = Positions[7].Id, AssignedToUserId = Users[22].Id },
        new Employee { FirstName = "Amanda", LastName = "Taylor", Email = "emp010@nexusems.com", Phone = "+1234567913", Gender = Gender.Female, EmployeeCode = "EMP010", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1996, 10, 1), IsMarried = true, NumberOfChildren = 1, HireDate = new DateTime(2022, 2, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[0].Id, DepartmentId = Departments[1].Id, PositionId = Positions[5].Id, AssignedToUserId = Users[23].Id },
        new Employee { FirstName = "Christopher", LastName = "Anderson", Email = "emp011@nexusems.com", Phone = "+1234567914", Gender = Gender.Male, EmployeeCode = "EMP011", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1992, 1, 1), IsMarried = false, NumberOfChildren = 0, HireDate = new DateTime(2022, 3, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[1].Id, DepartmentId = Departments[4].Id, PositionId = Positions[6].Id, AssignedToUserId = Users[24].Id },
        new Employee { FirstName = "Ashley", LastName = "Thomas", Email = "emp012@nexusems.com", Phone = "+1234567915", Gender = Gender.Female, EmployeeCode = "EMP012", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1993, 2, 1), IsMarried = true, NumberOfChildren = 1, HireDate = new DateTime(2022, 3, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[1].Id, DepartmentId = Departments[4].Id, PositionId = Positions[6].Id, AssignedToUserId = Users[25].Id },
        new Employee { FirstName = "Matthew", LastName = "Jackson", Email = "emp013@nexusems.com", Phone = "+1234567916", Gender = Gender.Male, EmployeeCode = "EMP013", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1994, 3, 1), IsMarried = false, NumberOfChildren = 0, HireDate = new DateTime(2022, 3, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[1].Id, DepartmentId = Departments[4].Id, PositionId = Positions[7].Id, AssignedToUserId = Users[26].Id },
        new Employee { FirstName = "Samantha", LastName = "White", Email = "emp014@nexusems.com", Phone = "+1234567917", Gender = Gender.Female, EmployeeCode = "EMP014", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1995, 4, 1), IsMarried = false, NumberOfChildren = 0, HireDate = new DateTime(2022, 3, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[1].Id, DepartmentId = Departments[4].Id, PositionId = Positions[7].Id, AssignedToUserId = Users[27].Id },
        new Employee { FirstName = "Daniel", LastName = "Harris", Email = "emp015@nexusems.com", Phone = "+1234567918", Gender = Gender.Male, EmployeeCode = "EMP015", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1996, 5, 1), IsMarried = true, NumberOfChildren = 1, HireDate = new DateTime(2022, 3, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[1].Id, DepartmentId = Departments[4].Id, PositionId = Positions[5].Id, AssignedToUserId = Users[28].Id },
        new Employee { FirstName = "Laura", LastName = "Martin", Email = "emp016@nexusems.com", Phone = "+1234567919", Gender = Gender.Female, EmployeeCode = "EMP016", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1992, 6, 1), IsMarried = false, NumberOfChildren = 0, HireDate = new DateTime(2022, 4, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[1].Id, DepartmentId = Departments[5].Id, PositionId = Positions[6].Id, AssignedToUserId = Users[29].Id },
        new Employee { FirstName = "James", LastName = "Thompson", Email = "emp017@nexusems.com", Phone = "+1234567920", Gender = Gender.Male, EmployeeCode = "EMP017", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1993, 7, 1), IsMarried = true, NumberOfChildren = 1, HireDate = new DateTime(2022, 4, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[1].Id, DepartmentId = Departments[5].Id, PositionId = Positions[6].Id, AssignedToUserId = Users[30].Id },
        new Employee { FirstName = "Megan", LastName = "Garcia", Email = "emp018@nexusems.com", Phone = "+1234567921", Gender = Gender.Female, EmployeeCode = "EMP018", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1994, 8, 1), IsMarried = false, NumberOfChildren = 0, HireDate = new DateTime(2022, 4, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[1].Id, DepartmentId = Departments[5].Id, PositionId = Positions[7].Id, AssignedToUserId = Users[31].Id },
        new Employee { FirstName = "Joshua", LastName = "Martinez", Email = "emp019@nexusems.com", Phone = "+1234567922", Gender = Gender.Male, EmployeeCode = "EMP019", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1995, 9, 1), IsMarried = false, NumberOfChildren = 0, HireDate = new DateTime(2022, 4, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[1].Id, DepartmentId = Departments[5].Id, PositionId = Positions[7].Id, AssignedToUserId = Users[32].Id },
        new Employee { FirstName = "Nicole", LastName = "Robinson", Email = "emp020@nexusems.com", Phone = "+1234567923", Gender = Gender.Female, EmployeeCode = "EMP020", EducationLevel = EducationLevel.Bachelor, DateOfBirth = new DateTime(1996, 10, 1), IsMarried = true, NumberOfChildren = 1, HireDate = new DateTime(2022, 4, 1), ContractType = ContractType.FullTime, EmploymentStatus = EmploymentStatus.Active, BranchId = Branches[1].Id, DepartmentId = Departments[5].Id, PositionId = Positions[5].Id, AssignedToUserId = Users[33].Id }
    };

    // Placeholder lists for other models
    public static List<SalaryConfiguration> SalaryConfigurations = new();
    public static List<SalaryPackage> SalaryPackages = new();
    public static List<SalaryComponent> SalaryComponents = new();
    public static List<SalaryChangeRequest> SalaryChangeRequests = new();
    public static List<SalaryChangeItem> SalaryChangeItems = new();
    public static List<PayrollRun> PayrollRuns = new();
    public static List<SalarySlipSnapshot> SalarySlipSnapshots = new();
    public static List<WeeklyRating> WeeklyRatings = new();
    public static List<WeeklyRatingRevision> WeeklyRatingRevisions = new();
    public static List<WorkSchedule> WorkSchedules = new();
    public static List<WorkScheduleAssignment> WorkScheduleAssignments = new();
    public static List<ComplaintCase> ComplaintCases = new();
    public static List<ComplaintMessage> ComplaintMessages = new();
    public static List<ComplaintAttachment> ComplaintAttachments = new();
    public static List<AttendanceEvent> AttendanceEvents = new();
    public static List<SessionLog> SessionLogs = new();
    public static List<AuditLog> AuditLogs = new();
}
