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
    public class CreateTestModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        private readonly IApiClient _apiClient;

        [BindProperty]
        public Test Tests { get; set; } = new Test();
        public CreateTestModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }



            await _apiClient.PostTestAsync(Tests);

            Message = "Successfully created new user";

            return Page();
        }
    }
}
