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
    public class QuestionsModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;

        protected readonly IApiClient _apiClient;

        public QuestionsModel(ILogger<IndexModel> logger, IApiClient apiClient)
        {

            _apiClient = apiClient;
            _logger = logger;
        }

        public QuestionsResponse Questions { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Questions = await _apiClient.GetQuestionAsync(id);

            if(Questions == null)
            {
                return RedirectToPage("/Index");
            }

            return Page();

        }
    }
}
