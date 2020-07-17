using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sonuncuqol.Areas.Admin.Models
{
    public class AboutUsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Məcburidir, boş qoyula bilməz")]
        [MaxLength(350,ErrorMessage ="350 simvolu keçmisiniz")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Məcburidir, boş qoyula bilməz")]
        [MaxLength(13000,ErrorMessage ="13000 simvolluq kvotanı keçmisiniz :( ")]
        public string Text { get; set; }
        public string AddedBy { get; set; }
        [Required(ErrorMessage = "Məcburidir, boş qoyula bilməz")]
        public bool Status { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
