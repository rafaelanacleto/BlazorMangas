using BlazorMangas.Models.DTOs;
using System.Net.Http.Json;
using BlazorMangas.Services.Api;

namespace BlazorMangas.Services.Api;
public class CategoriaService : ICategoriaService
{
    private readonly IHttpClientFactory _httpClientFactory;
    public ILogger<CategoriaService> _logger;
    private const string ApiEndpoint = "/Api/Categorias/";

    private CategoriaDTO? categoria;
    private IEnumerable<CategoriaDTO>? categorias;

    public CategoriaService(IHttpClientFactory httpClientFactory,
        ILogger<CategoriaService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<CategoriaDTO> GetCategoria(int id)
    {
        try
        {
            var httpClient = _httpClientFactory.CreateClient("ApiMangas");
            var response = await httpClient.GetAsync(ApiEndpoint + id);

            if (response.IsSuccessStatusCode)
            {
                categoria = await response.Content.ReadFromJsonAsync<CategoriaDTO>();
                return categoria;
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                _logger.LogError($"Erro ao obter a categoria pelo id= {id} - {message}");
                throw new Exception($"Status Code : {response.StatusCode} - {message}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao obter a categoria pelo id={id} \n\n {ex.Message} ");
            throw new UnauthorizedAccessException();
        }
    }
    public async Task<List<CategoriaDTO>> GetCategorias()
    {
        try
        {
            var httpClient = _httpClientFactory.CreateClient("ApiMangas");
            var result = await httpClient.GetFromJsonAsync<List<CategoriaDTO>>(ApiEndpoint);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Erro ao acessar categorias: {ApiEndpoint} " + ex.Message);
            throw new UnauthorizedAccessException();
        }
    }
}