using Microsoft.AspNetCore.Mvc;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]//permite hacer validaciones automaticas respecto a la data recibida en nuestro controlador
    [Route("api/autores")] //ruta del controlador
    public class AutoresController:ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Autor>> Get()
        {
            return new List<Autor> (){ 
                new Autor() { ID = 1, Name = "Juan Lopez", Edad = 25},
                new Autor() { ID = 2, Name = "Marcos Perez", Edad = 28},
                new Autor() { ID = 3, Name = "Maria Antonieta", Edad = 28}
            };
        }
        

    }
}
