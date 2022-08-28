using LuisCriolloPrueba.Modelos;
using LuisCriolloPrueba.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuisCriolloPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IServicioPersona _personaServicio;
        public PersonaController(IServicioPersona ServicioPersona)
        {
            _personaServicio = ServicioPersona;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await _personaServicio.ObtenerTodos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error al recuperar datos de la Base");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetPersona(int id)
        {
            try
            {
                var result = await _personaServicio.ObtenerXId(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Persona>> PostPersona([FromBody] Persona persona)
        {
            await _personaServicio.AnadirPersona(persona);
            return CreatedAtAction(nameof(GetPersona), new { id = persona.idPersona }, persona);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Persona persona)
        {
            if (id != persona.idPersona)
            {
                return BadRequest();
            }
            try
            {
                await _personaServicio.ActualizarPersona(persona);
                return Ok("Registro Actualizado Exitosamente");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExiste(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool PersonaExiste(int id)

        {
            return _personaServicio.ExistePersona(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cuenta>> BorrarCuenta(int id)
        {

            var persona = await _personaServicio.ObtenerXId(id);
            if (persona == null)
            {
                return NotFound();
            }

            _personaServicio.BorrarPersona(id);

            return Ok();
        }
    }
}
