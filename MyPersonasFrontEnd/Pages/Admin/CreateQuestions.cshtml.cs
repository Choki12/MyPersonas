using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPersonasFrontEnd.Services;
using PersonalityProfilerDTO;

namespace MyPersonasFrontEnd.Pages.Admin
{
    public class CreateQuestionsModel : PageModel
    {

        [TempData]
        public string Message { get; set; }

        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        private readonly IApiClient _apiClient;

        public Test mytest { get; set; } = new Test();

        [BindProperty]
        public Questions Quests { get; set; } = new Questions();

        public QuestionsResponse qt;

        [BindProperty]
        public IEnumerable<Test> Tests { get; set; }
        public CreateQuestionsModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }


        public async Task OnGet()
        {
           Tests = await _apiClient.GetTestsAsync();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


           

            await _apiClient.PostQuestionsAsync(Quests);
            

            Message = "Successfully created new Question";

            return Page();
        }
    }
}
