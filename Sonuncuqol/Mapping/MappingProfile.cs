using AutoMapper;
using Sonuncuqol.Areas.Admin.Models;
using Sonuncuqol.Models;
using Sonuncuqol.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sonuncuqol.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyViewModel>();
            CreateMap<Company, AboutUsViewModel>();
            CreateMap<AboutUsViewModel, Company>();

            CreateMap<Post, PostViewModel>();

            CreateMap<Writer, WriterViewModel>();

            CreateMap<Label, LabelViewModel>();

            CreateMap<SliderItem, SliderItemViewModel>();

            CreateMap<Label, LabelAViewModel>();
            CreateMap<LabelAViewModel, Label>();

            CreateMap<Writer, MemberViewModel>();
            CreateMap<MemberViewModel, Writer>();

            CreateMap<Post, ApostViewModel>();
            CreateMap<ApostViewModel, Post>();

            CreateMap<SliderItem, SliderViewModel>();
            CreateMap<SliderViewModel, SliderItem>();



        }
    }
}
