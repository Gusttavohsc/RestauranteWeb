using AutoMapper;
using RestauranteWeb.Application.DTOs;
using RestauranteWeb.Application.DTOs.Validations;
using RestauranteWeb.Application.Services.Interfaces;
using RestauranteWeb.Domain.Entities;
using RestauranteWeb.Domain.Repositories;

namespace RestauranteWeb.Application.Services
{
	public class PratoService : IPratoService
	{
		private readonly IPratoRepository _pratoRepository;
		private readonly IMapper _mapper;

		public PratoService(IPratoRepository pratoRepository, IMapper mapper)
		{
			_pratoRepository = pratoRepository;
			_mapper = mapper;
		}

		public async Task<ResultService<PratoDTO>> CreateAsync(PratoDTO pratoDTO)
		{
			if (pratoDTO == null)
			{
				return ResultService.Falha<PratoDTO>("Objeto deve ser informado");
			}

			var resultado = new PratoDTOValidator().Validate(pratoDTO);
			if (!resultado.IsValid)
			{
				return ResultService.RequestError<PratoDTO>("Problemas na validação", resultado);
			}

			var prato = _mapper.Map<Prato>(pratoDTO);
			var dado = await _pratoRepository.CreateAsync(prato);
			return ResultService.Sucesso<PratoDTO>(_mapper.Map<PratoDTO>(dado));

		}

		public async Task<ResultService<ICollection<PratoDTO>>> GetPratosAsync(string? categoria, bool? status)
		{
			var pratos = await _pratoRepository.GetPratosAsync();
			return ResultService.Sucesso<ICollection<PratoDTO>>(_mapper.Map<ICollection<PratoDTO>>(pratos));
		}

		public async Task<ResultService<PratoDTO>> GetByIdAsync(int id)
		{
			var prato = await _pratoRepository.GetByIdAsync(id);
			if (prato == null)
			{
				return ResultService.Falha<PratoDTO>("Prato não localizado");
			}
			return ResultService.Sucesso<PratoDTO>(_mapper.Map<PratoDTO>(prato));
		}

		public async Task<ResultService> UpdateAsync(PratoDTO pratoDTO)
		{
			if (pratoDTO == null)
			{
				return ResultService.Falha("Prato não encontrado");
			}
			var validacao = new PratoDTOValidator().Validate(pratoDTO);
			if (!validacao.IsValid)
			{
				return ResultService.RequestError("Falha na validação", validacao);
			}

			var prato = await _pratoRepository.GetByIdAsync(pratoDTO.Id);
			if (prato == null)
			{
				return ResultService.Falha("Prato não foi localizado");
			}

			prato = _mapper.Map<PratoDTO, Prato>(pratoDTO, prato);
			await _pratoRepository.EditAsync(prato);
			return ResultService.Sucesso("Prato alterado com sucesso");
		}

		public async Task<ResultService> DeleteAsync(int id)
		{
			var prato = await _pratoRepository.GetByIdAsync(id);
			if (prato == null)
			{
				return ResultService.Falha("Prato não foi localizado");
			}
			await _pratoRepository.DeleteAsync(prato);
			return ResultService.Sucesso($"Prato '{prato.Nome}' removido com sucesso");
		}
	}
}
