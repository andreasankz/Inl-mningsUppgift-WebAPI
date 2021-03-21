using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorApp.HttpRepository
{
    public class UserHttpRepository : IUserHttpRepository
    {
        private readonly HttpClient _client;

        public UserHttpRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<GetUser>> GetUsers()
        {
            var response = await _client.GetAsync("https://localhost:44309/api/users");
            var content = await response.Content.ReadAsStringAsync();

            var users = JsonSerializer.Deserialize<List<GetUser>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return users;
        }
    }
}
