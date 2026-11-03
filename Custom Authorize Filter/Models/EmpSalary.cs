namespace Custom_Authorize_Filter.Models
{
    public class EmpSalary
    {
        public Int64 EmpSalaryID { get; set; }
        public Int64 EmpID { get; set; }
        public virtual Emp Emp { get; set; }
        public decimal Basic { get; set; }
        public decimal TA { get; set; }
        public decimal HRA { get; set; }
    }
}
