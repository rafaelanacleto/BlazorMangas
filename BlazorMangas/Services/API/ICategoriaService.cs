using BlazorMangas.Models.DTOs;

namespace BlazorMangas.Services.API;

public interface ICategoriaService
{
    Task<List<CategoriaDTO>> GetCategorias();
    Task<CategoriaDTO> GetCategoria(int id);

    //Task CreateCategoria(CategoriaDTO categoriaDto);
    //Task UpdateCategoria(CategoriaDTO categoriaDto);
    //Task DeleteCategoria(int id);
    //Task<IEnumerable<CategoriaDTO>> LocalizaCategoria(string criterio);
}