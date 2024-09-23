using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Domain.ViewModels.Question;

namespace TestWithValue.Application.Services.IServices
{
    public interface IQuestionService
    {
        Task<IEnumerable<ShowQuestionViewModel>> GetAllQuestion();
    }
}
