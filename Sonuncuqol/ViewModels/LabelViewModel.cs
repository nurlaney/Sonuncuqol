using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sonuncuqol.ViewModels
{
    public class LabelViewModel
    {
        [Required]
        [MaxLength(60)]
        public string Text { get; set; }

        public ICollection<PostViewModel> Posts { get; set; }
    }
}
