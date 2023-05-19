using RestauranteWeb.Application.DTOs;

namespace RestauranteWeb.Application.Services.Interfaces
{
	public interface IPratoService
	{
		Task<ResultService<PratoDTO>> CreateAsync(PratoDTO pratoDTO);
		Task<ResultService<PratoDTO>> GetByIdAsync(int id);
		Task<ResultService<ICollection<PratoDTO>>> GetPratosAsync(string? categoria, bool? status);
		Task<ResultService> UpdateAsync(PratoDTO pratoDTO);
		Task<ResultService> DeleteAsync(int id);
	}
}
