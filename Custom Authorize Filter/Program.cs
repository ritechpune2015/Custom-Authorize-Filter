using Custom_Authorize_Filter.CustFilter;
using Custom_Authorize_Filter.Models;
using Custom_Authorize_Filter.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//builder.Services.AddControllersWithViews(opt=>opt.Filters.Add(new UserAuth()));

builder.Services.AddDbContextPool<CompanyContext>(
     options=> options.UseSqlServer(builder.Configuration.GetConnectionString("scon"))
    );
builder.Services.AddScoped<IProduct, ProductRepo>();
builder.Services.AddScoped<IEmpRepo, EmpRepo>();
builder.Services.AddScoped<IUser,UserRepo>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(opt => {
    //20 minutes
    opt.IdleTimeout = TimeSpan.FromMinutes(10);
    opt.Cookie.IsEssential = true;
    opt.Cookie.HttpOnly = true;
});

var app = builder.Build();
app.UseSession();
app.MapControllerRoute(name:"area",pattern:"{area:exists}/{controller=UserHome}/{action=Index}");
//app.MapDefaultControllerRoute();
app.MapControllerRoute(name: "default", pattern: "{controller=ManageUsers}/{action=Login}");
app.Run();
