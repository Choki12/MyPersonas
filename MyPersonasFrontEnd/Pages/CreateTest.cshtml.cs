using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using PersonalityProfilerDTO;
using MyPersonasFrontEnd.Services;

namespace MyPersonasFrontEnd.Pages
{
    public class CreateTestModel : PageModel
    {
        private readonly IApiClient _apiClient;


        [BindProperty]
        public Test myTests { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _apiClient.PutTestAsync(myTests);

            return Page();
        }

            public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
