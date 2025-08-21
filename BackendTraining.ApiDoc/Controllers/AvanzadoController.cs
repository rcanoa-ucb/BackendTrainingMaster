using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendTraining.ApiDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvanzadoController : ControllerBase
    {
        #region 11 Clase Producto
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 999.99m },
            new Product { Id = 2, Name = "Mouse", Price = 19.99m },
            new Product { Id = 3, Name = "Teclado", Price = 25.60m }
        };

        [HttpGet("products")]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }
        #endregion

        #region 12 Herencia: Empleado y Gerente
        public abstract class Empleado
        {
            public string Nombre { get; set; }
            public abstract decimal CalcularSalario();
        }

        public class Gerente : Empleado
        {
            public override decimal CalcularSalario()
            {
                return 5000m;
            }
        }

        public class Contador : Empleado
        {
            public override decimal CalcularSalario()
            {
                return 1000m;
            }
        }

        [HttpGet("empleados")]
        public IActionResult ObtenerEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>
            {
                new Gerente { Nombre = "Carlos" },
                new Contador { Nombre = "Pablo" },
                new Contador { Nombre = "Maria" },
            };

            return Ok(empleados);
        }

        #endregion

        #region 13 Interfaces: ICalculadora
        public interface ICalculadora
        {
            int Sumar(int a, int b);
        }

        public class Calculadora : ICalculadora
        {
            public int Sumar(int a, int b)
            {
                return a + b;
            }
        }

        [HttpPost("calcular")]
        public IActionResult Calcular([FromServices] ICalculadora calculadora, int a, int b)
        {
            int resultado = calculadora.Sumar(a, b);
            return Ok(resultado);
        }
        #endregion

        #region 14 Polimorfismo: Animales
        public class AnimalRequest
        {
            public required string Tipo { get; set; }
        }
        public abstract class Animal
        {
            public abstract string Sonido();
        }

        public class Perro : Animal
        {
            public override string Sonido() => "Guau guau!";
        }

        public class Gato : Animal
        {
            public override string Sonido() => "Miau miau!";
        }

        public class Vaca : Animal
        {
            public override string Sonido() => "Muu muu!";
        }

        [HttpPost("hablar")]
        public IActionResult Hablar([FromBody] AnimalRequest request)
        {
            Animal animal = request.Tipo.ToLower() switch
            {
                "perro" => new Perro(),
                "gato" => new Gato(),
                "vaca" => new Vaca(),
                _ => throw new ArgumentException("Animal no reconocido. Use: perro, gato o vaca")
            };

            return Ok($"El {request.Tipo} dice: {animal.Sonido()}");
        }
        #endregion
    }
}
