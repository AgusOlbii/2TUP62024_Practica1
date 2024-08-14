// Reciba el precio de un producto (valor positivo), la cantidad a comprar y la forma de pagar (efectivo o tarjeta).
// Si la forma de pago es mediante tarjeta, debe recibir también el número de la misma(inventado), verificar que sean 16 dígitos y retornar el valor a pagar con un 10% de recargo.
// Si la forma de pago es mediante efectivo, retorna el valor a pagar.
// Si la forma de pago no es tarjeta ni efectivo, debe retornar un status code del grupo de los 400.
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class Ej6Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Get(int price, int cant, string payMethod, string? cardNumber = null)
    {
        // Verificar que el precio y la cantidad sean positivos
        if (price <= 0 || cant <= 0)
        {
            return BadRequest("El precio y la cantidad deben ser valores positivos.");
        }

        // Normalizar la forma de pago a minúsculas y quitar espacios en blanco
        string normalizedPayMethod = payMethod.Trim().ToLower();

        // Calcular el valor total sin recargos
        int total = price * cant;

        if (normalizedPayMethod == "efectivo")
        {
            return Ok($"El valor a pagar es: {total}");
        }
        else if (normalizedPayMethod == "tarjeta")
        {
            // Verificar que se haya proporcionado un número de tarjeta
            if (string.IsNullOrWhiteSpace(cardNumber))
            {
                return BadRequest("Debe proporcionar un número de tarjeta.");
            }

            // Verificar que el número de tarjeta tenga 16 dígitos
            if (cardNumber.Length != 16 || !cardNumber.All(char.IsDigit))
            {
                return BadRequest("El número de tarjeta debe tener 16 dígitos.");
            }

            // Calcular el recargo del 10% por pago con tarjeta
            double totalConRecargo = total * 1.10;
            return Ok($"El valor a pagar con recargo es: {totalConRecargo}");
        }
        else
        {
            // Forma de pago inválida
            return BadRequest("La forma de pago no es válida. Debe ser 'efectivo' o 'tarjeta'.");
        }
    }
}

