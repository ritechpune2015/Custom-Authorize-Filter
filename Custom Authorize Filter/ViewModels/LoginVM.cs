using System.ComponentModel.DataAnnotations;

namespace Custom_Authorize_Filter.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Email ID Required")]
        [EmailAddress(ErrorMessage ="Invalid Email ID")]
        public string   EmailID { get; set; }

        [Required(ErrorMessage ="Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
