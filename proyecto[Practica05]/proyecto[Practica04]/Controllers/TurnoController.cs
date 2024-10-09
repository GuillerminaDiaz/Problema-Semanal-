using Microsoft.AspNetCore.Mvc;
using ServicioDLL.Models;
using ServicioDLL.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace proyecto_Practica04_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private ITurnoRepository _repository;
        public TurnoController(ITurnoRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<TurnoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllTurno());
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno");
            }
        }

        
        // POST api/<TurnoController>
        [HttpPost]
        public IActionResult Post([FromBody] TTurno value)
        {
            try
            {
                if (_repository.CreateTurno(value))
                    return Ok("Se creó el turno");
                else
                    return BadRequest("Datos Incorrectos");
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno");
            }
        }

        // PUT api/<TurnoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TTurno value)
        {
            try
            {
                if (_repository.UpdateTurno(id, value))
                    return Ok("Se modifico el turno");
                else
                    return NotFound("No se encontro el turno a modificar");
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno");
            }
        }

        // DELETE api/<TurnoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_repository.DeleteTurno(id))
                    return Ok("Se eliminó el turno");
                else
                    return NotFound("No se encontro el turno a eliminar");
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno");
            }
        }
    }
}
