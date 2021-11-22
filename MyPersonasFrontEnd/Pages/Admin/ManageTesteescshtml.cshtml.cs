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
    public class ManageTesteescshtmlModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        private readonly IApiClient _apiClient;

        [BindProperty]
        public Testee Testees { get; set; }
        public ManageTesteescshtmlModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task OnGet(string name)
        {
            var mytestee = await _apiClient.GetTesteeAsync(name);

            if (mytestee == null)
            {
                RedirectToPage("/Index");
            }

            Testees = new Testee
            {
                Id = mytestee.Id,
                Name = mytestee.Name,
                Surname = mytestee.Surname,
                DOB = mytestee.DOB,
                Email = mytestee.UserName,
                UserName = mytestee.UserName
            };

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _apiClient.PutTesteeAsync(Testees);

            Message = "Test successfully updated";

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var test = await _apiClient.GetTestAsync(id);

            if (test != null)
            {
                await _apiClient.DeleteTestAsync(id);
            }

            Message = "Testee successfully removed";

            return Page();
        }
    }
}
