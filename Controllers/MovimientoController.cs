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
    public class MovimientoController : ControllerBase
    {
        private readonly IServicioMovimiento _movimientoServicio;
        public MovimientoController(IServicioMovimiento servicioMovimiento)
        {
            _movimientoServicio = servicioMovimiento;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await _movimientoServicio.ObtenerTodos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error al recuperar datos de la Base");
            }
        }
      

        [HttpGet("{id}")]
        public async Task<ActionResult<Movimiento>> GetMovimiento(int id)
        {
            try
            {
                var result = await _movimientoServicio.ObtenerXId(id);

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
        public async Task<ActionResult<Movimiento>> PostMovimiento([FromBody] Movimiento movimiento)
        {
            await _movimientoServicio.AnadirMovimiento(movimiento);
            return CreatedAtAction(nameof(GetMovimiento), new { id = movimiento.idMovimiento }, movimiento);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Movimiento movimiento)
        {
            if (id != movimiento.idMovimiento)
            {
                return BadRequest();
            }
            try
            {
                await _movimientoServicio.ActualizarMovimiento(movimiento);
                return Ok("Registro Actualizado Exitosamente");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimientoExiste(id))
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

        private bool MovimientoExiste(int id)

        {
            return _movimientoServicio.ExisteMovimiento(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Movimiento>> BorrarMovimiento(int id)
        {

            var persona = await _movimientoServicio.ObtenerXId(id);
            if (persona == null)
            {
                return NotFound();
            }

            _movimientoServicio.BorrarMovimiento(id);

            return Ok();
        }
    }
}
