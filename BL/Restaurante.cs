using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Restaurante
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                //Hacemo la conexion a la base de datos, le pasamos la cadena de conexion
                using (DL.ProyectoRestauranteEntities context = new DL.ProyectoRestauranteEntities())
                {
                    DateTime fechaConvertida = DateTime.Parse(usuario.FechaNacimiento);
                    string sexoConvertido = usuario.Sexo.ToString();



                    var query = context.UsuarioAdd(usuario.Nombre, usuario.Email, usuario.Edad, usuario.UserName, usuario.ApellidoPaterno, usuario.ApallidoMaterno, usuario.Password, sexoConvertido, usuario.Telefono, usuario.Celular, fechaConvertida, usuario.Curp, null, usuario.Rol.IdRol, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);

                    if (query > 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se inserto";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }
    }
}
