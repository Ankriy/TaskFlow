
using business.DAL.EF;
using business.DAL.EF.Repositories;
using business.Logic.DataContracts.Repositories.Customers;
using business.Logic.Services;
using business.PostgresMigrate;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<PostgreeContext>(opt =>
//    opt.UseNpgsql(builder.Configuration.GetConnectionString("Db")));

//builder.Services.AddAuthentication(opt =>
//{
//    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    //options.DefaultScheme = Options.DefaultAuthScheme;
//    //options.DefaultChallengeScheme = Options.DefaultAuthScheme;
//})
//    .AddJwtBearer(/*"Bearer",*/ options =>
//    {
//        //options.SaveToken = true;
//        //options.RequireHttpsMetadata = false;
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = false /*true*/,
//            ValidateAudience = false /*true*/,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            //ClockSkew = TimeSpan.Zero,

//            ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
//            ValidAudience = builder.Configuration["Jwt:ValidAudience"],
//            IssuerSigningKey = new SymmetricSecurityKey(
//                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!))
//        };
//    });
//.AddPolicyScheme(Options.DefaultAuthScheme, Options.DefaultAuthScheme, options =>
//{
//    options.ForwardDefaultSelector = context =>
//    {
//        string authorization = context.Request.Headers[HeaderNames.Authorization];
//        if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer "))
//            return JwtBearerDefaults.AuthenticationScheme;

//        return IdentityConstants.ApplicationScheme;
//    };
//});
//builder.Services.AddAuthorization(options => options.DefaultPolicy =
//    new AuthorizationPolicyBuilder
//            (JwtBearerDefaults.AuthenticationScheme)
//        .RequireAuthenticatedUser()
//        .Build());
//builder.Services.AddIdentity<ApplicationUser, IdentityRole<long>>()
//    .AddEntityFrameworkStores<PostgreeContext>()
//    .AddUserManager<UserManager<ApplicationUser>>()
//    .AddSignInManager<SignInManager<ApplicationUser>>();

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

app.UseAuthentication();
app.UseAuthorization();
//app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authorization}/{action=Authorization}/{id?}");

app.Run();
