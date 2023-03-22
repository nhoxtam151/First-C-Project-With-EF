using ASPNETMVCCRUD.Data;
using ASPNETMVCCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ASPNETMVCCRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MVCDemoDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, MVCDemoDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {   
            LoadSampleData();
            /*var employees =
                _dbContext.Employee
                            .Include(a => a.Addresses)
                            .Include(a => a.City)
                            .ToList();               use this for fetch data from others table  */
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void LoadSampleData()
        {
            if(_dbContext.Employees.Count() == 0)
            {
                var file = System.IO.File.ReadAllText("employees.json");
                var people = System.Text.Json.JsonSerializer.Deserialize<List<Employee>>(file);
                _dbContext.AddRange(people);
                _dbContext.SaveChanges();
            }
        }
    }
}