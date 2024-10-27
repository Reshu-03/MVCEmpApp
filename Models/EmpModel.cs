using MVCEmp.Data;

namespace Employee.Models
{
    public class EmpModel
    {
        private readonly EmpDbContext _context;

        public EmpModel(EmpDbContext context)
        {
            _context = context;
        }

 public IEnumerable<MVCEmp.Data.Employee> GetEmployees()
{
    return _context.Employees.ToList(); 
}

        public void AddEmployee(int id, string name,  int deptno)
        {
            var existingEmployee = _context.Employees.Find(id);
            if (existingEmployee == null)
            {
                var newEmployee = new MVCEmp.Data.Employee
                {
                    Id = id,
                    EmployeeName = name,
              
                    DepartmentNo = deptno
                };
                _context.Employees.Add(newEmployee);
                _context.SaveChanges();
            }
        }
        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
        public void UpdateEmployee(MVCEmp.Data.Employee updatedEmployee)
        {
            var employee = _context.Employees.Find(updatedEmployee.Id);
            if (employee != null)
            {
                employee.EmployeeName = updatedEmployee.EmployeeName;
                employee.DepartmentNo = updatedEmployee.DepartmentNo;
                _context.SaveChanges();
            }
        }

       

        // public void AddDepartment(int id, string name)
        // {
        //     var existingDepartment = _context.Departments.Find(id);
        //     if (existingDepartment == null)
        //     {
        //         var newDepartment = new Department
        //         {
        //             Id = id,
        //             Name = name
        //         };
        //         _context.Departments.Add(newDepartment);
        //         _context.SaveChanges();
        //     }
        // }

    }
}
