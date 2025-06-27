using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SportClub.Models
{
    [Table("participant_event")]
    public class ParticipantEvent
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("event_id")]
        public int? EventId { get; set; }

        [Column("app_user_id")]
        public int? AppUserId { get; set; }

        [Column("result")]
        public string Result { get; set; }
        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }
    }
}
