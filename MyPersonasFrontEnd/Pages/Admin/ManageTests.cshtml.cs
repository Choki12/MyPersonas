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
    public class ManageTestsModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        private readonly IApiClient _apiClient;

        [BindProperty]
        public Test Tests { get; set; }
        public ManageTestsModel(IApiClient apiClient)
        {
            _apiClient = apiClient;


        }



        public async Task OnGet(int id)
        {
            var mytest = await _apiClient.GetTestAsync(id);
            Tests = new Test
            {
                Id = mytest.Id,
                DateTaken = mytest.DateTaken,
                TestState = mytest.TestState,
                Type = mytest.Type
            };

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Message = "Test successfully updated";

            await _apiClient.PutTestAsync(Tests);

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var test = await _apiClient.GetTestAsync(id);

            if (test != null)
            {
                await _apiClient.DeleteTestAsync(id);
            }

            Message = "Test successfully removed";

            return Page();
        }

    }
}
