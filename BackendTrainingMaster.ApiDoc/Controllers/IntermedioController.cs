using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendTraining.ApiDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntermedioController : ControllerBase
    {
        #region 06 Buscar en Lista
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

        [HttpGet("buscar/{item}")]
        public IActionResult BuscarEnLista(string item)
        {
            if (frutas.Contains(item))
            {
                return Ok($"Se encontró {item}");
            }
            else
            {
                return NotFound("No encontrado");
            }
        }
        #endregion

        #region 07 Filtrar Números Pares
        [HttpPost("filtrar-pares")]
        public IActionResult FiltrarPares([FromBody] List<int> numeros)
        {
            List<int> pares = new List<int>();

            foreach (int num in numeros)
            {
                if (num % 2 == 0)
                {
                    pares.Add(num);
                }
            }

            return Ok(pares);
        }
        #endregion

        #region 08 Diccionario de Traducciones
        private static readonly Dictionary<string, string> traducciones =
            new Dictionary<string, string>
        {
            {"gato", "cat"},
            {"perro", "dog"},
            {"sol", "sun"},
            {"luna", "moon"},
            {"árbol", "tree"},
            {"coche", "car"},
            {"puerta", "door"},
            {"ventana", "window"},
            {"computadora", "computer"},
            {"teléfono", "phone"},
            {"papel", "paper"},
            {"bolígrafo", "pen"},
            {"llave", "key"},
            {"dinero", "money"},
            {"música", "music"},
            {"lluvia", "rain"},
            {"fuego", "fire"},
            {"tierra", "earth"},
            {"nube", "cloud"},
            {"estrella", "star"}
        };

        [HttpGet("traducir/{palabra}")]
        public IActionResult Traducir(string palabra)
        {
            if (traducciones.TryGetValue(palabra, out string traduccion))
            {
                return Ok(traduccion);
            }
            else
            {
                return NotFound("Palabra no encontrada");
            }
        }
        #endregion

        #region 09 Contador de Palabras
        [HttpPost("contar-palabras")]
        public IActionResult ContarPalabras([FromBody] string texto)
        //public IActionResult ContarPalabras()
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return BadRequest("Texto no válido");
            }

            string[] palabras = texto.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return Ok(palabras.Length);
        }
        #endregion

        #region 10 Stack de Operaciones
        private static Stack<string> stack = new Stack<string>();

        [HttpPost("stack/push/{item}")]
        public IActionResult Push(string item)
        {
            stack.Push(item);
            return Ok($"Item '{item}' añadido al stack");
        }

        [HttpGet("stack/pop")]
        public IActionResult Pop()
        {
            if (stack.Count == 0)
            {
                return BadRequest("Stack vacío");
            }

            string item = stack.Pop();
            return Ok(item);
        }

        #endregion
    }
}
