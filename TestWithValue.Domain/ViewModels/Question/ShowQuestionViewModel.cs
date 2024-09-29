using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Domain.Enitities;
using TestWithValue.Domain.ViewModels.Option;

namespace TestWithValue.Domain.ViewModels.Question
{
    public class ShowQuestionViewModel
    {
        public int TestId { get; set; }
        public int CurrentQuestionIndex { get; set; }

    }
}

