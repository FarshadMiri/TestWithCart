using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWithValue.Domain.Enitities
{
    public class Tbl_Answer
    {
        [Key]
        public int AnswerId { get; set; }  // کلید اصلی
        
        public int UserId { get; set; }  // کلید خارجی به جدول کاربران
        [ForeignKey("Question")]

        public int QuestionId { get; set; }  // کلید خارجی به جدول سوالات
        [ForeignKey("SelectedOption")]
        public int SelectedOptionId { get; set; }  // کلید خارجی به جدول گزینه‌ها (Option)

        // ناوبری به کاربر (در صورتی که مدل User دارید)
        // public User User { get; set; }

        // ناوبری به سوال
        public Tbl_Question Question { get; set; }

        // ناوبری به گزینه انتخاب شده
        public Tbl_Option SelectedOption { get; set; }
    }
}
