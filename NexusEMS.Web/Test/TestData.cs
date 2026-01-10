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
        new Branch { Name = "North Branch", Code = "BR001", Location = "New York", Budget = 1000000, ContactNumber = "+1-555-001", ManagerId = Users[1].Id },
        new Branch { Name = "South Branch", Code = "BR002", Location = "Los Angeles", Budget = 1200000, ContactNumber = "+1-555-002", ManagerId = Users[2].Id },
        new Branch { Name = "East Branch", Code = "BR003", Location = "Chicago", Budget = 1400000, ContactNumber = "+1-555-003", ManagerId = Users[3].Id },
        new Branch { Name = "West Branch", Code = "BR004", Location = "Houston", Budget = 1600000, ContactNumber = "+1-555-004", ManagerId = Users[4].Id },
        new Branch { Name = "Central Branch", Code = "BR005", Location = "Phoenix", Budget = 1800000, ContactNumber = "+1-555-005", ManagerId = Users[5].Id }
    };

    // Departments
    public static List<Department> Departments = new()
    {
        new Department { Name = "Engineering - North", Code = "ENG01", BranchId = Branches[0].Id, Budget = 200000, IsSystemDepartment = false },
        new Department { Name = "Marketing - North", Code = "MKT01", BranchId = Branches[0].Id, Budget = 180000, IsSystemDepartment = false },
        new Department { Name = "HR - North", Code = "HR01", BranchId = Branches[0].Id, Budget = 150000, IsSystemDepartment = true },
        new Department { Name = "Accounting - North", Code = "ACC01", BranchId = Branches[0].Id, Budget = 180000, IsSystemDepartment = true },
        new Department { Name = "Engineering - South", Code = "ENG02", BranchId = Branches[1].Id, Budget = 220000, IsSystemDepartment = false },
        new Department { Name = "Marketing - South", Code = "MKT02", BranchId = Branches[1].Id, Budget = 190000, IsSystemDepartment = false },
        new Department { Name = "HR - South", Code = "HR02", BranchId = Branches[1].Id, Budget = 160000, IsSystemDepartment = true },
        new Department { Name = "Accounting - South", Code = "ACC02", BranchId = Branches[1].Id, Budget = 190000, IsSystemDepartment = true }
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

    static TestData()
    {
        Departments[0].ChiefId = Employees[6].Id;
        Departments[0].Chief = Employees[6];

        Departments[1].ChiefId = Employees[7].Id;
        Departments[1].Chief = Employees[7];

        Departments[2].ChiefId = Employees[10].Id;
        Departments[2].Chief = Employees[10];

        Departments[3].ChiefId = Employees[12].Id;
        Departments[3].Chief = Employees[12];

        Departments[4].ChiefId = Employees[8].Id;
        Departments[4].Chief = Employees[8];

        Departments[5].ChiefId = Employees[9].Id;
        Departments[5].Chief = Employees[9];

        Departments[6].ChiefId = Employees[11].Id;
        Departments[6].Chief = Employees[11];

        Departments[7].ChiefId = Employees[13].Id;
        Departments[7].Chief = Employees[13];
    }

    public static List<SalaryConfiguration> SalaryConfigurations = new()
    {
        new SalaryConfiguration
        {
            Id = Guid.NewGuid(),
            BranchId = Branches[0].Id,
            Name = "North Branch Standard",
            Description = "Standard salary configuration for North Branch",
            BaseSalary = 60000,
            HraPercentage = 20,
            DaPercentage = 10,
            ConveyanceAllowance = 2000,
            MedicalAllowance = 1500,
            MarriedMultiplier = 1.1m,
            ChildMultiplier = 0.05m,
            PostGraduateMultiplier = 1.15m,
            PhdMultiplier = 1.25m,
            TwoYearIncrementPercentage = 5,
            IsActive = true,
            CreatedAt = DateTime.UtcNow.AddMonths(-6),
            UpdatedAt = DateTime.UtcNow.AddMonths(-6)
        },
        new SalaryConfiguration
        {
            Id = Guid.NewGuid(),
            BranchId = Branches[1].Id,
            Name = "South Branch Standard",
            Description = "Standard salary configuration for South Branch",
            BaseSalary = 65000,
            HraPercentage = 22,
            DaPercentage = 12,
            ConveyanceAllowance = 2200,
            MedicalAllowance = 1600,
            MarriedMultiplier = 1.1m,
            ChildMultiplier = 0.05m,
            PostGraduateMultiplier = 1.15m,
            PhdMultiplier = 1.25m,
            TwoYearIncrementPercentage = 5,
            IsActive = true,
            CreatedAt = DateTime.UtcNow.AddMonths(-5),
            UpdatedAt = DateTime.UtcNow.AddMonths(-5)
        },
        new SalaryConfiguration
        {
            Id = Guid.NewGuid(),
            DepartmentId = Departments[0].Id,
            Name = "Engineering Department",
            Description = "Specialized configuration for Engineering department",
            BaseSalary = 70000,
            HraPercentage = 20,
            DaPercentage = 10,
            ConveyanceAllowance = 2500,
            MedicalAllowance = 2000,
            MarriedMultiplier = 1.12m,
            ChildMultiplier = 0.06m,
            PostGraduateMultiplier = 1.20m,
            PhdMultiplier = 1.30m,
            TwoYearIncrementPercentage = 6,
            IsActive = true,
            CreatedAt = DateTime.UtcNow.AddMonths(-4),
            UpdatedAt = DateTime.UtcNow.AddMonths(-4)
        }
    };

    public static List<SalaryPackage> SalaryPackages = new();
    public static List<SalaryComponent> SalaryComponents = new();

    public static List<SalaryChangeItem> SalaryChangeItems = new()
    {
        new SalaryChangeItem
        {
            Id = Guid.NewGuid(),
            ComponentType = SalaryComponentType.Base,
            Action = SalaryChangeItemAction.AddOrUpdate,
            Amount = 90000,
            IsDeduction = false,
            Source = SalaryComponentSource.Manual,
            CreatedAt = DateTime.UtcNow.AddDays(-10),
            UpdatedAt = DateTime.UtcNow.AddDays(-10)
        },
        new SalaryChangeItem
        {
            Id = Guid.NewGuid(),
            ComponentType = SalaryComponentType.Bonus,
            Action = SalaryChangeItemAction.AddOrUpdate,
            Amount = 5000,
            IsDeduction = false,
            Source = SalaryComponentSource.Manual,
            CreatedAt = DateTime.UtcNow.AddDays(-10),
            UpdatedAt = DateTime.UtcNow.AddDays(-10)
        },
        new SalaryChangeItem
        {
            Id = Guid.NewGuid(),
            ComponentType = SalaryComponentType.Base,
            Action = SalaryChangeItemAction.AddOrUpdate,
            Amount = 110000,
            IsDeduction = false,
            Source = SalaryComponentSource.Manual,
            CreatedAt = DateTime.UtcNow.AddDays(-5),
            UpdatedAt = DateTime.UtcNow.AddDays(-5)
        }
    };

    public static List<SalaryChangeRequest> SalaryChangeRequests = new()
    {
        new SalaryChangeRequest
        {
            Id = Guid.NewGuid(),
            EmployeeProfileId = Employees[6].Id,
            Status = SalaryChangeStatus.Submitted,
            RequestedByUserId = Users[12].Id,
            Reason = "Performance-based salary increase for Department Chief",
            EffectiveFrom = DateOnly.FromDateTime(DateTime.Today.AddMonths(1)),
            CreatedAt = DateTime.UtcNow.AddDays(-10),
            UpdatedAt = DateTime.UtcNow.AddDays(-10),
            Items = new List<SalaryChangeItem> { SalaryChangeItems[0], SalaryChangeItems[1] }
        },
        new SalaryChangeRequest
        {
            Id = Guid.NewGuid(),
            EmployeeProfileId = Employees[1].Id,
            Status = SalaryChangeStatus.Submitted,
            RequestedByUserId = Users[12].Id,
            Reason = "Annual increment for Branch Manager",
            EffectiveFrom = DateOnly.FromDateTime(DateTime.Today.AddMonths(1)),
            CreatedAt = DateTime.UtcNow.AddDays(-5),
            UpdatedAt = DateTime.UtcNow.AddDays(-5),
            Items = new List<SalaryChangeItem> { SalaryChangeItems[2] }
        },
        new SalaryChangeRequest
        {
            Id = Guid.NewGuid(),
            EmployeeProfileId = Employees[10].Id,
            Status = SalaryChangeStatus.Approved,
            RequestedByUserId = Users[12].Id,
            ReviewedByUserId = Users[0].Id,
            Reason = "HR Chief promotion salary adjustment",
            EffectiveFrom = DateOnly.FromDateTime(DateTime.Today),
            ReviewedAtUtc = DateTime.UtcNow.AddDays(-2),
            CreatedAt = DateTime.UtcNow.AddDays(-15),
            UpdatedAt = DateTime.UtcNow.AddDays(-2),
            Items = new List<SalaryChangeItem>()
        }
    };

    public static List<SalarySlipSnapshot> SalarySlipSnapshots = new();

    public static List<PayrollRun> PayrollRuns = new()
    {
        new PayrollRun
        {
            Id = Guid.NewGuid(),
            PeriodStart = new DateOnly(2026, 1, 1),
            PeriodEnd = new DateOnly(2026, 1, 31),
            Status = PayrollRunStatus.Paid,
            CreatedByUserId = Users[12].Id,
            FinalizedAtUtc = DateTime.UtcNow.AddDays(-5),
            CreatedAt = DateTime.UtcNow.AddDays(-10),
            UpdatedAt = DateTime.UtcNow.AddDays(-5),
            SalarySlips = new List<SalarySlipSnapshot>()
        },
        new PayrollRun
        {
            Id = Guid.NewGuid(),
            PeriodStart = new DateOnly(2025, 12, 1),
            PeriodEnd = new DateOnly(2025, 12, 31),
            Status = PayrollRunStatus.Paid,
            CreatedByUserId = Users[12].Id,
            FinalizedAtUtc = DateTime.UtcNow.AddDays(-35),
            CreatedAt = DateTime.UtcNow.AddDays(-40),
            UpdatedAt = DateTime.UtcNow.AddDays(-35),
            SalarySlips = new List<SalarySlipSnapshot>()
        },
        new PayrollRun
        {
            Id = Guid.NewGuid(),
            PeriodStart = new DateOnly(2026, 2, 1),
            PeriodEnd = new DateOnly(2026, 2, 28),
            Status = PayrollRunStatus.Draft,
            CreatedByUserId = Users[12].Id,
            CreatedAt = DateTime.UtcNow.AddDays(-2),
            UpdatedAt = DateTime.UtcNow.AddDays(-2),
            SalarySlips = new List<SalarySlipSnapshot>()
        }
    };

    public static List<WeeklyRatingRevision> WeeklyRatingRevisions = new();

    public static List<WeeklyRating> WeeklyRatings = new()
    {
        new WeeklyRating
        {
            Id = Guid.NewGuid(),
            EmployeeProfileId = Employees[14].Id,
            WeekStartDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek)),
            CreatedByUserId = Users[6].Id,
            IsFinalized = false,
            CreatedAt = DateTime.UtcNow.AddDays(-2),
            UpdatedAt = DateTime.UtcNow.AddDays(-2),
            Revisions = new List<WeeklyRatingRevision>()
        },
        new WeeklyRating
        {
            Id = Guid.NewGuid(),
            EmployeeProfileId = Employees[15].Id,
            WeekStartDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek - 7)),
            CreatedByUserId = Users[6].Id,
            IsFinalized = true,
            CreatedAt = DateTime.UtcNow.AddDays(-9),
            UpdatedAt = DateTime.UtcNow.AddDays(-8),
            Revisions = new List<WeeklyRatingRevision>()
        },
        new WeeklyRating
        {
            Id = Guid.NewGuid(),
            EmployeeProfileId = Employees[16].Id,
            WeekStartDate = DateOnly.FromDateTime(DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek)),
            CreatedByUserId = Users[6].Id,
            IsFinalized = true,
            CreatedAt = DateTime.UtcNow.AddDays(-3),
            UpdatedAt = DateTime.UtcNow.AddDays(-1),
            Revisions = new List<WeeklyRatingRevision>()
        }
    };

    public static List<WorkScheduleAssignment> WorkScheduleAssignments = new();

    public static List<WorkSchedule> WorkSchedules = new()
    {
        new WorkSchedule
        {
            Id = Guid.NewGuid(),
            DepartmentId = Departments[0].Id,
            CreatedByUserId = Users[6].Id,
            Title = "Engineering Q1 Schedule",
            PeriodStart = new DateOnly(2026, 1, 1),
            PeriodEnd = new DateOnly(2026, 3, 31),
            Description = "Q1 work schedule for Engineering department",
            Status = WorkScheduleStatus.Approved,
            ApprovedByUserId = Users[1].Id,
            SubmittedAtUtc = DateTime.UtcNow.AddDays(-20),
            ApprovedAtUtc = DateTime.UtcNow.AddDays(-15),
            ScheduleDataJson = "{}",
            CreatedAt = DateTime.UtcNow.AddDays(-25),
            UpdatedAt = DateTime.UtcNow.AddDays(-15),
            Assignments = new List<WorkScheduleAssignment>()
        },
        new WorkSchedule
        {
            Id = Guid.NewGuid(),
            DepartmentId = Departments[1].Id,
            CreatedByUserId = Users[7].Id,
            Title = "Marketing Q1 Schedule",
            PeriodStart = new DateOnly(2026, 1, 1),
            PeriodEnd = new DateOnly(2026, 3, 31),
            Description = "Q1 work schedule for Marketing department",
            Status = WorkScheduleStatus.Submitted,
            SubmittedAtUtc = DateTime.UtcNow.AddDays(-5),
            ScheduleDataJson = "{}",
            CreatedAt = DateTime.UtcNow.AddDays(-10),
            UpdatedAt = DateTime.UtcNow.AddDays(-5),
            Assignments = new List<WorkScheduleAssignment>()
        },
        new WorkSchedule
        {
            Id = Guid.NewGuid(),
            DepartmentId = Departments[4].Id,
            CreatedByUserId = Users[8].Id,
            Title = "Engineering South Q1",
            PeriodStart = new DateOnly(2026, 1, 1),
            PeriodEnd = new DateOnly(2026, 3, 31),
            Description = "Q1 work schedule for South Engineering",
            Status = WorkScheduleStatus.Published,
            ApprovedByUserId = Users[2].Id,
            SubmittedAtUtc = DateTime.UtcNow.AddDays(-18),
            ApprovedAtUtc = DateTime.UtcNow.AddDays(-12),
            ScheduleDataJson = "{}",
            CreatedAt = DateTime.UtcNow.AddDays(-22),
            UpdatedAt = DateTime.UtcNow.AddDays(-12),
            Assignments = new List<WorkScheduleAssignment>()
        }
    };

    public static List<ComplaintMessage> ComplaintMessages = new();
    public static List<ComplaintAttachment> ComplaintAttachments = new();

    public static List<ComplaintCase> ComplaintCases = new()
    {
        new ComplaintCase
        {
            Id = Guid.NewGuid(),
            CreatedByEmployeeProfileId = Employees[14].Id,
            DepartmentId = Departments[0].Id,
            BranchId = Branches[0].Id,
            Subject = "Workplace Environment Issue",
            Description = "The air conditioning in the engineering office has been malfunctioning for two weeks.",
            Target = ComplaintTarget.HR,
            Category = ComplaintCategory.Policy,
            Severity = ComplaintSeverity.Medium,
            Status = ComplaintStatus.InReview,
            IsAnonymousToChief = false,
            AssignedToUserId = Users[10].Id,
            IsForwardedToBranchManager = false,
            CreatedAt = DateTime.UtcNow.AddDays(-5),
            UpdatedAt = DateTime.UtcNow.AddDays(-3),
            Messages = new List<ComplaintMessage>(),
            Attachments = new List<ComplaintAttachment>()
        },
        new ComplaintCase
        {
            Id = Guid.NewGuid(),
            CreatedByEmployeeProfileId = Employees[15].Id,
            DepartmentId = Departments[0].Id,
            BranchId = Branches[0].Id,
            Subject = "Equipment Request Delayed",
            Description = "Requested new laptop three months ago, still waiting for approval.",
            Target = ComplaintTarget.BranchManager,
            Category = ComplaintCategory.IT,
            Severity = ComplaintSeverity.High,
            Status = ComplaintStatus.Submitted,
            IsAnonymousToChief = false,
            AssignedToUserId = Users[6].Id,
            IsForwardedToBranchManager = true,
            ForwardedByUserId = Users[6].Id,
            ForwardedAtUtc = DateTime.UtcNow.AddDays(-2),
            ForwardingNotes = "Employee needs urgent equipment upgrade for project work.",
            CreatedAt = DateTime.UtcNow.AddDays(-10),
            UpdatedAt = DateTime.UtcNow.AddDays(-2),
            Messages = new List<ComplaintMessage>(),
            Attachments = new List<ComplaintAttachment>()
        },
        new ComplaintCase
        {
            Id = Guid.NewGuid(),
            CreatedByEmployeeProfileId = Employees[19].Id,
            DepartmentId = Departments[1].Id,
            BranchId = Branches[0].Id,
            Subject = "Salary Discrepancy",
            Description = "Last month's salary was calculated incorrectly.",
            Target = ComplaintTarget.HR,
            Category = ComplaintCategory.Payroll,
            Severity = ComplaintSeverity.Critical,
            Status = ComplaintStatus.Resolved,
            IsAnonymousToChief = false,
            AssignedToUserId = Users[12].Id,
            ClosedAtUtc = DateTime.UtcNow.AddDays(-1),
            CreatedAt = DateTime.UtcNow.AddDays(-8),
            UpdatedAt = DateTime.UtcNow.AddDays(-1),
            Messages = new List<ComplaintMessage>(),
            Attachments = new List<ComplaintAttachment>()
        }
    };

    public static List<AttendanceEvent> AttendanceEvents = new()
    {
        new AttendanceEvent
        {
            Id = Guid.NewGuid(),
            EmployeeProfileId = Employees[14].Id,
            Timestamp = DateTime.Today.AddHours(9),
            EventType = AttendanceEventType.CheckIn,
            VerificationMethod = VerificationMethod.FaceRecognition,
            DeviceId = "DEVICE001",
            LocationLabel = "North Branch - Main Entrance",
            CreatedAt = DateTime.Today.AddHours(9),
            UpdatedAt = DateTime.Today.AddHours(9)
        },
        new AttendanceEvent
        {
            Id = Guid.NewGuid(),
            EmployeeProfileId = Employees[15].Id,
            Timestamp = DateTime.Today.AddHours(8).AddMinutes(55),
            EventType = AttendanceEventType.CheckIn,
            VerificationMethod = VerificationMethod.FaceRecognition,
            DeviceId = "DEVICE001",
            LocationLabel = "North Branch - Main Entrance",
            CreatedAt = DateTime.Today.AddHours(8).AddMinutes(55),
            UpdatedAt = DateTime.Today.AddHours(8).AddMinutes(55)
        },
        new AttendanceEvent
        {
            Id = Guid.NewGuid(),
            EmployeeProfileId = Employees[16].Id,
            Timestamp = DateTime.Today.AddHours(9).AddMinutes(10),
            EventType = AttendanceEventType.CheckIn,
            VerificationMethod = VerificationMethod.FaceRecognition,
            DeviceId = "DEVICE001",
            LocationLabel = "North Branch - Main Entrance",
            CreatedAt = DateTime.Today.AddHours(9).AddMinutes(10),
            UpdatedAt = DateTime.Today.AddHours(9).AddMinutes(10)
        },
        new AttendanceEvent
        {
            Id = Guid.NewGuid(),
            EmployeeProfileId = Employees[14].Id,
            Timestamp = DateTime.Today.AddHours(12),
            EventType = AttendanceEventType.BreakStart,
            VerificationMethod = VerificationMethod.Manual,
            DeviceId = "DEVICE001",
            LocationLabel = "North Branch",
            CreatedAt = DateTime.Today.AddHours(12),
            UpdatedAt = DateTime.Today.AddHours(12)
        },
        new AttendanceEvent
        {
            Id = Guid.NewGuid(),
            EmployeeProfileId = Employees[14].Id,
            Timestamp = DateTime.Today.AddHours(13),
            EventType = AttendanceEventType.BreakEnd,
            VerificationMethod = VerificationMethod.Manual,
            DeviceId = "DEVICE001",
            LocationLabel = "North Branch",
            CreatedAt = DateTime.Today.AddHours(13),
            UpdatedAt = DateTime.Today.AddHours(13)
        },
        new AttendanceEvent
        {
            Id = Guid.NewGuid(),
            EmployeeProfileId = Employees[15].Id,
            Timestamp = DateTime.Today.AddHours(17),
            EventType = AttendanceEventType.CheckOut,
            VerificationMethod = VerificationMethod.FaceRecognition,
            DeviceId = "DEVICE001",
            LocationLabel = "North Branch - Main Entrance",
            CreatedAt = DateTime.Today.AddHours(17),
            UpdatedAt = DateTime.Today.AddHours(17)
        }
    };

    public static List<SessionLog> SessionLogs = new()
    {
        new SessionLog
        {
            Id = Guid.NewGuid(),
            UserId = Users[0].Id,
            LoginAt = DateTime.UtcNow.AddHours(-2),
            LogoutAt = null,
            IpAddress = "192.168.1.100",
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) Chrome/120.0",
            DeviceInfo = "Windows 10 Desktop",
            IsActive = true,
            CreatedAt = DateTime.UtcNow.AddHours(-2),
            UpdatedAt = DateTime.UtcNow.AddHours(-2)
        },
        new SessionLog
        {
            Id = Guid.NewGuid(),
            UserId = Users[1].Id,
            LoginAt = DateTime.UtcNow.AddHours(-4),
            LogoutAt = DateTime.UtcNow.AddHours(-1),
            IpAddress = "192.168.1.101",
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) Chrome/120.0",
            DeviceInfo = "Windows 11 Laptop",
            IsActive = false,
            CreatedAt = DateTime.UtcNow.AddHours(-4),
            UpdatedAt = DateTime.UtcNow.AddHours(-1)
        },
        new SessionLog
        {
            Id = Guid.NewGuid(),
            UserId = Users[6].Id,
            LoginAt = DateTime.UtcNow.AddHours(-3),
            LogoutAt = null,
            IpAddress = "192.168.1.102",
            UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) Safari/537.36",
            DeviceInfo = "MacBook Pro",
            IsActive = true,
            CreatedAt = DateTime.UtcNow.AddHours(-3),
            UpdatedAt = DateTime.UtcNow.AddHours(-3)
        },
        new SessionLog
        {
            Id = Guid.NewGuid(),
            UserId = Users[14].Id,
            LoginAt = DateTime.Today.AddHours(9),
            LogoutAt = null,
            IpAddress = "192.168.1.103",
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) Edge/120.0",
            DeviceInfo = "Windows 11 Desktop",
            IsActive = true,
            CreatedAt = DateTime.Today.AddHours(9),
            UpdatedAt = DateTime.Today.AddHours(9)
        }
    };

    public static List<AuditLog> AuditLogs = new()
    {
        new AuditLog
        {
            Id = Guid.NewGuid(),
            ActorUserId = Users[0].Id,
            ActorName = "admin",
            Action = AuditAction.Create,
            EntityType = "Branch",
            EntityId = Branches[0].Id,
            BranchId = Branches[0].Id,
            Description = "Created North Branch",
            IpAddress = "192.168.1.100",
            CreatedAt = DateTime.UtcNow.AddDays(-30),
            UpdatedAt = DateTime.UtcNow.AddDays(-30)
        },
        new AuditLog
        {
            Id = Guid.NewGuid(),
            ActorUserId = Users[0].Id,
            ActorName = "admin",
            Action = AuditAction.Update,
            EntityType = "User",
            EntityId = Users[1].Id,
            BranchId = Branches[0].Id,
            Description = "Updated user bm1 role",
            IpAddress = "192.168.1.100",
            CreatedAt = DateTime.UtcNow.AddDays(-25),
            UpdatedAt = DateTime.UtcNow.AddDays(-25)
        },
        new AuditLog
        {
            Id = Guid.NewGuid(),
            ActorUserId = Users[0].Id,
            ActorName = "admin",
            Action = AuditAction.Approve,
            EntityType = "SalaryChangeRequest",
            EntityId = SalaryChangeRequests[2].Id,
            BranchId = Branches[0].Id,
            EmployeeId = Employees[10].Id,
            Description = "Approved salary change for HR Chief",
            IpAddress = "192.168.1.100",
            CreatedAt = DateTime.UtcNow.AddDays(-2),
            UpdatedAt = DateTime.UtcNow.AddDays(-2)
        },
        new AuditLog
        {
            Id = Guid.NewGuid(),
            ActorUserId = Users[6].Id,
            ActorName = "chief1_eng",
            Action = AuditAction.Create,
            EntityType = "WorkSchedule",
            EntityId = WorkSchedules[0].Id,
            DepartmentId = Departments[0].Id,
            BranchId = Branches[0].Id,
            Description = "Created Q1 work schedule",
            IpAddress = "192.168.1.102",
            CreatedAt = DateTime.UtcNow.AddDays(-25),
            UpdatedAt = DateTime.UtcNow.AddDays(-25)
        },
        new AuditLog
        {
            Id = Guid.NewGuid(),
            ActorUserId = Users[1].Id,
            ActorName = "bm1",
            Action = AuditAction.Approve,
            EntityType = "WorkSchedule",
            EntityId = WorkSchedules[0].Id,
            DepartmentId = Departments[0].Id,
            BranchId = Branches[0].Id,
            Description = "Approved Q1 work schedule",
            IpAddress = "192.168.1.101",
            CreatedAt = DateTime.UtcNow.AddDays(-15),
            UpdatedAt = DateTime.UtcNow.AddDays(-15)
        }
    };
}
