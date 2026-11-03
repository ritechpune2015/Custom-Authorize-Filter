using Custom_Authorize_Filter.Models;
using Custom_Authorize_Filter.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Custom_Authorize_Filter.Repositories
{
    public class EmpRepo : IEmpRepo
    {
        CompanyContext cntx;
        public EmpRepo(CompanyContext _cntx)
        {
            cntx = _cntx;
        }
        public async Task<List<EmpListVM>> GetAll(Int64 CompanyID)
        {
            //var res = from t in this.cntx.Emps
            //          where t.CompanyID == CompanyID
            //          select new EmpListVM
            //          {
            //              EmpName = t.EmpName,
            //              EmpID = t.EmpID,
            //              Address = t.Address,
            //              EmailID = t.EmailID,
            //              TotalSalary = t.EmpSalaries.Sum(p=>p.TA + p.HRA + p.Basic)
            //          };

            var res= from t in this.cntx.Emps
                     join s in this.cntx.EmpSalariess
                     on t.EmpID equals s.EmpID
                     where t.CompanyID == CompanyID
                     select new EmpListVM
                     {
                         EmpID = t.EmpID,
                         EmpName = t.EmpName,
                         Address = t.Address,
                         EmailID = t.EmailID,
                         TotalSalary = s.TA + s.HRA + s.Basic
                     };
            return await res.ToListAsync();
        }

        public async Task Insert(EmpCreateVM rec)
        {
            // insert emp
             Emp emp = new Emp();
             emp.EmpName = rec.EmpName;
             emp.Address = rec.Address;
             emp.EmailID = rec.EmailID;
             emp.CompanyID = rec.CompanyID;

            // insert emp salary 
            EmpSalary empSal = new EmpSalary();
            empSal.Basic = rec.Basic;
            empSal.TA= rec.TA;
            empSal.HRA = rec.HRA;

            emp.EmpSalaries.Add(empSal);
            this.cntx.Emps.Add(emp); 
              this.cntx.EmpSalariess.Add(empSal);
            await this.cntx.SaveChangesAsync();
        }
    }
}
