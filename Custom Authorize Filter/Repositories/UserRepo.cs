using Custom_Authorize_Filter.Models;
using Custom_Authorize_Filter.ViewModels;

namespace Custom_Authorize_Filter.Repositories
{
    public class UserRepo : IUser
    {
        CompanyContext cc;
        public UserRepo(CompanyContext cc)
        {
            this.cc = cc;
        }
        public async Task<LoginResultVM> Login(LoginVM rec)
        {
            LoginResultVM res = new LoginResultVM();
            var urec= this.cc.Companies.SingleOrDefault(p=>p.EmailID== rec.EmailID && p.Password==rec.Password);
            if (urec != null)
            {
                //loggedin 
                res.IsLoggedIn = true;
                res.LoggedInUserID = urec.CompanyID;
                // res.FullName = urec.FirstName+" "+urec.LastName;
                res.FullName = urec.CompanyName;
            }
            else
            {
                res.IsLoggedIn = false;
                res.ProblemMesssage = "Invalid Email Id or Password!";
            }
            return res;
        }

        public async Task<bool> Register(Company rec)
        {
            await this.cc.Companies.AddAsync(rec);
            await this.cc.SaveChangesAsync();
            return true;    
        }
    }
}
