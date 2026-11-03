using Custom_Authorize_Filter.ViewModels;

namespace Custom_Authorize_Filter.Repositories
{
    public interface IEmpRepo
    {
        Task<List<EmpListVM>> GetAll(Int64 CompanyID);   
        Task Insert(EmpCreateVM rec);
    }
}
