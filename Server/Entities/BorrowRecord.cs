using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Entities
{
    public class BorrowRecord : BaseEntity
    {
        [Required]
        public Guid BookId { get; set; }
        [Required]
        [ForeignKey("Member")]
        public string MemberId { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; } = DateTime.UtcNow;
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public IdentityUser Member { get; set; }
        public Book Book { get; set; }
    }
}
