using Microsoft.AspNetCore.Mvc;
using trabajo_final_api_rest.Data;
using trabajo_final_api_rest.model;

namespace trabajo_final_api_rest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ProductosController> _logger;

        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context, ILogger<ProductosController> logger)
        {
            _context = context;
            _logger = logger;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public async Producto Get()
        //{
        //    Usuarios user = new Usuarios();

        //    return user;

        //}
        [HttpPost()]
        public async Task<ActionResult<Producto>> Post()
        {
            Producto producto = new Producto();
            producto.Id = 1;
            producto.Titulo = "plato";
            producto.Stock = 5;
            producto.Precio = 100;
            producto.Descripcion = "plato facil de romper";

            _context.productos.Add(producto);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(Post),new {Id=producto.Id},producto);
        }
        //[HttpDelete()]
        //public async Producto Delete()
        //{
        //    Usuarios user = new Usuarios();
        //    user.nombre = "";
        //    user.apellido = "";
        //    user.email = "";
        //    return user;
        //}
    }
}
