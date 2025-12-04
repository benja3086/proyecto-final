using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using trabajo_final_api_rest.Data;
using trabajo_final_api_rest.Dtos;
using trabajo_final_api_rest.model;
using trabajo_final_api_rest.Services;

namespace trabajo_final_api_rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ILogger<ProductosController> _logger;
        private readonly IProductoService _service;
        private readonly AppDbContext _context;

        public ProductosController(
     IProductoService service,
     AppDbContext context,
     ILogger<ProductosController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ProductoResponseDto>>> Get()
        {
            var productos = await _service.GetAll();
            return Ok(productos);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoResponseDto>> GetId(int id)
        {
            var producto = await _service.GetById(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }
        [HttpPost]
        public async Task<ActionResult<ProductoResponseDto>> Post(ProductoCreateDto dto)
        {
            var productoCreado = await _service.Create(dto);

            return CreatedAtAction(nameof(GetId), new { id = productoCreado.id }, productoCreado);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Producto>> Delete(int id)
        {
            var ProductoDeleted = await _service.Delete(id);
            return Ok("Producto eliminado");
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Producto>> Put(int id, ProductoUpdateDto dto)
        {
            var producto = await _service.Put(id, dto);
            return Ok (producto);
        }

    }
}
