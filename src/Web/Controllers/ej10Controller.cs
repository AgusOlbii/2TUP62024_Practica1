// Reciba un número entero de inicio y un número entero de fin.
// Debe verificar que la diferencia entre inicio y fin sea menor a 1000.
// Debe retornar una lista de número que inicie en el valor de inicio y termine en el valor de fin.
// Idem ejercicio 7, pero creando dos listas, una con los números pares y otra con los números impares.
// Retornar las dos listas.

using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ej10Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Get(int number1, int number2)
    {
        if (number1 - number2 > 1000)
        {
            return BadRequest("La diferencia entre el numero de Inicio y Fin debe ser menor a 1000");
        }

        List<int> numberRange = new List<int>();
        for (int i = number1; i <= number2; i++)
        {
            numberRange.Add(i);
        }

        List<int> evenNumber = new List<int>();
        List<int> oddNumber = new List<int>();

        foreach (int number in numberRange)
        {
            if (number % 2 == 0){
                evenNumber.Add(number);
            }
            else
            {
                oddNumber.Add(number);
            }
        }
            var result = new 
            {
                EvenNumbers = evenNumber,
                OddNumbers = oddNumber,
            };
            return Ok(result);
    }
}