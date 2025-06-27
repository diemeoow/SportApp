using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportClub.Models
{
    [Table("client")]
    public class Client
    {
        [Key, Column("id")]
        public int Id { get; set; }

        [Column("full_name")]
        public string? FullName { get; set; }

        [Column("phone_num")]
        public string? PhoneNum { get; set; }

        [Column("date_registration")]
        public DateTime? DateRegistration { get; set; }

        [Column("health_indicators_id")]
        public int? HealthIndicatorsId { get; set; }

        // ← Навигационное свойство
        public HealthIndicators HealthIndicators { get; set; }

        [Column("subscription_id")]
        public int? SubscriptionId { get; set; }

        public Subscription Subscription { get; set; }
    }
}
