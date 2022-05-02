using Microsoft.EntityFrameworkCore;
using RegistrationApi.Models;

namespace RegistrationApi.Data
{
    public class RegistrationApiContext : DbContext
    {
        public RegistrationApiContext(DbContextOptions<RegistrationApiContext> options) : base(options)
        {
        }

        public DbSet<PolicyHolder> PolicyHolders { get; set; }
    }
}