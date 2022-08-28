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
    public class ClientesController : ControllerBase
    {
        private readonly IServicioCliente _clienteServicio;
        public ClientesController(IServicioCliente ServicioCliente)
        {
            _clienteServicio = ServicioCliente;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await _clienteServicio.ObtenerTodos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error al recuperar datos de la Base");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            try
            {
                var result = await _clienteServicio.ObtenerXId(id);

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
        public async Task<ActionResult<Cliente>> PostCliente([FromBody] Cliente cliente)
        {
            await _clienteServicio.AnadirCliente(cliente);
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.clienteId }, cliente);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.clienteId)
            {
                return BadRequest();
            }
            try
            {
                await _clienteServicio.ActualizarCliente(cliente);
                return Ok("Registro Actualizado Exitosamente");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExiste(id))
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

        private bool ClienteExiste(int id)

        {
            return _clienteServicio.ExisteCliente(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> BorrarEstudiante(int id)
        {

            var cliente = await _clienteServicio.ObtenerXId(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _clienteServicio.BorrarCliente(id);

            return Ok();
        }
    }
}
