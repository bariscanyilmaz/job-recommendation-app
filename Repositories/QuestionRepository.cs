using JobRecommendationApp.Models;

namespace JobRecommendationApp.Repositories
{
    public class QuestionRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public QuestionRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IQueryable<Question> GetAll()
        {
            return _appDbContext.Questions;
        }
    }
}