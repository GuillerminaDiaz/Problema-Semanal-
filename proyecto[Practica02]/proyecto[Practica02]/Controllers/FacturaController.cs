using ArticulosLibrary.Entities;
using ArticulosLibrary.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace proyecto_Practica02_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private IFacturaService _service;
        public FacturaController()
        {
            _service = new FacturaService();
        }
        // GET: api/<FacturaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.GetAllFcaturas());
            }
            catch (Exception)
            {

                return StatusCode(500, "Hubo un problema interno");
            }
        }

        // GET api/<FacturaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_service.GetFactura( id));
            }
            catch (Exception)
            {

                return StatusCode(500, "Hubo un problema interno");
            }
        }

        // POST api/<FacturaController>
        [HttpPost]
        public IActionResult Post([FromBody] Factura oFactura)
        {
            try
            {
                if (_service.InsertFcatura(oFactura))
                {

                    return Ok("se ha creado la factura");
                }
                else
                {
                    return BadRequest("No se ha podido crear la factura");
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Hubo un problema interno");
            }
        }

        // PUT api/<FacturaController>/5
        [HttpPut("{id}")]
        public IActionResult Put( [FromBody] Factura oFactura, int id)
        {
            try
            {
                if (_service.GetFactura(id) == null)
                {
                    return NotFound("La factura no se ha encontrado");
                }if(_service.UpdateFactura(oFactura, id))
                {
                    return Ok("Se ha modificado la factura exitosamente");

                }
                else
                {
                    return BadRequest("Factura NO se ha podido actualizar");
                }

            }
            catch (Exception)
            {

                return StatusCode(500, "Hubo un problema interno");
            }
        }

       
    }
}
