using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Domain.Enitities;

namespace TestWithValue.Data.SeedData
{
    public static class CategorySeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_Category>().HasData(
                   new Tbl_Category { CategoryId = 1, Name = "ایده‌آل‌گرا", MinScore = 90, MaxScore = 100 },
                   new Tbl_Category { CategoryId = 2, Name = "واقع‌گرا", MinScore = 70, MaxScore = 89 },
                   new Tbl_Category { CategoryId = 3, Name = "عمل‌گرا", MinScore = 50, MaxScore = 69 },
                   new Tbl_Category { CategoryId = 4, Name = "لذت‌گرا", MinScore = 30, MaxScore = 49 },
                   new Tbl_Category { CategoryId = 5, Name = "ایثارگر", MinScore = 10, MaxScore = 29 },
                   new Tbl_Category { CategoryId = 6, Name = "فردگرا", MinScore = 0, MaxScore = 9 }
             );
        }

    }
}
