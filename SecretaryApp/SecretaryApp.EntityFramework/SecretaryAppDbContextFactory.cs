using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SecretaryApp.EntityFramework
{
    public class SecretaryAppDbContextFactory : IDesignTimeDbContextFactory<SecretaryAppDbContext>
    {
        public SecretaryAppDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<SecretaryAppDbContext>();
            options.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = SecretaryTestDb; Trusted_Connection = True;");

            return new SecretaryAppDbContext(options.Options);
        }
    }
}
