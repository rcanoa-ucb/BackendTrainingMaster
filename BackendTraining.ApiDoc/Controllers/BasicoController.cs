using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendTraining.ApiDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicoController : ControllerBase
    {
        #region 01 Hola Mundo 
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hola, mundo");
        }

        #endregion

        #region 02 Saludar por Nombre
        [HttpGet("{nombre}")]
        public IActionResult Saludar(string nombre)
        {
            string mensaje = $"Hola, {nombre}";
            return Ok(mensaje);
        }
        #endregion

        #region 03 Sumar Dos Números
        [HttpGet("sumar/{a}/{b}")]
        public IActionResult Sumar(int a, int b)
        {
            int resultado = a + b;
            return Ok(resultado);
        }
        #endregion

        #region 04 Verificar Par/Impar
        [HttpGet("par-impar/{numero}")]
        public IActionResult VerificarParImpar(int numero)
        {
            if (numero % 2 == 0)
            {
                return Ok("Par");
            }
            else
            {
                return Ok("Impar");
            }
        }
        #endregion

        #region 05 Lista de Frutas
        private static readonly List<string> frutas = new List<string>
        {
            "Manzana",
            "Banana",
            "Naranja",
            "Fresa",
            "Uva",
            "Sandia",
            "Mango",
            "Piña",
            "Limon",
            "Pera"
        };

        [HttpGet("frutas")]
        public IActionResult ObtenerFrutas()
        {
            return Ok(frutas);
        }
        #endregion
    }
}
