using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Application.Contract.Persistence;
using TestWithValue.Domain.Enitities;

namespace TestWithValue.Data.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly TestWithValueDbContext _context;
        public QuestionRepository(TestWithValueDbContext context)
        {
            _context = context; 
        }
        public  async Task<IEnumerable<Tbl_Question>> GetAllQuestion()
        {
            return await _context.Tbl_Questions.ToListAsync();
        }
    }
}
