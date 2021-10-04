﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using PersonalityProfilerDTO;

namespace MyPersonasFrontEnd.Services
{
    /*
     * $ = String interpolation, 
     */
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddTesteeAsync(Testee mytestee)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/testee", mytestee);

            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                return false;
            }

            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<TesteeResponse> GetTesteeAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            var response = await _httpClient.GetAsync($"/api/testee/{name}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<TesteeResponse>();
        }

        public async Task<TestResponse> GetTestAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/test/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<TestResponse>();
        }

        public async Task<List<TestResponse>> GetTestsAsync()
        {
            var response = await _httpClient.GetAsync("/api/Tests");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<TestResponse>>();
        }

        public async Task DeleteTestAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Tests/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return;
            }

            response.EnsureSuccessStatusCode();
        }

        public async Task<QuestionsResponse> GetQuestionAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/test/{id}");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<QuestionsResponse>();
        }

        public async Task<List<QuestionsResponse>> GetQuestionsAsync()
        {
            var response = await _httpClient.GetAsync("/api/questions");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<QuestionsResponse>>();
        }

        public async Task PutTestAsync(Test mytest)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/test/{mytest.Id}", mytest);

            response.EnsureSuccessStatusCode();
        }


        public async Task AddTestToTesteeAsync(string name, int testId)
        {
            var response = await _httpClient.PostAsync($"/api/testee/{name}/test/{testId}", null);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteTestFromTesteeAsync(string name, int testId)
        {
            var response = await _httpClient.DeleteAsync($"/api/attendees/{name}/session/{testId}");

            response.EnsureSuccessStatusCode();
        }

        public async Task<List<TestResponse>> GetTestByTesteeAsync(string name)
        {
            var response = await _httpClient.GetAsync($"/api/testee/{name}/test");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<TestResponse>>();
        }


        public async Task<List<TesteeResponse>> GetTesteesAsync()
        {
            var response = await _httpClient.GetAsync("/api/testees");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<TesteeResponse>>();
        }

        public async Task PutQuestionsAsync(Questions myquestions)
        {

            var response = await _httpClient.PutAsJsonAsync($"/api/questions/{myquestions.Id}", myquestions);

            response.EnsureSuccessStatusCode();
        }

        /*public async Task<bool> CheckHealthAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("/health");

                return string.Equals(response, "Healthy", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }*/

    }
}
