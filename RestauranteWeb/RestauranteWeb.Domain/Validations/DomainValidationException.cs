namespace RestauranteWeb.Domain.Validations
{
	public class DomainValidationException : Exception
	{
		public DomainValidationException(string err) : base(err)
		{
		}

		public static void Validar(bool temErro, string mensagem)
		{
			if (temErro)
			{
				throw new DomainValidationException(mensagem);
			}
		}
	}
}
