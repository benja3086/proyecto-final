using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using trabajo_final_api_rest.Data;
using trabajo_final_api_rest.Dtos;
using trabajo_final_api_rest.model;

namespace trabajo_final_api_rest.Services
{
    public class ProductoService : IProductoService
    {
        private readonly AppDbContext _context;

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductoResponseDto>> GetAll()
        {
            return await _context.productos
                .Select(p => new ProductoResponseDto
                {
                    id = p.id,
                    titulo = p.titulo,
                    precio = p.precio,
                    stock = p.stock,
                    descripcion = p.descripcion
                })
                .ToListAsync();
        }
        public async Task<ProductoResponseDto?> GetById(int id)
        {
            var p = await _context.productos.FindAsync(id);
            if (p == null) return null;

            return new ProductoResponseDto
            {
                id = p.id,
                titulo = p.titulo,
                precio = p.precio,
                stock = p.stock,
                descripcion = p.descripcion
            };
        }
        public async Task<ProductoResponseDto> Create(ProductoCreateDto dto)
        {
            var producto = new Producto
            {
                titulo = dto.titulo,
                precio = dto.precio,
                stock = dto.stock,
                descripcion = dto.descripcion
            };

            _context.productos.Add(producto);
            await _context.SaveChangesAsync();

            return new ProductoResponseDto
            {
                id = producto.id,
                titulo = producto.titulo,
                precio = producto.precio,
                stock = producto.stock,
                descripcion = producto.descripcion
            };
        }
        public async Task<ProductoResponseDto?> Delete( int id)
        {
         var productoEncontrado = await _context.productos.FindAsync(id);
            if (productoEncontrado == null)
            {
                return null;
            }
            _context.productos.Remove(productoEncontrado);

            await _context.SaveChangesAsync();
            return new ProductoResponseDto
            {
                id = productoEncontrado.id,
                titulo = productoEncontrado.titulo,
                precio = productoEncontrado.precio,
                stock = productoEncontrado.stock,
                descripcion = productoEncontrado.descripcion
            };
        }
        public async Task<ProductoResponseDto?> Put(int id, ProductoUpdateDto dto)
        {
            var producto = await _context.productos.FindAsync(id);
            if (producto == null) return null;

            producto.titulo = dto.titulo;
            producto.precio = dto.precio;
            producto.stock = dto.stock;
            producto.descripcion = dto.descripcion;


            await _context.SaveChangesAsync();
            return new ProductoResponseDto
            {
                id = producto.id,
                titulo = producto.titulo,
                precio = producto.precio,
                stock = producto.stock,
                descripcion = producto.descripcion
            };
        }
    }
}
