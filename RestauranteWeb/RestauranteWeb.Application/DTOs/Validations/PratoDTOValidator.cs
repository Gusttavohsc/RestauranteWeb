using FluentValidation;
using System;

namespace RestauranteWeb.Application.DTOs.Validations
{
    public class PratoDTOValidator : AbstractValidator<PratoDTO>
    {
        public PratoDTOValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser inserido");

            RuleFor(x => x.Categoria)
                .NotEmpty()
                .NotNull()
                .WithMessage("Categoria deve ser inserido");

            RuleFor(x => x.Preparo)
                .NotEmpty()
                .NotNull()
                .WithMessage("Tempo de preparo deve ser inserido");

            RuleFor(x => x.Valor)
                .GreaterThan(0)
                .WithMessage("Valor deve ser inserido");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("Descrição deve ser inserido");

        }
    }
}
