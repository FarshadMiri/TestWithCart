using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWithValue.Domain.ViewModels.Category
{
    public class GetCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } // نام دسته‌بندی (مثلاً برونگرا، درونگرا)
        public int MinScore { get; set; } // حداقل امتیاز برای این دسته
        public int MaxScore { get; set; }
    }
}
