using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sonuncuqol.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }
        public IEnumerable<SliderItemViewModel> SliderItems { get; set; }
    }
}
