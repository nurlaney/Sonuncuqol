using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sonuncuqol.Areas.Admin.Models
{
    public class LabelAViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Text { get; set; }
        public bool Status { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
