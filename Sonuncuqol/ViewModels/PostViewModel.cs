using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sonuncuqol.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(155)]
        public string Title { get; set; }
        public DateTime AddedDate { get; set; }
        [Required]
        [MaxLength(13000)]
        public string Text { get; set; }
        [Required]
        [MaxLength(800)]
        public string Description { get; set; }
        [Required]
        [MaxLength(300)]
        public string Image { get; set; }
        public bool IsFeatured { get; set; }
        public WriterViewModel Writer { get; set; }
        public LabelViewModel Label { get; set; }
    }
}
