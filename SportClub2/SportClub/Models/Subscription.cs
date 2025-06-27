using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("subscription")]
    public class Subscription
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("subscription_type_id")]
        public int SubscriptionTypeId { get; set; }
        public SubscriptionType SubscriptionType { get; set; }

        [Column("deadline_action")]
        public int DurationDays { get; set; }   // <- переименовали

        [Column("date_started")]
        public DateTime DateStarted { get; set; }
    }
}
