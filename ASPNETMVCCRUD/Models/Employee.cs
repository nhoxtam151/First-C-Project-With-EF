using ASPNETMVCCRUD.Data;
using ASPNETMVCCRUD.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace ASPNETMVCCRUD.Models
{
    public class Employee
    {

        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        public decimal Salary { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        public string Department { get; set; }

        public Employee()
        {
        }

        public Employee(EmployeeDTO employeeDTO)
        {
            Id = Guid.NewGuid(); // becausee employeeDTO dont have Id
            Name = employeeDTO.Name;
            Email = employeeDTO.Email;
            Salary = employeeDTO.Salary;
            DateOfBirth = employeeDTO.DateOfBirth;
            Department = employeeDTO.Department;
        }

        
    }
}
