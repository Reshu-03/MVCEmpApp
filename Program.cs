using MVCEmp.Data;
using Microsoft.EntityFrameworkCore;
using Employee.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EmpDbContext>(options =>
    options.UseSqlite("Data Source=emp_37.db"));

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<EmpModel>();
builder.Logging.AddConsole(); 

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
