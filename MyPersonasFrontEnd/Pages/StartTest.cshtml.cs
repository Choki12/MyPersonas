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

        [TempData]
        public string Message { get; set; }

        public bool ShowMessage => !string.IsNullOrEmpty(Message);


        [BindProperty]
        public Questions questions { get; set; }

        [BindProperty]
        public IEnumerable<Questions> Quests { get; set; }
        public List<QuestionsResponse> quest { get; set; } = new List<QuestionsResponse>();

        public StartTestModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task OnGet()
        {
            Quests = await _apiClient.GetQuestionsAsync();

            var myQ = await _apiClient.GetQuestionsAsync();

            quest = await _apiClient.GetQuestionsAsync();
            
            if (myQ == null)
            {
                RedirectToPage("/Index");
            }

            foreach(var q in myQ)
            {
                
                questions = new Questions
                {
                    Id = q.Id,
                    Question = q.Question,
                    State = q.State,
                    Number = q.Number
                    
                };

                
            }
          
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            

            foreach(var questions in Quests)
            {
                await _apiClient.PutAnswerAsync(questions);
            }
            


             // we insert only the answer

            return Page();
        }

    }
}
