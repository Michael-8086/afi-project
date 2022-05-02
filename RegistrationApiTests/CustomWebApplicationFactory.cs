using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RegistrationApi.Data;

namespace RegistrationApiTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<RegistrationApi.Controllers.RegistrationController>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IRegistrationApiRepository, MockRegistrationApiRepository>();
                // var descriptor = services.SingleOrDefault(
                //     d => d.ServiceType ==
                //         typeof(DbContextOptions<RegistrationApiContext>));

                // services.Remove(descriptor);

                // services.AddDbContext<RegistrationApiContext>(options =>
                // {
                //     options.UseInMemoryDatabase("InMemoryDbForTesting");
                // });

                // var sp = services.BuildServiceProvider();

                // using (var scope = sp.CreateScope())
                // {
                //     var scopedServices = scope.ServiceProvider;
                //     var db = scopedServices.GetRequiredService<RegistrationApiContext>();
                //     var logger = scopedServices
                //         .GetRequiredService<ILogger<CustomWebApplicationFactory>>();

                //     db.Database.EnsureCreated();
                //}
            });
        }
    }
}