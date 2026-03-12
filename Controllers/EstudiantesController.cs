using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EstudiantesAPI.Context;
using EstudiantesAPI.DTOs;
using EstudiantesAPI.Models;

namespace EstudiantesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstudiantesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Estudiantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiantes()
        {
            var estudiantes = await _context.Estudiantes
                .Where(e => e.Activo)
                .ToListAsync();

            return Ok(estudiantes);
        }

        // GET: api/Estudiantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);

            if (estudiante == null)
                return NotFound(new { mensaje = $"No se encontró el estudiante con ID {id}." });

            return Ok(estudiante);
        }

        // POST: api/Estudiantes
        [HttpPost]
        public async Task<ActionResult<Estudiante>> PostEstudiante(EstudianteDTO estudianteDTO)
        {
            var estudiante = new Estudiante
            {
                Nombre = estudianteDTO.Nombre,
                Apellido = estudianteDTO.Apellido,
                Correo = estudianteDTO.Correo,
                Carrera = estudianteDTO.Carrera,
                Nota = estudianteDTO.Nota,
                Activo = estudianteDTO.Activo
            };

            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstudiante), new { id = estudiante.Id }, estudiante);
        }

        // PUT: api/Estudiantes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, EstudianteDTO estudianteDTO)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);

            if (estudiante == null)
                return NotFound(new { mensaje = $"No se encontró el estudiante con ID {id}." });

            estudiante.Nombre = estudianteDTO.Nombre;
            estudiante.Apellido = estudianteDTO.Apellido;
            estudiante.Correo = estudianteDTO.Correo;
            estudiante.Carrera = estudianteDTO.Carrera;
            estudiante.Nota = estudianteDTO.Nota;
            estudiante.Activo = estudianteDTO.Activo;

            _context.Entry(estudiante).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(estudiante);
        }

        // DELETE: api/Estudiantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);

            if (estudiante == null)
                return NotFound(new { mensaje = $"No se encontró el estudiante con ID {id}." });

            estudiante.Activo = false;
            _context.Entry(estudiante).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = $"Estudiante con ID {id} eliminado correctamente." });
        }
    }
}