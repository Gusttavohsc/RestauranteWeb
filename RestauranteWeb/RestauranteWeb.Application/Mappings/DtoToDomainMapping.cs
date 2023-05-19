using AutoMapper;
using RestauranteWeb.Application.DTOs;
using RestauranteWeb.Domain.Entities;


namespace RestauranteWeb.Application.Mappings
{
	public class DtoToDomainMapping : Profile
	{
		public DtoToDomainMapping()
		{
			CreateMap<ClienteDTO, Cliente>();
			CreateMap<PratoDTO, Prato>();
		}
	}
}
