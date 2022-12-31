using JobRecommendationApp.Models;
using JobRecommendationApp.Repositories;

namespace JobRecommendationApp.Services
{
    public class JobService
    {
        private readonly JobRepository _jobRepository;
        public JobService(JobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }


        public IQueryable<Job> GetAll()
        {
            return _jobRepository.GetAll();
        }

    }
}