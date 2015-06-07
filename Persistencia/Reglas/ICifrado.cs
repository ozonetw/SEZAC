namespace Sezac.Persistencia.Reglas
{
	interface ICifrado
	{
		#region Metodos

		byte[] Cifrar(string entrada);
		string Descifrar(byte[] entrada);
		bool Verificar(string textoValidar, string textoComparar);

		#endregion
	}
}
