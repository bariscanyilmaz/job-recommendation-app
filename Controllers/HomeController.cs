using JobRecommendationApp.Models;
using JobRecommendationApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobRecommendationApp.Controllers
{
    [Route("[controller]")]
    public class HomeController:ControllerBase
    {
        private readonly QuestionService _questionService;
        private readonly EntryService _entryService;

        public HomeController(QuestionService questionService,EntryService entryService)
        {
            _questionService=questionService;
            _entryService=entryService;
        }

        [HttpGet("[action]")]
        public IQueryable<Question> Index(){
            return _questionService.GetAll();
        }

        
        [HttpPost("[action]")]
        public async Task<Entry> AddEntryAsync([FromBody]Entry entry){
            await _entryService.AddAsync(entry);
            return entry;
        }

    }


}