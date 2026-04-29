namespace SchedaVisite.Services.database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class AppDbFactory : IDesignTimeDbContextFactory<AppDb>
{
    public AppDb CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<AppDb>()
            .UseSqlite("Data Source=design.db") // used ONLY at design time
            .Options;

        return new AppDb(options);
    }
}