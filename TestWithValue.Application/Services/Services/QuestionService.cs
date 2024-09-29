using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Application.Contract.Persistence;
using TestWithValue.Application.Services.Services_Interface;
using TestWithValue.Domain.ViewModels.Question;

namespace TestWithValue.Application.Services.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
        }
        public async Task<IEnumerable<ShowQuestionViewModel>> GetQuestionsByTestId(int testId)
        {
            var question =await _questionRepository.GetQuestionsByTestId(testId);
            var questionVM=_mapper.Map<IEnumerable<ShowQuestionViewModel>>(question);
            return questionVM;
        }
    }
}
