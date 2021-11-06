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
    public class TesteeListModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public TesteeListModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
          
        public IEnumerable<TesteeResponse> Testees { get; set; }

        public async Task OnGet()
        {
            var testees = await _apiClient.GetTesteesAsync();

            Testees = testees.OrderBy(tt => tt.Surname);

        }
    }
}
