using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServicioDLL.Models;
using ServicioDLL.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace proyecto_Practica04_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private IServicioService _service;
        public ServicioController(IServicioService service)
        {
            _service = service;
        }
        // GET: api/<ServicioController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocurrió un error interno");
            }
        }
        [HttpGet("promocion")]
        public IActionResult GetPromocion()
        {
            try
            {
                return Ok(_service.GetPromocion());
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocurrió un error interno");
            }
        }
        [HttpGet("costo")]
        public IActionResult GetPrecio([FromQuery] float precio)
        {
            try
            {
                return Ok(_service.GetSinPromocionCosto(precio));
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocurrió un error interno");
            }
        }

        // GET api/<ServicioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var service = _service.GetById(id);
                if (service != null)
                {
                    return Ok(service);

                }
                else
                {
                    return NotFound("El servicio no fue encontrado");
                }
                
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocurrió un error interno");
            }
        }

        // POST api/<ServicioController>
        [HttpPost]
        public IActionResult Post([FromBody] TServicio servicio)
        {
            try
            {
                if (servicio!=null)
                {
                    _service.Save(servicio);
                    return Ok("Se ha guardado el servicio correctamente");
                }
                else
                {
                    return BadRequest("Los datos ingresados son incorrectos");
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocurrió un error interno");
            }
        }

        // PUT api/<ServicioController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TServicio servicio)
        {
            try
            {
                if (servicio != null)
                {
                    _service.Update(servicio, id);
                    return Ok("Se ha modificado el servicio correctamente");
                }
                else
                {
                    return BadRequest("Los datos ingresados para la modificación son incorrectos");
                }
                
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocurrió un error interno");
            }
        }

        // DELETE api/<ServicioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                _service.Delete(id);

                return Ok("El servicio se ha eliminado correctamente");
                
                
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocurrió un error interno");
            }
        }
    }
}
