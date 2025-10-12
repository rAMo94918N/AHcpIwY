// 代码生成时间: 2025-10-13 03:28:24
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

/// <summary>
/// Represents a simple IoT gateway manager.
/// </summary>
public class IoTGatewayManager
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl;

    /// <summary>
    /// Initializes a new instance of the IoTGatewayManager class.
    /// </summary>
    /// <param name="apiUrl">The URL of the IoT gateway API.</param>
    public IoTGatewayManager(string apiUrl)
    {
        _httpClient = new HttpClient();
        _apiUrl = apiUrl;
    }

    /// <summary>
    /// Gets a list of all IoT gateways.
    /// </summary>
    /// <returns>A list of IoT gateways.</returns>
    public async Task<List<IoTGateway>> GetAllGatewaysAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync(_apiUrl + "/gateways");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<IoTGateway>>(content);
        }
        catch (HttpRequestException ex)
        {
            throw new ApplicationException("Error fetching gateways", ex);
        }
    }

    /// <summary>
    /// Adds a new IoT gateway.
    /// </summary>
    /// <param name="gateway">The IoT gateway to add.</param>
    /// <returns>The added IoT gateway.</returns>
    public async Task<IoTGateway> AddGatewayAsync(IoTGateway gateway)
    {
        try
        {
            var content = JsonSerializer.Serialize(gateway);
            var response = await _httpClient.PostAsync(_apiUrl + "/gateways", new StringContent(content, System.Text.Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            var addedGateway = await response.Content.ReadAsAsync<IoTGateway>();
            return addedGateway;
        }
        catch (HttpRequestException ex)
        {
            throw new ApplicationException("Error adding gateway", ex);
        }
    }

    /// <summary>
    /// Represents an IoT gateway.
    /// </summary>
    public class IoTGateway
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
    }
}
