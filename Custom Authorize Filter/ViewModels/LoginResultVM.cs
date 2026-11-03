using System.Net.Sockets;

namespace Custom_Authorize_Filter.ViewModels
{
    public class LoginResultVM
    {
        public Int64 LoggedInUserID { get; set; }
        public bool IsLoggedIn { get; set; }
        public string FullName { get; set; }
        public string ProblemMesssage { get; set; }
    }
}
