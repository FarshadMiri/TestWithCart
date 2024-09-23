using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWithValue.Domain.Enitities
{
    public class Tbl_Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int Value { get; set; } // امتیاز هر سوال

        // رابطه یک به چند با Answer
        public ICollection<Tbl_Answer> Answers { get; set; }
    }
}
