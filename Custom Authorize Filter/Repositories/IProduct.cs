using Custom_Authorize_Filter.Models;

namespace Custom_Authorize_Filter.Repositories
{
    public interface IProduct
    {
        Task<List<Product>> GetAll(Int64 CompanyID);
        Task<Product> GetByID(Int64 ID);
        Task Insert(Product product);
        Task Update(Product product);
        Task Delete(Int64 ID);


    }
}
