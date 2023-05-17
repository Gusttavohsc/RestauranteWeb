using RestauranteWeb.Domain.Validations;
using System;
using System.Security.Principal;

namespace RestauranteWeb.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; private set; }
        public int IdCliente { get; private set; }
        public int IdPrato { get; private set; }
        public int Mesa { get; private set; }
        public TimeSpan Preparo { get; private set; }
        public decimal Valor { get; private set; }

        public Cliente Cliente { get; set; }
        public Prato Prato { get; set; }

        public Pedido(int idCliente, int idPrato, int mesa, TimeSpan preparo, decimal valor)
        {
            ValidarCampos(idCliente, idPrato, mesa, preparo, valor);
        }

        public Pedido(int id, int idCliente, int idPrato, int mesa, TimeSpan preparo, decimal valor)
        {
            DomainValidationException.Validar(id < 0, "Campo ID do pedido deve ser informado");
            ValidarCampos(idCliente, idPrato, mesa, preparo, valor);
            Id = id;
        }

        private void ValidarCampos(int idCliente, int idPrato, int mesa, TimeSpan preparo, decimal valor)
        {
            DomainValidationException.Validar(idCliente < 0, "Campo ID do cliente deve ser preenchido");
            DomainValidationException.Validar(idPrato < 0, "Campo ID do prato deve ser preenchido");
            DomainValidationException.Validar(mesa <= 0, "Campo mesa deve ser preenchido");
            DomainValidationException.Validar(preparo == TimeSpan.Zero, "Campo preparo deve ser preenchido");
            DomainValidationException.Validar(valor < 0, "Campo valor deve ser preenchido");

            IdCliente = idCliente;
            IdPrato = idPrato;
            Mesa = mesa;
            Preparo = preparo;
            Valor = valor;
        }

    }
}
