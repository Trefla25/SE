using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartFridge.Service;

public class RecipeRecommendationService
{
    private readonly HttpClient _httpClient;
    private readonly string? _apiKey;

    public RecipeRecommendationService(HttpClient httpClient)
    {
        _httpClient = httpClient;

        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        _apiKey = configuration["OpenAI:ApiKey"];

        if (string.IsNullOrEmpty(_apiKey))
        {
            throw new InvalidOperationException("OpenAI API key is missing in appsettings.json.");
        }
    }

    public async Task<string> GetRecipeRecommendations(List<string> availableIngredients)
    {
        try
        {
            string ingredientsText = string.Join(", ", availableIngredients);
            string prompt = $"You are a cooking assistant. Based on the following available ingredients: {ingredientsText}, suggest a few simple and delicious recipes.";

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                        new { role = "system", content = "You are a recipe recommendation assistant." },
                        new { role = "user", content = prompt }
                    },
                max_tokens = 300,
                temperature = 0.7
            };

            string jsonContent = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);

            if (response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<OpenAIChatResponse>(responseJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return result?.Choices?.FirstOrDefault()?.Message?.Content?.Trim() ?? "No recipes found.";
            }
            else
            {
                string errorDetails = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"OpenAI API Error: {errorDetails}");
                return "Error: Unable to fetch recipes.";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            return "Error: Unable to fetch recipes.";
        }
    }

    private class OpenAIChatResponse
    {
        public List<Choice> Choices { get; set; }
    }

    private class Choice
    {
        public Message Message { get; set; }
    }

    private class Message
    {
        public string Role { get; set; }
        public string Content { get; set; }
    }
}
