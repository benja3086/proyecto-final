using Microsoft.EntityFrameworkCore;
using trabajo_final_api_rest.Data;
using trabajo_final_api_rest.Dtos;
using trabajo_final_api_rest.model;
using AutoMapper;

namespace trabajo_final_api_rest.Services
{
    public class ProductoService : IProductoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductoResponseDto>> GetAll()
        {
            var productos = await _context.productos.ToListAsync();
            return _mapper.Map<List<ProductoResponseDto>>(productos);
        }

        public async Task<ProductoResponseDto?> GetById(int id)
        {
            var producto = await _context.productos.FindAsync(id);
            return _mapper.Map<ProductoResponseDto?>(producto);
        }

        public async Task<ProductoResponseDto> Create(ProductoCreateDto dto)
        {
            var producto = _mapper.Map<Producto>(dto);

            _context.productos.Add(producto);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductoResponseDto>(producto);
        }

        public async Task<ProductoResponseDto?> Delete(int id)
        {
            var producto = await _context.productos.FindAsync(id);
            if (producto == null) return null;

            _context.productos.Remove(producto);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductoResponseDto>(producto);
        }

        public async Task<ProductoResponseDto?> Put(int id, ProductoUpdateDto dto)
        {
            var producto = await _context.productos.FindAsync(id);
            if (producto == null) return null;

            // mapear dto → producto existente
            _mapper.Map(dto, producto);

            await _context.SaveChangesAsync();

            return _mapper.Map<ProductoResponseDto>(producto);
        }
    }
}
