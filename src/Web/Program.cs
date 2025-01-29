using Microsoft.EntityFrameworkCore;
using MouseTracker.Application;
using MouseTracker.Data;
using MouseTracker.Data.Engine;
using MouseTracker.Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// Для примера, чтобы тестировать работу фронта и бекенда по отдельности, разрешаем запросы с любого источника
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy => 
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
});

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddContext();

builder.Services.AddRepositories();

builder.Services.AddBusinessServices();

var app = builder.Build();

app.UseExceptionHandler();

app.UseCors();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

app.Run();