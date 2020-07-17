using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sonuncuqol.Areas.Admin.Models
{
    public class ApostViewModel
    {
        public int Id { get; set; }
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
        public IFormFile File { get; set; }
        public bool IsFeatured { get; set; }
        public bool Status { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int WriterId { get; set; }
        public int? LabelId { get; set; }


        public MemberViewModel Writer { get; set; }
        public LabelAViewModel Label { get; set; }
    }
}
