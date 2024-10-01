using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Domain.Enitities;
using TestWithValue.Domain.ViewModels.Answer;
using TestWithValue.Domain.ViewModels.CartItem;
using TestWithValue.Domain.ViewModels.Option;
using TestWithValue.Domain.ViewModels.Question;
using TestWithValue.Domain.ViewModels.Test;
using TestWithValue.Domain.ViewModels.Ticket;
using TestWithValue.Domain.ViewModels.Topic;

namespace TestWithValue.Application.profile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //CreateMap<Tbl_Answer, SumbitAnswerViewModel>().ReverseMap();
            CreateMap<Tbl_Test, ShowTestViewModel>().ReverseMap();
            CreateMap<Tbl_Question, ShowQuestionViewModel>().ReverseMap();
            CreateMap<Tbl_Option, ShowOptionViewModel>().ReverseMap();
            CreateMap<Tbl_Answer, AnswerViewModel>().ReverseMap();
            CreateMap<Tbl_Topic, ShowTopicViewModel>().ReverseMap();
            CreateMap<Tbl_CartItem, CartItemViewModel>().ReverseMap();
            CreateMap<Tbl_Ticket,TicketViewModel >();








        }
    }
}
