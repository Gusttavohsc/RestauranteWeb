using AutoMapper;
using RestauranteWeb.Application.DTOs;
using RestauranteWeb.Domain.Entities;
using System;


namespace RestauranteWeb.Application.Mappings
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<ClienteDTO, Cliente>();
        }
    }
}
