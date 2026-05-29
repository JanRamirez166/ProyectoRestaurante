using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Restaurante
    {

        public static ML.Result GetAll()
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProyectoRestauranteEntities context = new DL.ProyectoRestauranteEntities())
                {
                    //con var podemos gurdar cualquier cosa;   UsuarioGetAll es el storeProcedure
                    var query = context.GetAll().ToList();

                    if (query.Count > 0)
                    {
                        //Esto para instanciar la lista de objetos pero vacia, esto para que se pueda meter objetos
                        result.Objects = new List<object>();//null vs vacio

                        foreach (var item in query)
                        {
                            ML.Restaurante restauranteBD = new ML.Restaurante();

                            restauranteBD.IdRestaurante = item.IdRestaurante;
                            restauranteBD.Nombre = item.Nombre;
                            restauranteBD.Imagen = item.Imagen;
                            restauranteBD.HorarioCierre = item.HorarioCierre.Value;
                            restauranteBD.HorarioApertura = item.HorarioApertura.Value;
                            restauranteBD.Descripcion = item.Descripcion;
                            restauranteBD.Telefono = item.Telefono;
                            restauranteBD.Correo = item.Correo;
                            restauranteBD.Estatus = item.Estatus.Value;

                            result.Objects.Add(restauranteBD);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay registros";
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

        public static ML.Result GetById(int idRestaurante)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProyectoRestauranteEntities context = new DL.ProyectoRestauranteEntities())
                {
                    //con var podemos gurdar cualquier cosa;   UsuarioGetAll es el storeProcedure
                    var query = context.GetById(idRestaurante).SingleOrDefault();

                    if (query != null)
                    {

                        ML.Restaurante restauranteBD = new ML.Restaurante();

                        restauranteBD.IdRestaurante = query.IdRestaurante;
                        restauranteBD.Nombre = query.Nombre;
                        restauranteBD.Imagen = query.Imagen;
                        restauranteBD.HorarioCierre = query.HorarioCierre.Value;
                        restauranteBD.HorarioApertura = query.HorarioApertura.Value;
                        restauranteBD.Descripcion = query.Descripcion;
                        restauranteBD.Telefono = query.Telefono;
                        restauranteBD.Correo = query.Correo;
                        restauranteBD.Estatus = query.Estatus.Value;

                        result.Object = restauranteBD;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No hay registros";
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

        public static ML.Result Add(ML.Restaurante restaurante)
        {
            ML.Result result = new ML.Result();

            try
            {
                //Hacemo la conexion a la base de datos, le pasamos la cadena de conexion
                using (DL.ProyectoRestauranteEntities context = new DL.ProyectoRestauranteEntities())
                {

                    var query = context.Agregar(restaurante.Nombre, restaurante.Imagen, restaurante.HorarioApertura, restaurante.HorarioCierre, restaurante.Descripcion, restaurante.Telefono, restaurante.Correo, restaurante.Estatus);

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
        public static ML.Result Update(ML.Restaurante restaurante)
        {
            ML.Result result = new ML.Result();

            try
            {
                //Hacemo la conexion a la base de datos, le pasamos la cadena de conexion
                using (DL.ProyectoRestauranteEntities context = new DL.ProyectoRestauranteEntities())
                {

                    var query = context.Actualizar(restaurante.IdRestaurante, restaurante.Nombre, restaurante.Imagen, restaurante.HorarioApertura, restaurante.HorarioCierre, restaurante.Descripcion, restaurante.Telefono, restaurante.Correo, restaurante.Estatus);

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

        public static ML.Result Delete(int idRestaurante)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ProyectoRestauranteEntities context = new DL.ProyectoRestauranteEntities())
                {

                    var query = context.Eliminar(idRestaurante);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se elimino";

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
