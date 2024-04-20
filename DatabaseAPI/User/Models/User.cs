using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabaseAPI.User.Models
{
    [Table("users")]
    public class User
    {
        [Column("id"), Key]
        [JsonPropertyName("id")]
        public long Id { get; init; }

        [Column("user_name"), Required]
        [JsonPropertyName("user_name")]
        public string UserName { get; init; }

        [Column("password"), Required]
        [JsonPropertyName("password")]
        public string Password { get; init; }

        [Column("device_id"), Required]
        [JsonPropertyName("device_id")]
        public string DeviceId { get; init; }

        [Column("name"), Required]
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [Column("created_at"), Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset Created_At { get; init; }

        [Column("deleted_at")]
        public DateTimeOffset? Deleted_At { get; init; }
    }
}
