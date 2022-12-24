using JobRecommendationApp.Models;

namespace JobRecommendationApp.Repositories
{
    public class EntryRepository
    {
        private readonly ApplicationDbContext _appDbContext;

        public EntryRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Entry> AddAsync(Entry entry)
        {
            _appDbContext.Entries.Add(entry);
            await _appDbContext.SaveChangesAsync();
            return entry;
        }

        public IQueryable<Entry> GetAll()
        {
            return _appDbContext.Entries;
        }
    }
}