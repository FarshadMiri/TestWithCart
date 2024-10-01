using Microsoft.AspNetCore.Identity;
using TestWithValue.Application.profile;
using TestWithValue.Data;
using TestWithValue.Data.SeedData;
using TestWithValue.Infrastructure.IOC;
using TestWithValue.Web.HubSupport;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistenceServices(builder.Configuration);
//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(MappingProfile));



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {
    //  ‰Ÿ?„«  —« «?‰Ã« «‰Ã«„ œÂ?œ
})
.AddEntityFrameworkStores<TestWithValueDbContext>()
.AddDefaultTokenProviders();

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

app.UseEndpoints(async endpoints =>
{
     endpoints.MapHub<SupportHub>("/supportHub");
    endpoints.MapDefaultControllerRoute();
});
app.UseAuthentication();    
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await IdentitySeedData.Initialize(services, userManager, roleManager);
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
