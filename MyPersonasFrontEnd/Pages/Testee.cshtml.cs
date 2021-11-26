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
    public class TesteeModel : PageModel
    {
		private readonly ILogger<IndexModel> _logger;
		protected readonly IApiClient _apiClient;

		public TesteeModel (ILogger<IndexModel> logger, IApiClient apiClient)
		{
			_apiClient = apiClient;
			_logger = logger;
		}

		public TesteeResponse Testee { get; set; }

		public async Task<IActionResult> OnGet(Testee mytestee)
		{
			Testee = await _apiClient.GetTesteeAsync(mytestee.UserName);

		

			var mytestees = await _apiClient.GetTesteesAsync();
			return Page();
		}
	}
}
