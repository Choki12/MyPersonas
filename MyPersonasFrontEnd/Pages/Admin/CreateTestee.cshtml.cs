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
    public class CreateTesteeModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        private readonly IApiClient _apiClient;

        [BindProperty]
        public Testee Testees { get; set; } = new Testee();
        public CreateTesteeModel(IApiClient apiClient)
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



            await _apiClient.PostTesteeAsync(Testees);

            Message = "Successfully created new testee";

            return Page();
        }
    }
}

