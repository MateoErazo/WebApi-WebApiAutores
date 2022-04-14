using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]//permite hacer validaciones automaticas respecto a la data recibida en nuestro controlador
    [Route("api/autores")] //ruta del controlador
    public class AutoresController:ControllerBase
    {
        private readonly ApplicationDbContext Context;
        public AutoresController(ApplicationDbContext context)
        {
            this.Context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            //return new List<Autor> (){ 
            //    new Autor() { ID = 1, Name = "Juan Lopez", Edad = 25},
            //    new Autor() { ID = 2, Name = "Marcos Perez", Edad = 28},
            //    new Autor() { ID = 3, Name = "Maria Antonieta", Edad = 28}
            //};

            return await Context.Autores.ToListAsync();
        }



        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            Context.Add(autor);
            await Context.SaveChangesAsync(); //guarda los cambios de manera asincrona
            return Ok();
        }


    }
}
