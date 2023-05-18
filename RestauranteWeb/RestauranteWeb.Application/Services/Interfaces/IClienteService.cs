using RestauranteWeb.Application.DTOs;
using System;

namespace RestauranteWeb.Application.Services.Interfaces
{
    public interface IClienteService
    {
        Task<ResultService<ClienteDTO>> CreateAsync(ClienteDTO clienteDTO);
    }
}
