using System.ComponentModel.DataAnnotations;

namespace Server.Entities
{
    public class Book : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        public string BookCoverUrl { get; set; }
        [Required]
        public int TotalCopies { get; set; }
        [Required]
        public int AvailableCopies { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        public Category Category { get; set; }
    }
}