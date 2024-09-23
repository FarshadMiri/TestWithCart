using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Domain.Enitities;

namespace TestWithValue.Application.Contract.Persistence
{
    public interface IAnswerRepository
    {
        Task<bool> SaveAnswer(Tbl_Answer answer);
        Task<IEnumerable<Tbl_Answer>> GetAnswersByUserId(int userId);
        Task<Tbl_Answer> GetAnswerByQuestionIdAndUserId(int questionId, int userId);
        Task<bool> UpdateAnswer(Tbl_Answer answer);
    }
}
