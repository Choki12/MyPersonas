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
    public class QuestionsListModel : PageModel
    {

        private readonly IApiClient _apiClient;

        public QuestionsListModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public IEnumerable<QuestionsResponse> Questions { get; set; }

        public async Task OnGet()
        {
            var myquestions = await _apiClient.GetQuestionsAsync();

            Questions = myquestions.OrderBy(n => n.Number);

        }
    }
}
