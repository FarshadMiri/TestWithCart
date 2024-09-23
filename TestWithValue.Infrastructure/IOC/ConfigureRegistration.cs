using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Application.Contract.Persistence;
using TestWithValue.Application.Services.IServices;
using TestWithValue.Application.Services.Services;
using TestWithValue.Data;
using TestWithValue.Data.Repository;

namespace TestWithValue.Infrastructure.IOC
{
    public static class ConfigureRegistration
    {
        public static void ConfigurePersistenceServices(this IServiceCollection services,
    IConfiguration configuration)
        {
            services.AddDbContext<TestWithValueDbContext>(options =>
            {
                options.UseSqlServer(configuration
                    .GetConnectionString("TestWithValueConnection"));
            });
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionService, QuestionService>();

            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IAnswerService, AnswerService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();



            services.AddAutoMapper(Assembly.GetExecutingAssembly());


        }
    }
}
