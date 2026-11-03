namespace Custom_Authorize_Filter.Models
{
    public class Product
    {
        public Int64 ProductID { get; set; }
        public string ProductName { get; set; }
        public string MfgName { get; set; }
        public decimal Price { get; set; }
        public Int64 CompanyID { get; set; }
        public virtual Company? Company { get; set; }
    }
}
