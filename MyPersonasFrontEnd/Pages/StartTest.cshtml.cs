using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPersonasFrontEnd.Services;
using PersonalityProfilerDTO;

namespace MyPersonasFrontEnd.Pages
{
    public class StartTestModel : PageModel
    {
        private readonly IApiClient _apiClient;

        [BindProperty]
        public Questions questions { get; set; }

        public IEnumerable<IGrouping<Questions, QuestionsResponse>> quest { get; set; }

        public StartTestModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task OnGet()
        {

            var myQ = await _apiClient.GetQuestionsAsync();
            questions = new Questions
            {
                Id = 4566,
                Question = "What is your favourite Pastime?",
                State = "Incomplete",
                Number = 1,
               
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _apiClient.PutQuestionsAsync(questions); // we insert only the answer

            return Page();
        }

    }
}
