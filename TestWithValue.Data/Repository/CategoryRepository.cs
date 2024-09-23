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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TestWithValueDbContext _context;
        public CategoryRepository(TestWithValueDbContext context)
        {
            _context = context;
                
        }
        public async Task<Tbl_Category> GetCategoryByScore(int totalScore)
        {
            var category=await _context.Tbl_Categories
                                    .FirstOrDefaultAsync(c => totalScore >= c.MinScore && totalScore <= c.MaxScore);

             return category;

        }
    }
}
