using AutoMapper;
using RestauranteWeb.Application.DTOs;
using RestauranteWeb.Application.DTOs.Validations;
using RestauranteWeb.Application.Services.Interfaces;
using RestauranteWeb.Domain.Entities;
using RestauranteWeb.Domain.Repositories;
using System;

namespace RestauranteWeb.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _personRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ClienteDTO>> CreateAsync(ClienteDTO clienteDTO)
        {
            if (clienteDTO == null)
            {
                return ResultService.Falha<ClienteDTO>("Objeto deve ser informado");

            }

            var resultado = new ClienteDTOValidator().Validate(clienteDTO);

            if (!resultado.IsValid)
            {
                return ResultService.RequestError<ClienteDTO>("Problemas de validade!", resultado);
            }

            var cliente = _mapper.Map<Cliente>(clienteDTO);
            var dado = await _personRepository.CreateAsync(cliente);
            return ResultService.Sucesso<ClienteDTO>(_mapper.Map<ClienteDTO>(dado));

        }
    }
}
