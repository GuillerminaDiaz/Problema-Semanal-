using ArticulosLibrary.Entities;
using ArticulosLibrary.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace proyecto_Practica02_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private IArticuloService service;
        public ArticulosController()
        {
            service = new ArticuloService();
        }
        // GET: api/<ArticulosController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var lst = service.GetAllArticulos();
                if(lst.Count==0)
                    return NotFound("Lista sin articulos");
                
                return Ok(lst);
            }
            catch (Exception)
            {

                return StatusCode(500, "No se pudo obtener la lista de articulos");
            }
        }

        // GET api/<ArticulosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Articulo art = service.GetArticulo(id);
                if(art==null)
                    return NotFound("No se pencuentra el articulo");

                return Ok(art);
            }
            catch (Exception)
            {

                return StatusCode(500, "No se pudo obtener el articulo");
            }
        }

        // POST api/<ArticulosController>
        [HttpPost]
        public IActionResult Post([FromBody] Articulo oArticulo)
        {
            try
            {
                if (oArticulo == null)
                    return BadRequest("Datos incorrectos");

                if (service.InsertArticulo(oArticulo))
                    return Ok("Articulo agregado con exito");
                else
                    return StatusCode(500, "No se pudo agregar el articulo");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // PUT api/<ArticulosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Articulo oArticulo)
        {
            try
            {
                if (oArticulo == null)
                    return BadRequest("Datos incorrectos");

                if (service.UpdateArticulo(oArticulo, id))
                    return Ok("Articulo modificado con exito");
                else
                    return StatusCode(500, "No se pudo modificar el articulo");
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno");
            }
        }

        // DELETE api/<ArticulosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (service.DeleteArticulo(id))
                    return Ok("El articulo se ha eliminado con exito");
                else
                    return StatusCode(500, "No se ha podido eliminar el articulo");
            }
            catch (Exception)
            {

                return StatusCode(500, "Error interno");
            }
        }
    }
}
