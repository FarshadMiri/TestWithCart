using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWithValue.Domain.ViewModels.Answer
{
    public  class SumbitAnswerViewModel
    {
        public int Id { get; set; }
        public string UserAnswer { get; set; } // جواب کاربر (بله یا خیر)
        public int AnswerScore { get; set; } // امتیازی که کاربر بر اساس پاسخ به این سوال گرفته
        public int QuestionId { get; set; }
        public int UserId { get; set; }
    }
}
