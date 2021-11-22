using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalityProfilerDTO;

namespace MyPersonasFrontEnd.Services
{
    public interface IApiClient
    {
        Task<List<TestResponse>> GetTestsAsync();
        Task<TestResponse> GetTestAsync(int id);
        Task<List<TesteeResponse>> GetTesteesAsync();
        Task<TesteeResponse> GetTesteeAsync(string name);
        Task PutTestAsync(Test mytest);
        Task PostTestAsync(Test mytest);
        Task<bool> AddTesteeAsync(Testee mytestee);
        Task<QuestionsResponse> GetQuestionAsync(int id);
        Task<List<QuestionsResponse>> GetQuestionsAsync();
        Task PutQuestionsAsync(Questions myquestions);
        Task DeleteTestAsync(int id);
        Task PutTesteeAsync(Testee mytestee);
        Task PostTesteeAsync(Testee mytestee);


    }
}
