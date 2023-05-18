using AutoMapper;
using RestauranteWeb.Application.DTOs;
using RestauranteWeb.Domain.Entities;
using System;

namespace RestauranteWeb.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Cliente, ClienteDTO>();
        }
    }
}
