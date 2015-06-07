using Sezac.Persistencia.Reglas;
using System.Runtime.Serialization;

namespace Sezac.Persistencia.Entidades
{
	public class Credenciales
	{
		#region Propiedades

		public Cifrado Cifrado 
        { 
            get; 
            set; 
        }
		public byte[] Contrasenia
        {
            get;
            set;
        }
		public string Usuario
        {
            get;
            set;
        }
				
		#endregion
	}
}
