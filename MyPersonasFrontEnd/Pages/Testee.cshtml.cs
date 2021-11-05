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
    public class TesteeModel : PageModel
    {
		private readonly IApiClient _apiClient;

		public TesteeModel (IApiClient apiClient)
		{
			_apiClient = apiClient;
		}

		public TesteeResponse Testee { get; set; }

		public async Task<IActionResult> OnGet(string name)
		{
			Testee = await _apiClient.GetTesteeAsync(name);

			if (Testee == null)
			{
				return NotFound();
			}

			//var mytestees = await _apiClient.GetTesteesAsync();
			return Page();
		}
	}
}
