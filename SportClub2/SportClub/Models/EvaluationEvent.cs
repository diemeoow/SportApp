using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("evaluation_event")]
    public class EvaluationEvent
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("event_id")]
        public int? EventId { get; set; }

        [Column("app_user_id")]
        public int? AppUserId { get; set; }

        [Column("appraisal")]
        public int? Appraisal { get; set; }

        [Column("commentary")]
        public string Commentary { get; set; }
        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }
    }
}
