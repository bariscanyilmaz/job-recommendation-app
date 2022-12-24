namespace JobRecommendationApp.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public decimal Realistic { get; set; }
        public decimal Investigation { get; set; }
        public decimal Artistic { get; set; }
        public decimal Social { get; set; }
        public decimal Enterprising  { get; set; }
        public decimal Conventional { get; set; }
        public bool IsSatisfied { get; set; }
    }    
}