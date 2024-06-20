using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Model;
using Repository.Repository;
using Services;

namespace api.ParcialRafaelRodi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaRepository _facturaRepository;
        private readonly FacturaService _facturaService;

        public FacturaController(FacturaRepository facturaRepository, FacturaService facturaService)
        {
            _facturaRepository = facturaRepository;
            _facturaService = facturaService;
        }

        [HttpPost("CrearFactura")]
        public IActionResult PostFactura([FromBody] FacturaModel factura)
        {
            var validador = new Services.FacturaService.ValidarFacturaFluente(_facturaRepository);
            var res = validador.Validate(factura);
            if (!res.IsValid)
            {
                return BadRequest(res.Errors);
            }

            _facturaRepository.AddFactura(factura);
            return Ok("Factura agregada correctamente.");
        }

        [HttpGet("ObtenerFacturas")]
        public IActionResult GetAllFacturas()
        {
            var facturas = _facturaRepository.GetAllFacturas();
            return Ok(facturas);
        }

        [HttpGet("ObtenerFacturaPorId/{id}")]
        public IActionResult GetFacturaById(int id)
        {
            var factura = _facturaRepository.GetFacturaById(id);
            if (factura == null)
                return NotFound("Factura no encontrada.");

            return Ok(factura);
        }

        [HttpPut("Actualizar")]
        public IActionResult PutFactura([FromBody] FacturaModel factura)
        {
            var exFact = _facturaRepository.GetFacturaById(factura.Id);
            if (exFact == null)
                return NotFound("ID no encontrado.");

            var val = new Services.FacturaService.ValidarFacturaFluente(_facturaRepository);
            var res = val.Validate(factura);

            var existingFactura = _facturaRepository.GetFacturaById(factura.Id);
            if (existingFactura == null)
                return NotFound("Factura no encontrada.");

            existingFactura.Id_cliente = factura.Id_cliente;
            existingFactura.Nro_Factura = factura.Nro_Factura;
            existingFactura.Fecha_Hora = factura.Fecha_Hora;
            existingFactura.Total = factura.Total;
            existingFactura.Total_iva5 = factura.Total_iva5;
            existingFactura.Total_iva10 = factura.Total_iva10;
            existingFactura.Total_iva = factura.Total_iva;
            existingFactura.Total_letras = factura.Total_letras;
            existingFactura.Sucursal = factura.Sucursal;

            _facturaRepository.UpdateFactura(existingFactura);
            return Ok("Factura actualizada correctamente.");
        }

        [HttpDelete("Eliminar/{id}")]
        public IActionResult DeleteFactura(int id)
        {
            var existingFactura = _facturaRepository.GetFacturaById(id);
            if (existingFactura == null)
                return NotFound("Factura no encontrada.");

            _facturaRepository.DeleteFactura(id);
            return Ok("Factura eliminada correctamente.");
        }
    }
}
