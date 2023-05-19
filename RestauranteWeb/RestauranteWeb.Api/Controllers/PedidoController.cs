using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Application.DTOs;
using RestauranteWeb.Application.Services;
using RestauranteWeb.Application.Services.Interfaces;
using RestauranteWeb.Domain.Validations;

namespace RestauranteWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PedidoDTO pedidoDTO)
        {

            try
            {
                var resultado = await _pedidoService.CreateAsync(pedidoDTO);
                if (resultado.ComSucesso)
                {
                    return Ok(resultado);
                }
                return BadRequest(resultado);
            }
            catch(DomainValidationException err)
            {
                var resultado = ResultService.Falha(err.Message);
                return BadRequest(resultado);
            }

        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
                var resultado = await _pedidoService.GetAsync();
                if (resultado.ComSucesso)
                {
                    return Ok(resultado);
                }
                return BadRequest(resultado);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var resultado = await _pedidoService.GetByIdAsync(id);
            if (resultado.ComSucesso)
            {
                return Ok(resultado);
            }
            return BadRequest(resultado);

        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] PedidoDTO pedidoDTO)
        {

            try
            {
                var resultado = await _pedidoService.UpdateAsync(pedidoDTO);
                if (resultado.ComSucesso)
                {
                    return Ok(resultado);
                }
                return BadRequest(resultado);
            }
            catch (DomainValidationException err)
            {
                var resultado = ResultService.Falha(err.Message);
                return BadRequest(resultado);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var resultado = await _pedidoService.DeleteAsync(id);
            if (resultado.ComSucesso)
            {
                return Ok(resultado);
            }
            return BadRequest(resultado);

        }

    }
}
