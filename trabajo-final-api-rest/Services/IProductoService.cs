using trabajo_final_api_rest.Dtos;

namespace trabajo_final_api_rest.Services
{
    public interface IProductoService
    {
        Task<List<ProductoResponseDto>> GetAll();
        Task<ProductoResponseDto?> GetById(int id);
        Task<ProductoResponseDto> Create(ProductoCreateDto dto);
        Task<ProductoResponseDto> Delete(int id);
        Task<ProductoResponseDto> Put(int id, ProductoUpdateDto dto );


    }
}
