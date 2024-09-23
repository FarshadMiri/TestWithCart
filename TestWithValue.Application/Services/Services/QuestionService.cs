using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Application.Contract.Persistence;
using TestWithValue.Application.Services.IServices;
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
        public async Task<IEnumerable<ShowQuestionViewModel>> GetAllQuestion()
        {
            var questions = await _questionRepository.GetAllQuestion();
            var questionVM = _mapper.Map<List<ShowQuestionViewModel>>(questions);  // مپ کردن کاربران به DTOها


            return questionVM;


        }
    }
}
