using ToDoList.Application;
using ToDoList.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoListStrider.Application;
using ToDoListStrider.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSession(); 
builder.Services.AddDistributedMemoryCache(); 
builder.Services.AddControllersWithViews(); 
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddSingleton<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<IToDoService, ToDoService>();


var app = builder.Build();


app.UseSession();
app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "account",
        pattern: "Account/{action=Login}");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.MapControllerRoute(
    name: "account",
    pattern: "{controller=Account}/{action=Login}");

app.UseDeveloperExceptionPage();

app.Run();