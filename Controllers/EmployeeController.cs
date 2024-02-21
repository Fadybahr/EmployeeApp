using Microsoft.AspNetCore.Mvc;
using EmployeeApp.Models;
namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        HRDatabaseContext dbContext= new HRDatabaseContext();

        public IActionResult Index(string SearchByName)
        {
            var employees =GetEmployees();
           
            if (!string.IsNullOrEmpty(SearchByName))
            {
                employees =employees.Where(e =>e.EmployeeName.ToLower().Contains(SearchByName.ToLower())).ToList();
                
            }

            return View(employees);

        }

        public List<Employee> GetEmployees()
        {
            var emp =
                            (from employee in dbContext.Employees
                             join deparment in dbContext.Department on employee.DepartmentId equals deparment.DepartmentId
                             select new Employee
                             {
                                 EmployeeId = employee.EmployeeId,
                                 EmployeeName = employee.EmployeeName,
                                 EmployeeNumber = employee.EmployeeNumber,
                                 DOB = employee.DOB,
                                 HiringDate = employee.HiringDate,
                                 GrossSalary = employee.GrossSalary,
                                 NetSalary = employee.NetSalary,
                                 DepartmentId = employee.DepartmentId,
                                 DepartmentName = deparment.DepartmentName,

                             }
                            ).ToList();

            return emp;
        }

        public IActionResult Create()
        {
            ViewBag.Departments = this.dbContext.Department.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee e) 
        {
            ModelState.Remove("EmployeeId");
            ModelState.Remove("DepartmentName");
            ModelState.Remove("Department");


            if (ModelState.IsValid)
            {
                dbContext.Employees.Add(e);
                dbContext.SaveChanges();
                return  RedirectToAction("Index");
            }
            ViewBag.Departments = this.dbContext.Department.ToList();
            return View();

        }
        public IActionResult Edit(int id) 
        {
            
           Employee emp = this.dbContext.Employees.Where(e=>e.EmployeeId==id).FirstOrDefault();
            ViewBag.Departments = this.dbContext.Department.ToList();
            return View("Create", emp);
        }
        [HttpPost]
        public IActionResult Edit(Employee e)
        {
            ModelState.Remove("EmployeeId");
            ModelState.Remove("DepartmentName");
            ModelState.Remove("Department");


            if (ModelState.IsValid)
            {
                dbContext.Employees.Update(e);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = this.dbContext.Department.ToList();
            return View("Create", e);

        }
        public IActionResult Delete(int id) 
        {
            Employee emp = this.dbContext.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
            if (emp != null)
            {
                dbContext.Employees.Remove(emp);
                dbContext.SaveChanges();
            }
           return RedirectToAction("Index");

        }
        
        }
    }

