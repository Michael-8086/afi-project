using System.Data.Common;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RegistrationApi.Data;

namespace RegistrationApiTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var dbContextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                         typeof(DbContextOptions<RegistrationApiContext>));

                if (dbContextDescriptor != null) services.Remove(dbContextDescriptor);

                var dbConnectionDescriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                         typeof(DbConnection));

                if (dbConnectionDescriptor != null) services.Remove(dbConnectionDescriptor);

                // Add DbContext with In-Memory database for testing
                services.AddDbContext<RegistrationApiContext>(options =>
                    options.UseInMemoryDatabase("InMemoryDatabase"));
            });
        }
    }
}
