using Microsoft.AspNetCore.Mvc;
using Employee.Models;

namespace MVCEmp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmpModel _empModel;

        public EmployeeController(EmpModel empModel)
        {
            _empModel = empModel;
        }

        public IActionResult Index()
        {
            var employees = _empModel.GetEmployees(); 
            return View(employees); 
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Data.Employee employee)
        {
            if (ModelState.IsValid)
            {
                _empModel.AddEmployee(employee.Id, employee.EmployeeName, employee.DepartmentNo);
                return RedirectToAction(nameof(Index)); 
            }
            return View(employee); 
        }
        // DELETE: Remove Employee
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Delete(int id)
            {
                _empModel.DeleteEmployee(id);
                return RedirectToAction(nameof(Index)); // Redirect to Index after deletion
            }
                                // GET: Edit Employee
                public IActionResult Edit(int id)
                {
                    var employee = _empModel.GetEmployees().FirstOrDefault(e => e.Id == id);
                    if (employee == null)
                    {
                        return NotFound();
                    }
                    return View(employee); // Pass the employee to the Edit view
                }

                // POST: Update Employee
                [HttpPost]
                [ValidateAntiForgeryToken]
                public IActionResult Edit(Data.Employee employee)
                {
                    if (ModelState.IsValid)
                    {
                        _empModel.UpdateEmployee(employee);
                        return RedirectToAction(nameof(Index)); // Redirect to Index after update
                    }
                    return View(employee); // Return the view with the employee data if model state is invalid
                }


    }
}
