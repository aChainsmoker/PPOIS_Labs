
using Microsoft.EntityFrameworkCore;
using TrainScheduler.DatabaseControl;

namespace TrainScheduler.Model;

public class TrainListModel
{
    private TrainContext _dbContext;

    public DbSet<TrainModel> Trains { get => _dbContext.Trains; set => _dbContext.Trains = value; }
    public TrainContext DbContext => _dbContext;

    public TrainListModel(string dbPath)
    {
        _dbContext = new TrainContext(dbPath);
        _dbContext.Database.EnsureCreated();
    }
}
