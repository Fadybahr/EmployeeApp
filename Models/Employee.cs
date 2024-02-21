using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Models
{
    [Table("Employee", Schema = "dbo")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }

        [Required]
        [Column(TypeName = "varchar(5)")]
        [MaxLength(5)]
        [Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        [MaxLength(100)]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]

        public DateTime DOB { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hiring Date")]
        [DisplayFormat (DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime HiringDate { get; set; }


        [Required]
        [Column(TypeName ="decimal(12,2)")]
        [Display(Name ="Gross Salary")]
        public Decimal GrossSalary { get; set; }


        [Required]
        [Column(TypeName = "decimal(12,2)")]
        [Display(Name = "Net Salary")]
        public Decimal NetSalary { get; set; }



        [ForeignKey("Department")]
        [Required]
        public int DepartmentId { get; set; }

        [Display(Name ="Department")]
        [NotMapped] // mean it will be execluded through generating the database cuz it is generated in model department
        public string DepartmentName { get; set; }


        public virtual Department department { get; set; }


    }


}
