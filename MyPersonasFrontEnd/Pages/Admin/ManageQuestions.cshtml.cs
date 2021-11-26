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
    public class ManageQuestionsModel : PageModel
    {

        [TempData]
        public string Message { get; set; }

        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        private readonly IApiClient _apiClient;

        [BindProperty]
        public Questions Question { get; set; }

        public ManageQuestionsModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }


        public async Task OnGet(int id)
        {
            var myquestions = await _apiClient.GetQuestionAsync(id);

            if (myquestions == null)
            {
                RedirectToPage("/Index");
            }

            Question = new Questions
            {
                Id = myquestions.Id,
                Number = myquestions.Number,
                Question = myquestions.Question,
                State = myquestions.State,
                Answer = myquestions.Answer
            };

        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }



            await _apiClient.PutQuestionsAsync(Question);

            Message = "Questions successfully updated";

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var q = await _apiClient.GetQuestionAsync(id);
            
            if(q != null)
            {
                //await _apiClient.D
                await _apiClient.DeleteQuestionAsync(id);
            }

            Message = "Question successfully removed";

            return Page();
        }



    }
}
