using System.ComponentModel.DataAnnotations.Schema;

namespace JobRecommendationApp.Models
{

    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(2,1)")]
        public decimal Realistic { get; set; }
        [Column(TypeName = "decimal(2,1)")]
        public decimal Investigation { get; set; }
        [Column(TypeName = "decimal(2,1)")]
        public decimal Artistic { get; set; }
        [Column(TypeName = "decimal(2,1)")]
        public decimal Social { get; set; }
        [Column(TypeName = "decimal(2,1)")]
        public decimal Enterprising { get; set; }
        [Column(TypeName = "decimal(2,1)")]
        public decimal Conventional { get; set; }
    }
}