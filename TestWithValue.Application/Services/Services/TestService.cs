using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Application.Contract.Persistence;
using TestWithValue.Application.Services.Services_Interface;
using TestWithValue.Domain.ViewModels.Test;

namespace TestWithValue.Application.Services.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;   
        public TestService(ITestRepository testRepository, IMapper mapper)
        {
            _mapper = mapper;   
            _testRepository = testRepository;
        }
        public async Task<IEnumerable<ShowTestViewModel>> GetAllTests()
        {
            var tests=await _testRepository.GetAllTests();  
            var testVM=_mapper.Map<IEnumerable<ShowTestViewModel>>(tests);
            return testVM;
            
        }

        public async Task<ShowTestViewModel> GetTestById(int testId)
        {
            var test=await _testRepository.GetTestById(testId); 
            var testVm=_mapper.Map<ShowTestViewModel>(test);    
            return testVm;
        }
    }
}
