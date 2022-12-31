using JobRecommendationApp.Models;

namespace JobRecommendationApp.Repositories
{
    public class JobRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public JobRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IQueryable<Job> GetAll()
        {
            return _dbContext.Jobs;
        }
    }
}