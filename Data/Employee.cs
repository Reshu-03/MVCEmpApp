using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEmp.Data
{
    [Table("employe")]
    public class Employee
    {
        [Column("empno")]
        public int Id { get; set; }

        [Column("ename")]
        public string EmployeeName { get; set; } = string.Empty;
        
        // [Column("sal")]
        // public int Salary { get; set; }

        [Column("deptno")]
        public int DepartmentNo { get; set; }
    }
}
