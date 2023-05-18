using FluentValidation;

namespace RestauranteWeb.Application.DTOs.Validations
{
    public class ClienteDTOValidator : AbstractValidator<ClienteDTO>
    {
        public ClienteDTOValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado");

            RuleFor(x => x.Documento)
                .NotEmpty()
                .NotNull()
                .WithMessage("Documento deve ser informado");
        }
    }
}
