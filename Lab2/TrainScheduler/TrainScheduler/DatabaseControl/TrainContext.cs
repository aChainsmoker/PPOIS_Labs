using Microsoft.EntityFrameworkCore;
using TrainScheduler.Model;

namespace TrainScheduler.DatabaseControl;

public  class TrainContext : DbContext
{
    private string _dbPath;

    public DbSet<TrainModel> Trains { get; set; }

    public TrainContext(string dbPath)
    {
        _dbPath = dbPath;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={_dbPath}");
}
