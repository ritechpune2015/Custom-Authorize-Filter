using System.Reflection.Metadata.Ecma335;

namespace Custom_Authorize_Filter.Models
{
    public class Emp
    {
        public Int64 EmpID { get; set; }
        public string EmpName { get; set; }
        public string Address { get; set; }
        public string EmailID { get; set; }
        public Int64 CompanyID { get; set; }
        public virtual List<EmpSalary> EmpSalaries { get; set; }
        public Emp()
        { 
          EmpSalaries = new List<EmpSalary>();  
        }

    }
}
