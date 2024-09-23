using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWithValue.Application.Services.IServices;
using TestWithValue.Domain.ViewModels.Answer;
using TestWithValue.Domain.ViewModels.Question;
using TestWithValue.Domain.ViewModels.Result;

namespace TestWithValue.Web.Controllers
{
    public class QuizController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly ICategoryService _categoryService;





        public QuizController(IQuestionService questionService, IAnswerService answerService, ICategoryService categoryService , IMapper mapper)
        {
            _mapper = mapper;
            _questionService = questionService;
            _answerService = answerService;
            _categoryService = categoryService;

        }

        public IActionResult Start()
        {
            return View();
        }

        // دریافت سوالات
        public async Task<IActionResult> GetQuestion(int index)
        {
            ViewBag.HideNavbar = true;
            var questionsVM = await _questionService.GetAllQuestion();
            var questionsList = questionsVM.ToList();

            // چک کردن مقدار index
            if (index < 0 || index >= questionsList.Count)
            {
                return NotFound();
            }

            // ساختن مدل سوال برای ارسال به ویو
            var questionVM = new ShowQuestionViewModel
            {
                QuestionId = questionsList[index].QuestionId,
                QuestionText = questionsList[index].QuestionText,
                CurrentQuestionIndex = index
            };

            ViewBag.TotalQuestions = questionsList.Count;  // ارسال تعداد کل سوالات برای استفاده در ویو

            
            //return  PartialView("_QuestionPartial", questionVM);  // PartialView را به جای View برگردانید
            return View(questionVM);
        }



        [HttpPost]
        public async Task<IActionResult> SubmitAnswer([FromBody] SumbitAnswerViewModel submitAnswer)
        {
            if (ModelState.IsValid)
            {
                submitAnswer.UserId = 1; // دریافت UserId کاربر از context یا session

                // تنظیم امتیاز بر اساس جواب کاربر
                submitAnswer.AnswerScore = submitAnswer.UserAnswer == "Yes" ? 10 : 0;

                // بررسی وجود پاسخ قبلی برای سوال فعلی
                var existingAnswer = await _answerService.GetAnswerByQuestionIdAndUserId(submitAnswer.QuestionId, submitAnswer.UserId);

                if (existingAnswer != null)
                {
                    // اگر پاسخی از قبل وجود دارد، آن را آپدیت کنید
                    existingAnswer.UserAnswer = submitAnswer.UserAnswer;
                    existingAnswer.AnswerScore = submitAnswer.AnswerScore;

                    await _answerService.UpdateAnswer(existingAnswer);
                }
                else
                {
                    // اگر پاسخی وجود ندارد، پاسخ جدید ایجاد کنید
                    await _answerService.AddAnswer(submitAnswer);
                }

                return Ok();
            }

            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAnswer(int questionId)
        {
            var userId = 1; // اینجا باید UserId کاربر را دریافت کنید
            var answer = await _answerService.GetAnswerByQuestionIdAndUserId(questionId, userId);

            if (answer == null)
            {
                return Ok(new { userAnswer = "" }); // اگر پاسخی نباشد، پاسخ خالی برگردانید
            }

            return Ok(new
            {
                userAnswer = answer.UserAnswer
            });
        }
        // پایان آزمون و نمایش نتیجه
        public async Task<IActionResult> ShowResult()
        {
            int userId = 1; // در عمل باید userId کاربر فعلی را دریافت کنید

            // دریافت تمام پاسخ‌های کاربر از دیتابیس
            var userAnswers = await _answerService.GetAnswersByUserId(userId);

            // محاسبه مجموع امتیازات
            int totalScore = userAnswers.Sum(a => a.AnswerScore);

            // یافتن کتگوری مناسب بر اساس مجموع امتیازات
            var userCategory = await _categoryService.GetCategory(totalScore); 

            if (userCategory == null)
            {
                // مدیریت خطا در صورت عدم یافتن کتگوری
                return NotFound("دسته‌بندی متناسب با امتیاز شما یافت نشد.");
            }

            // ارسال نتیجه به ویو
            var resultViewModel = new ResultViewModel
            {
                TotalScore = totalScore,
                CategoryName = userCategory.Name
            };

            return View(resultViewModel);
        }

        // هدایت پس از اتمام زمان آزمون
        public IActionResult Timeout()
        {
            return RedirectToAction("Start");
        }
    }
}
