using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Application.DTOs;
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
		public async Task<ActionResult> PostAsync([FromBody] ClienteDTO clienteDTO)
		{
			var resultado = await _clienteService.CreateAsync(clienteDTO);
			if (resultado.ComSucesso)
			{
				return Ok(resultado);
			}

			return BadRequest(resultado);
		}

		[HttpGet]
		public async Task<ActionResult> GetAsync()
		{
			var result = await _clienteService.GetAsync();
			if (result.ComSucesso)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult> GetByIdAsync(int id)
		{
			var result = await _clienteService.GetByIdAsync(id);
			if (result.ComSucesso)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateAsync([FromBody] ClienteDTO clienteDTO)
		{
			var resultado = await _clienteService.UpdateAsync(clienteDTO);
			if (resultado.ComSucesso)
			{
				return Ok(resultado);
			}

			return BadRequest(resultado);
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<ActionResult> DeleteAsync(int id)
		{
			var resultado = await _clienteService.DeleteAsync(id);
			if (resultado.ComSucesso)
			{
				return Ok(resultado);
			}

			return BadRequest(resultado);
		}
	}
}
