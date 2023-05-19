using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteWeb.Application.DTOs.Validations
{
    public class PedidoDTOValidator : AbstractValidator<PedidoDTO> 
    {
        public PedidoDTOValidator()
        {
            RuleFor(x => x.IdCliente)
                .NotEmpty()
                .NotNull()
                .WithMessage("Campo de ID do cliente deve ser inserido");

            RuleFor(x => x.IdPrato)
                .NotEmpty()
                .NotNull()
                .WithMessage("Campo de ID da ordem deve ser informado");

            RuleFor(x => x.Mesa)
                .NotEmpty()
                .NotNull()
                .WithMessage("Campo mesa deve ser inserido");

            RuleFor(x => x.Valor)
                .NotEmpty()
                .NotNull()
                .WithMessage("Campo valor deve ser inserido");
        }
    }
}
