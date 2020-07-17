using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sonuncuqol.Areas.Admin.Models
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string FullName { get; set; }
        public IFormFile File { get; set; }
        public string Image { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedBy { get; set; }
        public ICollection<ApostViewModel> Posts { get; set; }

    }
}
