using BuberDinner.Application.Common.Interfaces.Persistence;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

public class DinnerRepository : IDinnerRepository
{
    private readonly BuberDinnerDbContext _dbContext;

    public DinnerRepository(BuberDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}
