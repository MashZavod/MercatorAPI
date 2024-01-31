using MercatorAPI.Data;
using MercatorAPI.Modules.Interface;
using MercatorAPI.Services;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main()
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();
        
        builder.Services.AddTransient<ICarHolder, CarHolderService>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors(options => // Allow requests from address
        {
            options.AddPolicy(name: "AllowSpecificOrigins", policy =>
            {
                policy.WithOrigins("https://localhost:5173", "http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
            });
        });
        builder.Services.AddDbContext<CarDataContext>(option => option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // PostgreSQL connection
        WebApplication app = builder.Build();

        app.UseDefaultFiles();
        app.UseStaticFiles();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        app.UseCors("AllowSpecificOrigins");
        app.UseStaticFiles();

        app.UseAuthorization();

        app.MapControllers();

        app.MapFallbackToFile("/index.html");

        app.Run();
    }
}