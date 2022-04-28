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
        public async Task<List<Autor>> Get()
        {
            //return new List<Autor> (){ 
            //    new Autor() { ID = 1, Name = "Juan Lopez", Edad = 25},
            //    new Autor() { ID = 2, Name = "Marcos Perez", Edad = 28},
            //    new Autor() { ID = 3, Name = "Maria Antonieta", Edad = 28}
            //};

            return await Context.Autores.Include(x => x.Libros).ToListAsync();
        }

        [HttpGet("primero")]//api/autores/primero?nombre=Mateo&apellido=Erazo
        public async Task<ActionResult<Autor>> GetFirst([FromQuery] string valorQuery)
        {
            return await Context.Autores.FirstOrDefaultAsync();
        } 

        [HttpGet("CantLibros/{cant:int}")]
        public async Task<ActionResult<List<Autor>>> GetDosAutor([FromRoute] int cant)
        {
            var tieneLibros = await Context.Autores.AnyAsync(x => x.Libros.Count >= cant);

            if (!tieneLibros)
            {
                return NotFound();

            }

            return await Context.Autores.Where(x => x.Libros.Count >= cant).ToListAsync();
        }


        [HttpGet("{id:int}/{edad=18}")] 
        public async Task<ActionResult<Autor>> GetAutorId(int id, int edad)
        {
            var autor = await Context.Autores.Include(x => x.Libros).FirstOrDefaultAsync(x => x.ID == id);

            if (autor == null)  
            {
                return NotFound();
            }

            return autor;
        }


        [HttpGet("{nombre}/{apellido=erazo}")]
        public async Task<ActionResult<Autor>> GetAutorNom(string nombre)
        {
            var autor = await Context.Autores.Include(x => x.Libros).FirstOrDefaultAsync(x => x.Nombre.Contains(nombre));

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Autor autor)
        {
            Context.Add(autor);
            await Context.SaveChangesAsync(); //guarda los cambios de manera asincrona
            return Ok();
        }


        [HttpPut("{id:int}")]//api/autores/1  Este es un parametro de ruta
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if (autor.ID != id)
            {
                return BadRequest("El id del autor no coincide con el id de la URL");
                    
            }

            var existe = await Context.Autores.AnyAsync(x => x.ID == id);

            if (!existe)
            {
                return NotFound();
            }

            Context.Update(autor);
            await Context.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id:int}")]
        public async Task <ActionResult> Delete(int id)
        {
            var existe = await Context.Autores.AnyAsync(x => x.ID == id);

            if (!existe)
            {
                return NotFound();
            }
            
                Context.Remove(new Autor() { ID = id}); //es una instancia de autor para que EF sepa que debe eliminar
                await Context.SaveChangesAsync();
                return Ok();

        }
    }
}
