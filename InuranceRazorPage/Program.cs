using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using InuranceRazorPage.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/Denied";
    });
builder.Services.AddDbContext<InuranceRazorPageContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefualtConnection")));

builder.Services.AddRazorPages(options =>
{
    //options.Conventions.AuthorizePage("/Contact");
    options.Conventions.AuthorizeFolder("/Accounts");
    //options.Conventions.AllowAnonymousToPage("/Private/PublicPage");
    //options.Conventions.AllowAnonymousToFolder("/Private/PublicPages");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
