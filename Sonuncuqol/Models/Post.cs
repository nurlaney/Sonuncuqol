using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sonuncuqol.Models
{
    public class Post : BaseEntity
    {
        [Required]
        [MaxLength(155)]
        public string Title { get; set; }
        [Required]
        [MaxLength(13000)]
        public string Text { get; set; }
        [Required]
        [MaxLength(800)]
        public string Description { get; set; }
        [MaxLength(300)]
        public string Image { get; set; }
        public bool IsFeatured { get; set; }
        public int WriterId { get; set; }
        public int? LabelId { get; set; }

        public Writer Writer { get; set; }
        public Label Label { get; set; }
    }
}
