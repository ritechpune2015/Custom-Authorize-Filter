namespace Custom_Authorize_Filter.ViewModels
{
    public class EmpCreateVM
    {
        public Int64 EmpID { get; set; }
        public string EmpName { get; set; }
        public string Address { get; set; }
        public string EmailID { get; set; }
        public decimal Basic { get; set; }
        public decimal TA { get; set; }
        public decimal HRA { get; set; }
        public Int64 CompanyID { get; set; }
    }
}
