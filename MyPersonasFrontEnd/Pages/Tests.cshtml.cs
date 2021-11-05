using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyPersonasFrontEnd.Services;
using PersonalityProfilerDTO;

namespace MyPersonasFrontEnd.Pages
{
    public class TestsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        protected readonly IApiClient _apiClient;



        public TestsModel(ILogger<IndexModel> logger, IApiClient apiClient)
        {
            _apiClient = apiClient;
            _logger = logger;
        }

        public TestResponse Tests { get; set; } //assign a unique id for each test
        public async Task<IActionResult> OnGet(int id)
        {
            Tests = await _apiClient.GetTestAsync(id);
            
            if(Tests == null)
            {
                return RedirectToPage("/Index");

            }

            var mytests = await _apiClient.GetTestsAsync();

            //Add logic here
            return Page();


        }
    }
}
