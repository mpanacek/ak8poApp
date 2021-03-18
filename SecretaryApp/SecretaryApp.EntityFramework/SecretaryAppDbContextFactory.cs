using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SecretaryApp.EntityFramework
{
    class SecretaryAppDbContextFactory : IDesignTimeDbContextFactory<SecretaryAppDbContext>
    {
        public SecretaryAppDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<SecretaryAppDbContext>();
            options.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = SecretaryApp; Trusted_Connection = True;");

            return new SecretaryAppDbContext(options.Options);
        }
    }
}
