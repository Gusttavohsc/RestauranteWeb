using AutoMapper;
using RestauranteWeb.Application.DTOs;
using RestauranteWeb.Application.DTOs.Validations;
using RestauranteWeb.Application.Services.Interfaces;
using RestauranteWeb.Domain.Entities;
using RestauranteWeb.Domain.Repositories;
using System;

namespace RestauranteWeb.Application.Services
{
    public class PedidoService : IPedidoService
    {

        private readonly IPratoRepository _pratoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoService(IPratoRepository pratoRepository, IClienteRepository clienteReposiroy, IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pratoRepository = pratoRepository;
            _clienteRepository = clienteReposiroy;
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PedidoDTO>> CreateAsync(PedidoDTO pedidoDTO)
        {
            if(pedidoDTO == null)
            {
                return ResultService.Falha<PedidoDTO>("Objeto deve ser informado");
            }

            var validacao = new PedidoDTOValidator().Validate(pedidoDTO);
            if(!validacao.IsValid)
            {
                return ResultService.RequestError<PedidoDTO>("Falha de validação", validacao);
            }

            var idPrato = await _pratoRepository.GetIdByPratoIdAsync(pedidoDTO.IdPrato);
            var idCliente = await _clienteRepository.GetIdByClienteIdAsync(pedidoDTO.IdCliente);
            var pedido = new Pedido(idPrato, idCliente, pedidoDTO.Status);
            
            var dado = await _pedidoRepository.CreateAsync(pedido);
            pedidoDTO.Id = dado.Id;

            return ResultService.Sucesso<PedidoDTO>(pedidoDTO);
        }

        public async Task<ResultService<ICollection<PedidosDetailDTO>>> GetAsync()
        {
            var pedido = await _pedidoRepository.GetAllSync();
            return ResultService.Sucesso(_mapper.Map<ICollection<PedidosDetailDTO>>(pedido));
        }

        public async Task<ResultService<PedidosDetailDTO>> GetByIdAsync(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            if(pedido == null)
            {
                return ResultService.Falha<PedidosDetailDTO>("Pedido não localizado");
            }
            return ResultService.Sucesso(_mapper.Map<PedidosDetailDTO>(pedido));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            if(pedido == null)
            {
                return ResultService.Falha("Pedido não localizado");
            }
            await _pedidoRepository.DeleteAsync(pedido);
            return ResultService.Sucesso("Pedido cancelado");
        }

        public async Task<ResultService<PedidoDTO>> UpdateAsync(PedidoDTO pedidoDTO)
        {
            if(pedidoDTO == null)
            {
                return ResultService.Falha<PedidoDTO>("Objeto deve ser informado");
            }

            var resultado = new PedidoDTOValidator().Validate(pedidoDTO);
            if (!resultado.IsValid)
            {
                return ResultService.RequestError<PedidoDTO>("Falha de validação", resultado);
            }

            var pedido = await _pedidoRepository.GetByIdAsync(pedidoDTO.Id);
            if(pedido == null)
            {
                return ResultService.Falha<PedidoDTO>("Pedido não localizado");
            }

            var idPrato = await _pratoRepository.GetIdByPratoIdAsync(pedidoDTO.IdPrato);
            var idCliente = await _clienteRepository.GetIdByClienteIdAsync(pedidoDTO.IdCliente);

            pedido.Editar(pedido.Id, idPrato, idCliente, pedidoDTO.Mesa, pedido.Valor, pedidoDTO.Status);
            await _pedidoRepository.EditAsync(pedido);
            return ResultService.Sucesso(pedidoDTO);

        }
    }
}
