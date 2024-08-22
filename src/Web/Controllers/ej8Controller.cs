// Reciba un número entero de inicio y un número entero de fin.
// Debe verificar que la diferencia entre inicio y fin sea menor a 1000.
// Debe retornar una lista de número que inicie en el valor de inicio y termine en el valor de fin.
// Idem ejercicio 7 pero usando un bucle while..
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ej8Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Get(int number1, int number2)
    {
        if (number1 - number2 > 1000)
        {
            return BadRequest("La diferencia entre el numero de Inicio y Fin debe ser menor a 1000");
        }

        List<int> numberRange = new List<int>();
        int i = 0;
        while (i <= number2)
        {
            numberRange.Add(i);
            i++;
            
        }
        return Ok(numberRange);
    }
}