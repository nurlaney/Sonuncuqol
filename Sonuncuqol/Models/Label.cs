using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sonuncuqol.Models
{
    public class Label : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Text { get; set; }
    }
}
