using Sezac.Persistencia.Comun;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Sezac.Persistencia.Reglas
{
	public class Cifrado : ICifrado
	{
		#region Atributos

		private readonly Comun.Definiciones.TipoCifrado _algoritmo;
        private byte[] _llave;
        private byte[] _vectorInicializacion;

		#endregion

		#region Constructor

		public Cifrado(Comun.Definiciones.TipoCifrado algoritmo)
		{
			_algoritmo = algoritmo;
		}

		#endregion

		#region Metodos

		public byte[] Cifrar(string entrada)
		{
			
			switch (_algoritmo)
			{
				case Definiciones.TipoCifrado.AES:
					return CifrarAES(entrada);
				case Definiciones.TipoCifrado.MD5:
					return CifrarMD5(entrada);
				case Definiciones.TipoCifrado.SHA1:
					return CifrarSHA1(entrada);
				default:
					return null;
			}
		}

		public string Descifrar(byte[] entrada)
		{

			switch (_algoritmo)
			{
				case Definiciones.TipoCifrado.AES:
					return DescifrarAES(entrada);
				case Definiciones.TipoCifrado.MD5:
					return DescifrarMD5(entrada);
				case Definiciones.TipoCifrado.SHA1:
					return DescifrarSHA1(entrada);
				default:
					return string.Empty;
			}
		}

		public bool Verificar(string textoValidar, string textoComparar)
		{
			StringComparer comparador = StringComparer.OrdinalIgnoreCase;

			if (comparador.Compare(textoValidar, textoComparar) == 0)
				return true;
				
			return false;
		}

		private byte[] CifrarAES(string entrada)
		{
			byte[] bytesCifrado = null;

			if (string.IsNullOrEmpty(entrada))
				return null;

			using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
			{

				if (_llave == null)
					_llave = aes.Key;

				if (_vectorInicializacion == null)
					_vectorInicializacion = aes.IV;

				ICryptoTransform cifrador = aes.CreateEncryptor(_llave, _vectorInicializacion);

				using (MemoryStream stream = new MemoryStream())
				{
					using (CryptoStream streamCifrado = new CryptoStream(stream, cifrador, CryptoStreamMode.Write))
					{
						using (StreamWriter escritor = new StreamWriter(streamCifrado))
						{
							escritor.Write(entrada);
						}
						
						bytesCifrado = stream.ToArray();
					}
				}
			}

			return bytesCifrado;
		}

		private byte[] CifrarMD5(string entrada)
		{
			MD5CryptoServiceProvider hasher = new MD5CryptoServiceProvider();

			return hasher.ComputeHash(Encoding.Default.GetBytes(entrada));
		}

		private byte[] CifrarSHA1(string entrada)
		{
			SHA1CryptoServiceProvider hasher = new SHA1CryptoServiceProvider();

			return hasher.ComputeHash(Encoding.Default.GetBytes(entrada));
		}

		private string DescifrarAES(byte[] entrada)
		{
			string loTextoCifrado = string.Empty;

			if (entrada == null || entrada.Length <= 0)
				return string.Empty;
			if (_llave == null || _llave.Length <= 0)
				throw new Exception("Llave no válida");
			if (_vectorInicializacion == null || _vectorInicializacion.Length <= 0)
				throw new Exception("Vector de inicialización no válido");

			using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
			{
				aes.Key = _llave;
				aes.IV = _vectorInicializacion;

				ICryptoTransform descifrador = aes.CreateDecryptor(_llave, _vectorInicializacion);

				using (MemoryStream stream = new MemoryStream(entrada))
				{
					using (CryptoStream streamCifrado = new CryptoStream(stream, descifrador, CryptoStreamMode.Read))
					{
						using (StreamReader lector = new StreamReader(streamCifrado))
						{
							loTextoCifrado = lector.ReadToEnd();
						}
					}
				}
			}

			return loTextoCifrado;
		}

		private string DescifrarMD5(byte[] entrada)
		{
			StringBuilder builder = new StringBuilder();

			for (int i = 0; i < entrada.Length; i++)
				builder.Append(entrada[i].ToString("x2"));
			
			return builder.ToString();
		}

		private string DescifrarSHA1(byte[] entrada)
		{
			StringBuilder builder = new StringBuilder();

			for (int i = 0; i < entrada.Length; i++)
				builder.Append(entrada[i].ToString());

			return builder.ToString();
		}

		#endregion
	}
}
