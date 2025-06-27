using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("notification")]
    public class Notification
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("app_user_id")]
        public int? AppUserId { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("send_date")]
        public DateTime? SendDate { get; set; }
        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }
    }
}
