using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ZeroSum.Extend.EFCore.MySql.EntityFrameworks;

namespace Blog.EFCore.Migrations;

public class DbContextFactory : IDesignTimeDbContextFactory<ZeroSumDbContext>
{
    public ZeroSumDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ZeroSumDbContext>();
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 25));
        optionsBuilder.UseMySql(
            args[0],
            serverVersion,
            b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)
        );

        return new ZeroSumDbContext(optionsBuilder.Options);
    }
}