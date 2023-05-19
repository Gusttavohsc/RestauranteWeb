using Microsoft.AspNetCore.Mvc;
using RestauranteWeb.Application.DTOs;
using RestauranteWeb.Application.Services.Interfaces;

namespace RestauranteWeb.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PratoController : ControllerBase
	{
		private readonly IPratoService _pratoService;

		public PratoController(IPratoService pratoService)
		{
			_pratoService = pratoService;
		}

		[HttpPost]
		public async Task<ActionResult> PostAsync([FromBody] PratoDTO pratoDTO)
		{
			var resultado = await _pratoService.CreateAsync(pratoDTO);
			if (resultado.ComSucesso)
			{
				return Ok(resultado);
			}
			return BadRequest(resultado);
		}

		[HttpGet]
		public async Task<ActionResult> GetPratosAsync(string? categoria = null, bool? status = null)
		{
			var resultado = await _pratoService.GetPratosAsync(categoria, status);
			if (resultado.ComSucesso)
			{
				var pratos = resultado.Dado;
				if (!string.IsNullOrEmpty(categoria) || status.HasValue)
				{
					pratos = pratos.Where(x =>
							(string.IsNullOrEmpty(categoria) || x.Categoria.Contains(categoria)) &&
							(!status.HasValue || x.Status == status.Value)
					).ToList();
				}

				return Ok(pratos);
			}

			return BadRequest(resultado);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult> GetByIdAsync(int id)
		{
			var resultado = await _pratoService.GetByIdAsync(id);
			if (resultado.ComSucesso)
			{
				return Ok(resultado);
			}
			return BadRequest(resultado);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateAsync([FromBody] PratoDTO pratoDTO)
		{
			var resultado = await _pratoService.UpdateAsync(pratoDTO);
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
			var resultado = await _pratoService.DeleteAsync(id);
			if (resultado.ComSucesso)
			{
				return Ok(resultado);
			}
			return BadRequest(resultado);
		}
	}
}
