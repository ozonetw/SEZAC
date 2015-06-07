using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    class Datos
    {
        public bool Validar(string usuario, string contraseña)
        {
            string consulta = "SELECT * FROM sezac.usuario where Usuario = '"+usuario+"' AND Contrasenia = '"+contraseña+"'";
            return true;
        }

        public bool CrearDependencias(string nombre)
        {
            string insertar = "INSERT INTO `sezac`.`dependencia` (`Nombre`) VALUES('"+nombre+"')";
            return true;
        }
        public bool AltaBeneficiarios(string[] datos, byte[] foto)
        {
            string insertar = "INSERT INTO `sezac`.`beneficiario` (`RFC`, `Nombres`, `ApellidoPaterno`, `ApellidoMaterno`, `Correo`, `Imagen`, `TipoUsuarioId`, `EstatusBeneficiarioId`) VALUES('"+datos[0]+"', '"+datos[1]+"', '"+datos[2]+"', '"+datos[3]+"', '"+datos [4]+"', "+foto+", '3', '1')";
            return true;
        }
        public bool AltaAñoFiscal(int año)
        {
            string insertarAño= "INSERT INTO `sezac`.`aniofiscal` (`Anio`) VALUES('"+año+"')";
            return true;
        }
    }
}
