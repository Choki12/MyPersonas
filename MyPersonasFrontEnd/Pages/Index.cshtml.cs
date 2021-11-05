using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyPersonasFrontEnd.Services;
using PersonalityProfilerDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonasFrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        protected readonly IApiClient _apiClient;

  

        public IndexModel(ILogger<IndexModel> logger, IApiClient apiClient)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        public IEnumerable<IGrouping<Test,TestResponse>> Tests {get; set;} //assign a unique id for each test

        public IEnumerable<IGrouping<Questions, QuestionsResponse>> Questions { get; set; }

        //iterate through collection of questions
        public IEnumerable<(string SelectedAnswer, int QuestionNuumber)> OnQuestion { get; set; }

        public int QuestionsLeft { get; set; }

        public async Task OnGet()
        {

            var tests = await _apiClient.GetTestsAsync();

            var questions = await _apiClient.GetQuestionsAsync();

            //var initialTestDate = tests.Min(t => t.DateTaken);

            //var testType = tests.Select(t => t.Type);

            //QuestionsLeft = qLeft;

            var question = questions.Where(t => t.Number >= 1)
                                            .OrderBy(t => t.Number);


            var myTests = tests.ToList();

           
                         
                         




            
            //add radio buttons linked to cshtml to form logic here


        }
    }
}
