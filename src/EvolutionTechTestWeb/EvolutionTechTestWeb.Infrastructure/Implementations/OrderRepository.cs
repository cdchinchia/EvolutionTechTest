using EvolutionTechTestWeb.Core.DTO;
using EvolutionTechTestWeb.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionTechTestWeb.Infrastructure.Implementations
{
    public class OrderRepository : IRepositoryAsync<OrderDTO>
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _baseUrlPath;
        public OrderRepository(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            _baseUrlPath = "https://localhost:7287";
        }
        public async Task<OrderDTO> CreateAsync(OrderDTO entity)
        {
            if (entity == null) throw new NullReferenceException("Order is null!");

            string url = String.Format("{0}/{1}", _baseUrlPath, "api/Orders/");
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            string content = JsonConvert.SerializeObject(entity);
            request.Content = new StringContent(content, Encoding.UTF8, "application/json");
            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != HttpStatusCode.OK) throw new Exception($"Error with EvolutionTech Api [Status code {response.StatusCode}]: {responseContent}");

            return JsonConvert.DeserializeObject<OrderDTO>(responseContent);
        }

        public async Task<IEnumerable<OrderDTO>> GetAllAsync()
        {
            string url = String.Format("{0}/{1}", _baseUrlPath, "api/Orders/");

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != System.Net.HttpStatusCode.OK) throw new Exception($"Error with EvolutionTech Api [Status code {response.StatusCode}]: {responseContent}");

            return JsonConvert.DeserializeObject<IEnumerable<OrderDTO>>(responseContent);

        }

        public async Task<OrderDTO> GetByIdAsync(int id)
        {
            string url = String.Format("{0}/{1}", _baseUrlPath, "api/Orders/");
            var request = new HttpRequestMessage(HttpMethod.Get, url + id);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != System.Net.HttpStatusCode.OK) throw new Exception($"Error with EvolutionTech Api [Status code {response.StatusCode}]: {responseContent}");

            return JsonConvert.DeserializeObject<OrderDTO>(responseContent);
        }

        public async Task RemoveAsync(int id)
        {
            string url = String.Format("{0}/{1}", _baseUrlPath, "api/Orders/");
            var request = new HttpRequestMessage(HttpMethod.Delete, url + id);

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != System.Net.HttpStatusCode.NoContent) throw new Exception($"Error with EvolutionTech Api [Status code {response.StatusCode}]: {responseContent}");

        }

        public async Task<OrderDTO> UpdateAsync(int id, OrderDTO entity)
        {
            if (entity == null) throw new NullReferenceException("Order is null!");

            string url = String.Format("{0}/{1}", _baseUrlPath, "api/Orders/");
            var request = new HttpRequestMessage(HttpMethod.Patch, url + id);

            string content = JsonConvert.SerializeObject(entity);
            request.Content = new StringContent(content, Encoding.UTF8, "application/json");
            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != HttpStatusCode.OK) throw new Exception($"Error with EvolutionTech Api [Status code {response.StatusCode}]: {responseContent}");

            return JsonConvert.DeserializeObject<OrderDTO>(responseContent);
        }
    }
}
