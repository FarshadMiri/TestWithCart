using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWithValue.Domain.ViewModels.Question
{
    public class ShowQuestionViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int CurrentQuestionIndex { get; set; }

    }
}
