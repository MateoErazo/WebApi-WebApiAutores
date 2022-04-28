﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;
namespace WebApiAutores.Controllers
{

    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext Context;
        public LibrosController(ApplicationDbContext context)
        {
            this.Context = context;
        }


        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {
            var existeAutor = await Context.Autores.AnyAsync(x => x.ID == libro.AutorId);
            if (!existeAutor)
            {
                return BadRequest($"no existe un autor con el Id {libro.AutorId}");
            }

            Context.Add(libro);
            await Context.SaveChangesAsync();
            return Ok();
        }


    }
}
