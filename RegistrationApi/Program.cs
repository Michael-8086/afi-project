using Microsoft.EntityFrameworkCore;
using RegistrationApi.Data;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        string sqlServer = Environment.GetEnvironmentVariable("SQL_SERVER");
        string sqlUser = Environment.GetEnvironmentVariable("SQL_USER");
        string sqlPassword = Environment.GetEnvironmentVariable("SQL_PASSWORD");

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddScoped<IRegistrationApiRepository, SqlRegistrationApiRepository>();
        builder.Services.AddDbContext<RegistrationApiContext>(options => options.UseSqlServer($"Server={sqlServer};User Id={sqlUser};Password={sqlPassword};" + builder.Configuration.GetConnectionString("RegistrationApiContext")));

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            using (var scope = app.Services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<RegistrationApiContext>();

                // Check if we are using an in-memory database
                if (dataContext.Database.IsRelational())
                {
                    dataContext.Database.Migrate();
                }
            }
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
