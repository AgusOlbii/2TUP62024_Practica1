using System.Linq;
using Microsoft.AspNetCore.Mvc;
// 1) Dada una lista de números enteros, escriba una consulta que devuelva la lista de números mayores que 30 y menores que 100.
// Ejemplo: [67, 92, 153, 15] → 67, 92
namespace Web;

[ApiController]
[Route("[controller]")]
public class ej1LinqController : ControllerBase
{
    [HttpGet("[action]")]
    public ActionResult Get(){
        List<int> numbers = [67, 92, 153, 15];
        List<int> newList = new List<int>();
        var numQuery = numbers.Where(x => x < 100 && x > 30).Select(x => x);

        foreach (var num in numQuery)
        {
            newList.Add(num);
        }
        return Ok(newList);
    }
}