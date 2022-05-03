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
            });
        }
    }
}
