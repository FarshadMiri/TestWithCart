using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Domain.Enitities;
using TestWithValue.Domain.ViewModels.Answer;
using TestWithValue.Domain.ViewModels.Category;
using TestWithValue.Domain.ViewModels.Question;

namespace TestWithValue.Application.profile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Tbl_Answer, SumbitAnswerViewModel>().ReverseMap();
            CreateMap<Tbl_Question, ShowQuestionViewModel>().ReverseMap();
            CreateMap<Tbl_Category, GetCategoryViewModel>().ReverseMap();

        }
    }
}
