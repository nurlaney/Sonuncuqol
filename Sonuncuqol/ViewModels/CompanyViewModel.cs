using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sonuncuqol.ViewModels
{
    public class CompanyViewModel
    {
        [Required]
        [MaxLength(350)]
        public string Description { get; set; }
        [Required]
        [MaxLength(13000)]
        public string Text { get; set; }
    }
}
