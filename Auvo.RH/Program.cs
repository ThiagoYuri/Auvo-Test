using Auvo.RH.DAL;
using Auvo.RH.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ContextDb>(opt => opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
builder.Services.AddDbContext<ContextDb>(opt => opt.UseLazyLoadingProxies().UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Auvo;Data Source=THIAGOYURI;TrustServerCertificate=True"));

builder.Services.AddScoped<AnalisePontoServices, AnalisePontoServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/AnalisePonto/Error");
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
    pattern: "{controller=AnalisePonto}/{action=Index}/{id?}");


app.Run();
