using FluentValidation.Results;

namespace RestauranteWeb.Application.Services
{
	public class ResultService
	{
		public bool ComSucesso { get; set; }
		public string? Mensagem { get; set; }
		public ICollection<ErrorValidation>? Erros { get; set; }

		public static ResultService RequestError(string mensagem, ValidationResult validationResult)
		{
			return new ResultService
			{
				ComSucesso = false,
				Mensagem = mensagem,
				Erros = validationResult.Errors.Select(x => new ErrorValidation
				{
					Campo = x.PropertyName,
					Mensagem = x.ErrorMessage
				}
					).ToList()
			};
		}

		public static ResultService<T> RequestError<T>(string mensagem, ValidationResult validationResult)
		{
			return new ResultService<T>
			{
				ComSucesso = false,
				Mensagem = mensagem,
				Erros = validationResult.Errors.Select(x => new ErrorValidation
				{
					Campo = x.PropertyName,
					Mensagem = x.ErrorMessage
				}
					).ToList()
			};
		}

		public static ResultService Falha(string mensagem) => new ResultService { ComSucesso = false, Mensagem = mensagem };
		public static ResultService<T> Falha<T>(string mensagem) => new ResultService<T> { ComSucesso = false, Mensagem = mensagem };

		public static ResultService Sucesso(string mensagem) => new ResultService { ComSucesso = true, Mensagem = mensagem };
		public static ResultService<T> Sucesso<T>(T dado) => new ResultService<T> { ComSucesso = true, Dado = dado };
	}


	public class ResultService<T> : ResultService
	{
		public T? Dado { get; set; }
	}
}
