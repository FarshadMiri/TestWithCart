using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWithValue.Domain.Enitities
{
    public class Tbl_Answer
    {
        [Key]
        public int Id { get; set; }
        public string UserAnswer { get; set; } // جواب کاربر (بله یا خیر)
        public int AnswerScore { get; set; } // امتیازی که کاربر بر اساس پاسخ به این سوال گرفته

        // رابطه چند به یک با Question
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Tbl_Question Question { get; set; }

        // رابطه چند به یک با کاربر (User)
        [ForeignKey("User")]
        public int UserId { get; set; }
        public Tbl_User User { get; set; }
    }
}
