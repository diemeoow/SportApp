using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("group_participant")]
    public class GroupParticipant
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("workout_group_id")]
        public int? WorkoutGroupId { get; set; }

        [Column("app_user_id")]
        public int? AppUserId { get; set; }
        [ForeignKey(nameof(WorkoutGroupId))]
        public WorkoutGroup WorkoutGroup { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; }
    }
}
