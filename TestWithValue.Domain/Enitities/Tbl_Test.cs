using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWithValue.Domain.Enitities
{
    public class Tbl_Test
    {
        public class Test
        {
            [Key]
            public int TestId { get; set; }  // کلید اصلی
            public string TestName { get; set; }  // نام آزمون

            // ناوبری به سوالات مرتبط
            public ICollection<Tbl_Question> Questions { get; set; }

            // ناوبری به تاپیک‌های مرتبط
            public ICollection<Tbl_Topic> Topics { get; set; }
        }

    }
}
