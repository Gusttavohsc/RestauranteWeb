using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Application.DTOs;
using RestauranteWeb.Application.Services;
using RestauranteWeb.Application.Services.Interfaces;

namespace RestauranteWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDTO clienteDTO)
        {
            var resultado = await _clienteService.CreateAsync(clienteDTO);
            if (resultado.ComSucesso)
            {
                return Ok(resultado);
            }

            return BadRequest(resultado);
        }

    }
}
