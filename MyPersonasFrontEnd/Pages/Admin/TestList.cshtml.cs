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
    public class TestListModel : PageModel
    {

        private readonly IApiClient _apiClient;

        public TestListModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public IEnumerable<TestResponse> Tests { get; set; }

        public async Task OnGet()
        {
            var tests = await _apiClient.GetTestsAsync();

            Tests = tests.OrderBy(t => t.DateTaken);

        }
    }
}
