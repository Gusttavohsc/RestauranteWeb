using RestauranteWeb.Domain.Validations;
using System;  

namespace RestauranteWeb.Domain.Entities
{
    public sealed class Cliente
    {

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Documento { get; private set; }
        public ICollection<Pedido> Pedidos { get; set; }

        public Cliente(string nome, string documento) 
        {
            ValidarCampos(nome, documento);
            Pedidos = new List<Pedido>();
        }

        public Cliente(int id, string nome, string documento)
        {
            DomainValidationException.Validar(id < 0, "ID ínválido");
            Id = id;
            ValidarCampos(nome, documento);
            Pedidos = new List<Pedido>();
        }

        private void ValidarCampos(string nome, string documento)
        {
            DomainValidationException.Validar(string.IsNullOrEmpty(nome), "Campo nome deve ser preenchido");
            DomainValidationException.Validar(string.IsNullOrEmpty(documento), "Campo documento deve ser preenchido");

            Nome = nome;
            Documento = documento;
        }
    }
}
