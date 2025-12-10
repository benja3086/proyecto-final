using AutoMapper;
using trabajo_final_api_rest.Dtos;
using trabajo_final_api_rest.model;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class ProductoProfile : Profile
{
    public ProductoProfile()
    {
        CreateMap<Producto, ProductoResponseDto>();
        CreateMap<ProductoCreateDto, Producto>();
        CreateMap<ProductoUpdateDto, Producto>();
    }
}
