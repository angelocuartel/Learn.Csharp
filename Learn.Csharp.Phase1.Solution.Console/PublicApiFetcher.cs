using System.Text.Json.Serialization;

namespace Learn.Csharp.Phase1.Solution.Console
{
    public class PublicApiFetcher
    {
        private static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
        };

        // Generic fetch method for any endpoint
        public async Task<List<T>> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync(endpoint, cancellationToken);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            var result = System.Text.Json.JsonSerializer.Deserialize<List<T>>(content);

            if (result is null)
            {
                throw new Exception($"Failed to deserialize response from {endpoint}");
            }

            return result;
        }
    }

    public class Post
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("body")]
        public string Body { get; set; } = string.Empty;
    }

    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("username")]
        public string UserName { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
    }
}
