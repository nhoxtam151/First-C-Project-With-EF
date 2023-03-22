using ASPNETMVCCRUD.Data;
using ASPNETMVCCRUD.Models;
using ASPNETMVCCRUD.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVCCRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;

        public EmployeesController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await mvcDemoDbContext.Employees.ToListAsync();

            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpGet]
        public async Task Test()
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeDTO employeeDTO)
        {
            var employee = new Employee(employeeDTO);

            await mvcDemoDbContext.Employees.AddAsync(employee);
            await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await mvcDemoDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee != null)
            {
                var employeeDTO = new EmployeeDTO(employee);
                return View(employee);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeDTO employeeDTO)
        {

            var employee = await mvcDemoDbContext.Employees.FindAsync(employeeDTO.Id);

            if (employee != null)
            {
                employee.Name = employeeDTO.Name;
                employee.Email = employeeDTO.Email;
                employee.DateOfBirth = employeeDTO.DateOfBirth;
                employee.Salary = employeeDTO.Salary;
                employee.Department = employeeDTO.Department;
                await mvcDemoDbContext.SaveChangesAsync();
                
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeDTO employeeDTO)
        {
            Employee employee = await mvcDemoDbContext.Employees.FindAsync(employeeDTO.Id);

            if (employee != null)
            {
                mvcDemoDbContext.Employees.Remove(employee);
                await mvcDemoDbContext.SaveChangesAsync();
            }
            
            return RedirectToAction("Index"); 
        }
    }
}
