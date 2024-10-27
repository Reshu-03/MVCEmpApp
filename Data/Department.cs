using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEmp.Data
{
    [Table("dept")]
    public class Department
    {
        [Column("deptno")]
        public int Id { get; set; }

        [Column("dname")]
        public string Name { get; set; } = string.Empty;
    }
}
