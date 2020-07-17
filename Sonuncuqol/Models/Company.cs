using Repository.Models;
using System.ComponentModel.DataAnnotations;

namespace Sonuncuqol.Models
{
    public class Company : BaseEntity
    {
        [Required]
        [MaxLength(350)]
        public string Description { get; set; }
        [Required]
        [MaxLength(13000)]
        public string Text { get; set; }
    }
}
