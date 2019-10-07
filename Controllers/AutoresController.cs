using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using primerWebAPIVSCode.Data;
using primerWebAPIVSCode.Models;

namespace primerWebAPIVSCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly DbContextPostgreSQL _context;
        public AutoresController(DbContextPostgreSQL context) { 
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAutores() {
            var autores = await _context.Autores.ToListAsync();
            return Ok(autores);
        }

        [HttpGet("{id}", Name = "ObtenerAutor")]
        public async Task<IActionResult> getAutor(int id) {
            var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == id);
            if(autor == null) {
                return NotFound("Recurso no encontrado");
            }
            return Ok(autor);
        }

        [HttpPost]
        public async Task<IActionResult> addAutor([FromBody] Autor autor) {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
            //Nombre de la ruta donde se encuentra el recurso, parametro de la accion, en el cuerpo de la respuesta se coloca el tipo de dato a retornar
            return new CreatedAtRouteResult("ObtenerAutor", new { id = autor.Id}, autor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> modifyAutor(int id, [FromBody] Autor autor) {
            if(id != autor.Id) {
                return BadRequest();
            }

            _context.Entry(autor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteAutor(int id) {
            var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == id);
            
            if(autor == null) {
                return NotFound("Recurso no encontrado");
            }

            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
            return Ok(autor);


        }
        


            
        
    }
}