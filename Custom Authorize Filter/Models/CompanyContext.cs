using Microsoft.EntityFrameworkCore;

namespace Custom_Authorize_Filter.Models
{
    public class CompanyContext:DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options):base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Emp> Emps { get; set; }
        public DbSet<EmpSalary> EmpSalariess { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                 new Company { CompanyID = 1, CompanyName = "ABC Corp", Address = "123 Street", EmailID = "info@abccorp.com", MobileNo = "1234567890",Password="abcd" }
                );  

         
        }
    }
}
