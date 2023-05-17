using RestauranteWeb.Domain.Validations;
using System;

namespace RestauranteWeb.Domain.Entities
{
    public sealed class Prato
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Categoria { get; private set; }
        public TimeSpan Preparo { get; private set; }
        public decimal Valor { get; private set; }
        public string Descricao { get; private set; }
        public bool Status { get; private set; }
        public ICollection<Pedido> Pedidos { get; set; }

        public Prato(string nome,string categoria, TimeSpan preparo, decimal valor, bool status, string descricao) 
        {
            ValidarCampos(nome, categoria, preparo, valor, status, descricao);
        }

        public Prato(int id, string nome, string categoria, TimeSpan preparo, decimal valor, bool status, string descricao)
        {
            DomainValidationException.Validar(id < 0, "Campo ID inválido");

            Id = id;
            ValidarCampos(nome, categoria, preparo, valor, status, descricao);
        }

        private void ValidarCampos(string nome, string categoria,TimeSpan preparo, decimal valor, bool status, string? descricao)
        {
            DomainValidationException.Validar(string.IsNullOrEmpty(nome), "Campo nome deve ser preenchido");
            DomainValidationException.Validar(string.IsNullOrEmpty(categoria), "Campo categoria deve ser preenchido");
            DomainValidationException.Validar(preparo == TimeSpan.Zero, "Campo preparo deve ser preenchido");
            DomainValidationException.Validar(valor <= 0, "Campo nome deve ser preenchido");
            DomainValidationException.Validar(status != true && status != false, "Campo status deve ser selecionado");
            DomainValidationException.Validar(string.IsNullOrEmpty(descricao), "Campo descrição deve ser preenchido");

            Nome = nome;
            Categoria = categoria;
            Status = status;
            Preparo = preparo;
            Valor = valor;
            if (descricao != null)
            {
                Descricao = descricao;
            }

        }
    }
}
