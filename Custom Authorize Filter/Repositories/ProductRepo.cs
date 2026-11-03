using Custom_Authorize_Filter.Models;
using Microsoft.EntityFrameworkCore;

namespace Custom_Authorize_Filter.Repositories
{
    public class ProductRepo : IProduct
    {
        CompanyContext cc;
        public ProductRepo(CompanyContext _cc)
        {
            cc = _cc;
        }
        public async Task Delete(long ID)
        {
            var res = this.cc.Products.Find(ID);
            this.cc.Products.Remove(res);
            await this.cc.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAll(Int64 cid)
        {
           return await this.cc.Products.Where(p=>p.CompanyID==cid).ToListAsync();   
        }

        public async Task<Product> GetByID(long ID)
        {
            return await this.cc.Products.FindAsync(ID);
        }

        public async Task Insert(Product product)
        {
            this.cc.Products.Add(product);
            await this.cc.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            this.cc.Update(product);
            await this.cc.SaveChangesAsync();   
        }
    }
}
