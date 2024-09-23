using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Application.Contract.Persistence;
using TestWithValue.Application.Services.IServices;
using TestWithValue.Domain.Enitities;
using TestWithValue.Domain.ViewModels.Answer;

namespace TestWithValue.Application.Services.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;
        public AnswerService(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;

        }
        public async Task AddAnswer(SumbitAnswerViewModel answer)
        {
            var answers = new Tbl_Answer()
            {

                QuestionId = answer.QuestionId,
                UserId = 1,
                UserAnswer = answer.UserAnswer,
                AnswerScore = answer.AnswerScore

            };
            await _answerRepository.SaveAnswer(answers);

        }

        public async Task<SumbitAnswerViewModel> GetAnswerByQuestionIdAndUserId(int questionId, int userId)
        {
            var answer = await _answerRepository.GetAnswerByQuestionIdAndUserId(questionId, userId);
            return _mapper.Map<SumbitAnswerViewModel>(answer);
        }

        public async Task<IEnumerable<SumbitAnswerViewModel>> GetAnswersByUserId(int userId)
        {
            var answers = await _answerRepository.GetAnswersByUserId(userId);
            return  _mapper.Map<SumbitAnswerViewModel[]>(answers);
        }

        public async Task UpdateAnswer(SumbitAnswerViewModel answer)
        {
            var answers = new Tbl_Answer()
            {
                Id=answer.Id,
                QuestionId = answer.QuestionId,
                UserId = 1,
                UserAnswer = answer.UserAnswer,
                 AnswerScore= answer.AnswerScore    
            };
            await _answerRepository.UpdateAnswer(answers);
        }
    }
}
