using AutoMapper;
using RestauranteWeb.Application.DTOs;
using RestauranteWeb.Domain.Entities;

namespace RestauranteWeb.Application.Mappings
{
	public class DomainToDtoMapping : Profile
	{
		public DomainToDtoMapping()
		{
			CreateMap<Cliente, ClienteDTO>();
			CreateMap<Prato, PratoDTO>();
			CreateMap<Pedido, PedidosDetailDTO>()
				.ForMember(x => x.Cliente, opt => opt.Ignore())
				.ForMember(x => x.Prato, opt => opt.Ignore())
				.ConstructUsing((model, context) =>
				{
					var dto = new PedidosDetailDTO()
					{
						Id = model.Id,
						Cliente = model.Cliente.Nome,
						Prato = model.Prato.Nome,
						Status = model.Status,
					};
					return dto;
				});
		}
	}
}
