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
    public class CuentaController : ControllerBase
    {
        private readonly IServicioCuenta _cuentaServicio;
        public CuentaController(IServicioCuenta ServicioCuenta)
        {
            _cuentaServicio = ServicioCuenta;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await _cuentaServicio.ObtenerTodos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error al recuperar datos de la Base");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cuenta>> GetCuenta(int id)
        {
            try
            {
                var result = await _cuentaServicio.ObtenerXId(id);

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
        public async Task<ActionResult<Cuenta>> PostCuenta([FromBody] Cuenta Cuenta)
        {
            await _cuentaServicio.AnadirCuenta(Cuenta);
            return CreatedAtAction(nameof(GetCuenta), new { id = Cuenta.idCuenta }, Cuenta);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Cuenta Cuenta)
        {
            if (id != Cuenta.idCuenta)
            {
                return BadRequest();
            }
            try
            {
                await _cuentaServicio.ActualizarCuenta(Cuenta);
                return Ok("Registro Actualizado Exitosamente");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuentaExiste(id))
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

        private bool CuentaExiste(int id)

        {
            return _cuentaServicio.ExisteCuenta(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cuenta>> BorrarCuenta(int id)
        {

            var cliente = await _cuentaServicio.ObtenerXId(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _cuentaServicio.BorrarCuenta(id);

            return Ok();
        }
    }
}
