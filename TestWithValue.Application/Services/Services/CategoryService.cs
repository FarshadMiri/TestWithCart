using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Application.Contract.Persistence;
using TestWithValue.Application.Services.IServices;
using TestWithValue.Domain.ViewModels.Category;

namespace TestWithValue.Application.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<GetCategoryViewModel> GetCategory(int totalScore)
        {
            var category=await _categoryRepository.GetCategoryByScore(totalScore);
            var categoryVM= _mapper.Map<GetCategoryViewModel>(category);
            return categoryVM;


        }
    }
}
