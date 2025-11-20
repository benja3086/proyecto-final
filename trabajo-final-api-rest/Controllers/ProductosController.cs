using Microsoft.AspNetCore.Mvc;
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

        public ProductosController(ILogger<ProductosController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public Usuarios Get()
        {
            Usuarios user = new Usuarios();

            return user;

        }
        [HttpPost()]
        public Usuarios Post()
        {
            Usuarios user = new Usuarios();
            user.nombre = "benja";
            user.apellido = "Quinteros";
            user.email = "benja@gmail.com";

            return user;
        }
        public Usuarios Delete()
        {
            Usuarios user = new Usuarios();
            user.nombre = "";
            user.apellido = "";
            user.email = "";
            return user;
        }
    }
}
