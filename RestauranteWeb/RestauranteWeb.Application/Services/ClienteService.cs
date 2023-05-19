using AutoMapper;
using RestauranteWeb.Application.DTOs;
using RestauranteWeb.Application.DTOs.Validations;
using RestauranteWeb.Application.Services.Interfaces;
using RestauranteWeb.Domain.Entities;
using RestauranteWeb.Domain.Repositories;

namespace RestauranteWeb.Application.Services
{
	public class ClienteService : IClienteService
	{
		private readonly IClienteRepository _clienteRepository;
		private readonly IMapper _mapper;

		public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
		{
			_clienteRepository = clienteRepository;
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
			var dado = await _clienteRepository.CreateAsync(cliente);
			return ResultService.Sucesso<ClienteDTO>(_mapper.Map<ClienteDTO>(dado));

		}

		public async Task<ResultService> DeleteAsync(int id)
		{
			var cliente = await _clienteRepository.GetByIdAsync(id);
			if (cliente == null)
			{
				return ResultService.Falha<ClienteDTO>("Cliente não encontrado");
			}

			await _clienteRepository.DeleteAsync(cliente);
			return ResultService.Sucesso($"Cliente ID: {id}, foi deletado");
		}

		public async Task<ResultService<ICollection<ClienteDTO>>> GetAsync()
		{
			var cliente = await _clienteRepository.GetClientesAsync();
			return ResultService.Sucesso<ICollection<ClienteDTO>>(_mapper.Map<ICollection<ClienteDTO>>(cliente));
		}

		public async Task<ResultService<ClienteDTO>> GetByIdAsync(int id)
		{
			var cliente = await _clienteRepository.GetByIdAsync(id);
			if (cliente == null)
			{
				return ResultService.Falha<ClienteDTO>("Cliente não encontrado");
			}
			return ResultService.Sucesso(_mapper.Map<ClienteDTO>(cliente));
		}

		public async Task<ResultService> UpdateAsync(ClienteDTO clienteDTO)
		{
			if (clienteDTO == null)
			{
				return ResultService.Falha("Dados devem ser informados");
			}

			var validacao = new ClienteDTOValidator().Validate(clienteDTO);
			if (!validacao.IsValid)
			{
				return ResultService.RequestError("Falha na validação dos campos", validacao);
			}

			var cliente = await _clienteRepository.GetByIdAsync(clienteDTO.Id);

			if (cliente == null)
			{
				return ResultService.Falha("Pessoa não encontrada");
			}

			cliente = _mapper.Map<ClienteDTO, Cliente>(clienteDTO, cliente);
			await _clienteRepository.EditAsync(cliente);
			return ResultService.Sucesso("Cliente alterado");


		}
	}
}
