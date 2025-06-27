using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("app_user")]
    public class AppUser
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("login")]
        public string Login { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("role_user_id")]
        public int? RoleUserId { get; set; }

        [Column("trainer_id")]
        public int? TrainerId { get; set; }

        [ForeignKey(nameof(RoleUserId))]
        public RoleUser RoleUser { get; set; }

        [ForeignKey(nameof(TrainerId))]
        public Trainer Trainer { get; set; }
    }
}
