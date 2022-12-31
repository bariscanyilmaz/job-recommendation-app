using JobRecommendationApp.Models;
using JobRecommendationApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobRecommendationApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController:ControllerBase
    {
        private readonly QuestionService _questionService;
        private readonly EntryService _entryService;
        private readonly JobService _jobService;

        public HomeController(QuestionService questionService,EntryService entryService,JobService jobService)
        {
            _questionService=questionService;
            _entryService=entryService;
            _jobService=jobService;
        }

        [HttpGet("[action]")]
        public IQueryable<Question> Questions(){
            return _questionService.GetAll();
        }

        
        [HttpPost("[action]")]
        public async Task<Entry> AddEntryAsync([FromBody]Entry entry){
            await _entryService.AddAsync(entry);
            return entry;
        }

        [HttpGet("[action]")]
        public IQueryable<Job> Jobs(){
            return _jobService.GetAll();           
        }
    }


}