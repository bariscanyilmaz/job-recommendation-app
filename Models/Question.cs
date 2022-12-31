using System.ComponentModel.DataAnnotations.Schema;

namespace JobRecommendationApp.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
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