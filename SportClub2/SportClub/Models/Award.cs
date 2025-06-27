using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("award")]
    public class Award
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("app_user_id")]
        public int? AppUserId { get; set; }

        [Column("event_id")]
        public int? EventId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("place")]
        public int? Place { get; set; }
        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; }
    }
}
