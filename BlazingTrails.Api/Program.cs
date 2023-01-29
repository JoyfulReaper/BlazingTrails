using BlazingTrails.Api.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    builder.Services.AddDbContext<BlazingTrailsContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("BlazingTrailsContext"));
    });
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseWebAssemblyDebugging();
    }

    app.UseHttpsRedirection();

    app.UseBlazorFrameworkFiles();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();
    
    app.MapControllers();
    app.MapFallbackToFile("index.html");

    app.Run();
}