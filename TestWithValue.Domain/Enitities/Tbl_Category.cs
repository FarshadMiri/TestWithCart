using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWithValue.Domain.Enitities
{
    public class Tbl_Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; } // نام دسته‌بندی (مثلاً برونگرا، درونگرا)
        public int MinScore { get; set; } // حداقل امتیاز برای این دسته
        public int MaxScore { get; set; } // حداکثر امتیاز برای این دسته
    }
}
