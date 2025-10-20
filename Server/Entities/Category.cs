using System.ComponentModel.DataAnnotations;

namespace Server.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}