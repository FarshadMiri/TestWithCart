using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Domain.ViewModels.Category;

namespace TestWithValue.Application.Services.IServices
{
    public interface ICategoryService
    {
        Task<GetCategoryViewModel> GetCategory(int totalScore);


    }
}
