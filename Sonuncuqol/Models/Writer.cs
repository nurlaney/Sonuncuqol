using Repository.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sonuncuqol.Models
{
    public class Writer : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string FullName { get; set; }
        [MaxLength(300)]
        public string Image { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
