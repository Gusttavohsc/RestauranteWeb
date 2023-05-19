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
        public decimal Valor { get; private set; }
        public string Status { get; private set; }

        public Cliente Cliente { get; set; }
        public Prato Prato { get; set; }

        public Pedido(int idCliente, int idPrato, int mesa, decimal valor, string status)
        {
            ValidarCampos(idCliente, idPrato, mesa, valor, status);
        }

        public Pedido(int id, int idCliente, int idPrato, int mesa, decimal valor, string status)
        {
            DomainValidationException.Validar(id < 0, "Campo ID do pedido deve ser informado");
            ValidarCampos(idCliente, idPrato, mesa, valor, status);
            Id = id;
        }

        public Pedido(int idPrato, int idCliente, string status)
        {
            IdPrato = idPrato;
            IdCliente = idCliente;
            Status = status;
        }

        public void Editar(int id, int idPrato, int idCliente, int mesa ,decimal valor, string status )
        {
            DomainValidationException.Validar(id <= 0, "ID deve ser informado");
            Id = id;
            ValidarCampos(idCliente, idPrato, mesa, valor , status);
            Mesa = mesa;

        }

        private void ValidarCampos(int idCliente, int idPrato, int mesa, decimal valor, string status)
        {
            DomainValidationException.Validar(idCliente <= 0, "Campo ID do cliente deve ser preenchido");
            DomainValidationException.Validar(idPrato <= 0, "Campo ID do prato deve ser preenchido");
            DomainValidationException.Validar(mesa <= 0, "Campo mesa deve ser preenchido");
            DomainValidationException.Validar(valor < 0, "Campo valor deve ser preenchido");

            IdCliente = idCliente;
            IdPrato = idPrato;
            Mesa = mesa;
            Valor = valor;
            Status = status;
        }

    }
}
