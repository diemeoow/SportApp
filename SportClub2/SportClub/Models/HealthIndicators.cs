using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("health_indicators")]
    public class HealthIndicators
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("health_group")]
        public string HealthGroup { get; set; }

        [Column("restrictions")]
        public string Restrictions { get; set; }

        [Column("valid_to")]
        public DateTime? ValidTo { get; set; }
    }
}
