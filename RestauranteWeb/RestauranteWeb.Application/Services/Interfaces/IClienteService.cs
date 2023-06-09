﻿using RestauranteWeb.Application.DTOs;

namespace RestauranteWeb.Application.Services.Interfaces
{
	public interface IClienteService
	{
		Task<ResultService<ClienteDTO>> CreateAsync(ClienteDTO clienteDTO);
		Task<ResultService<ICollection<ClienteDTO>>> GetAsync();
		Task<ResultService<ClienteDTO>> GetByIdAsync(int id);
		Task<ResultService> UpdateAsync(ClienteDTO clienteDTO);
		Task<ResultService> DeleteAsync(int id);
	}
}
