using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TestWithValue.Application.Contract.Persistence;
using TestWithValue.Application.Services.Services;
using TestWithValue.Application.Services.Services_Interface;
using TestWithValue.Application.Services.Services_Interface.ActionMessage_s_Interface;
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
            // services.AddScoped<IQuestionRepository, QuestionRepository>();
            // services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<ITestService, TestService>();

            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionService, QuestionService>();

            services.AddScoped<IOptionRepository, OptionRepository>();
            services.AddScoped<IOptionService, OptionService>();

            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IAnswerService, AnswerService>();

            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<ITopicSevice, TopicSevice>();

            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<ICartItemService, CartItemService>();

            services.AddScoped<IActionMessageService, TempDataActionMessageService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ITempDataDictionaryFactory, TempDataDictionaryFactory>();

















            services.AddAutoMapper(Assembly.GetExecutingAssembly());


        }
    }
}
