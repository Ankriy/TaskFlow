using business.DAL.EF;
using business.DAL.EF.Repositories;
using business.Logic.DataContracts.Repositories.Customers;
using business.Logic.Services;
using business.PostgresMigrate;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<CustomerListService>();
builder.Services.AddScoped<ICustomerRepository, EFCustomerRepository>();

var connectionStringEF = "host=localhost; port=5432; database=business; username=postgres; password=123;";  //builder.Configuration.GetConnectionString("NpgsqlConnectionString");
PostgresMigrator.Migrate(connectionStringEF);

builder.Services.AddDbContext<PostgreeContext>(
    options => {
        options.UseNpgsql(connectionStringEF);
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Dashboard}/{id?}");

app.Run();
