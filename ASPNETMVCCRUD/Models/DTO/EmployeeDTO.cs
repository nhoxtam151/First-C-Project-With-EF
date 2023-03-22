namespace ASPNETMVCCRUD.Models.DTO
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public decimal Salary { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }

        public EmployeeDTO()
        {
        }

        public EmployeeDTO(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            Email = employee.Email;
            Salary = employee.Salary;
            DateOfBirth = employee.DateOfBirth;
            Department = employee.Department;
        }
    }
}
