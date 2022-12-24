using JobRecommendationApp.Models;
using JobRecommendationApp.Repositories;

namespace JobRecommendationApp.Services
{
    public class EntryService
    {
        private readonly EntryRepository _entryRepository;

        public EntryService(EntryRepository entryRepository)
        {
            _entryRepository=entryRepository;
        }

        public async Task<Entry> AddAsync(Entry entry)
        {
            await _entryRepository.AddAsync(entry);
            return entry;
        }
    }
}