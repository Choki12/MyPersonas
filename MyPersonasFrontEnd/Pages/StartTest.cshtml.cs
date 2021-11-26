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

       // [BindProperty]
       // public List<QuestionsResponse> quest { get; set; } = new List<QuestionsResponse>();

        public StartTestModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task OnGet()
        {
            Quests = await _apiClient.GetQuestionsAsync();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/

            //Quests = await _apiClient.GetQuestionsAsync();

            foreach(var q in Quests)
            {
                await _apiClient.PutAnswerAsync(q);
            }

            
          

            if (Quests == null)
            {
                RedirectToPage("/Index");
            }






            // we insert only the answer

            return Page();
        }

    }
}
