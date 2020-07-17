using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sonuncuqol.ViewModels
{
    public class WriterViewModel
    {
        [Required]
        [MaxLength(60)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(300)]
        public string Image { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        public ICollection<PostViewModel> Posts { get; set; }
    }
}
