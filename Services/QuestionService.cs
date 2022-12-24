using JobRecommendationApp.Models;
using JobRecommendationApp.Repositories;

namespace JobRecommendationApp.Services
{
    public class QuestionService
    {
        private readonly QuestionRepository _questionRepository;
        public QuestionService(QuestionRepository questionRepository)
        {
            _questionRepository=questionRepository;
        }

        public IQueryable<Question> GetAll(){
            return _questionRepository.GetAll();
        }
    }
}