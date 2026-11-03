using System.ComponentModel.DataAnnotations.Schema;

namespace Custom_Authorize_Filter.Models
{
    public class Company
    {
        public Int64 CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string EmailID { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
    }
}
