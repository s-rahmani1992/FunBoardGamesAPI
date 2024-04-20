using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseAPI.User.Models
{
    [Table("user_sessions")]
    public class UserSession
    {
        [Column("id"), Key]
        public long Id { get; init; }

        [Column("user_id"), Required]
        [ForeignKey(nameof(User))]
        public long UserId { get; init; }

        [Column("login_at")]
        public DateTimeOffset? LoginDate { get; init; }

        [Column("logout_at")]
        public DateTimeOffset? LogoutDate { get; init; }

        [Column("created_at"), Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset Created_At { get; init; }

        [Column("deleted_at")]
        public DateTimeOffset? Deleted_At { get; init; }
  
        public User User { get; init; }
    }
}
