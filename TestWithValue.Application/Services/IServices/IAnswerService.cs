using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Domain.ViewModels.Answer;

namespace TestWithValue.Application.Services.IServices
{
    public interface IAnswerService
    {
        Task AddAnswer(SumbitAnswerViewModel answer);
        Task<IEnumerable<SumbitAnswerViewModel>> GetAnswersByUserId(int userId);
        Task<SumbitAnswerViewModel> GetAnswerByQuestionIdAndUserId(int questionId, int userId);
        Task UpdateAnswer(SumbitAnswerViewModel answerDto);
    }
}
