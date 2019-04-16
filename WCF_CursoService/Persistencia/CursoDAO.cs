using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCF_CursoService.Dominio;

namespace WCF_CursoService.Persistencia
{
    public class CursoDAO
    {
        private string cadenaConexion = "Data Source=sql2019.ddns.net, 11433; Initial Catalog=BD_UniversidadTemporal; User Id=sa; Pwd=123456789*;";

        public List<Curso> ListarPorAlumno(int id_alumno)
        {
            List<Curso> cursosEncontrados = new List<Curso>();
            Curso CursoEncontrado = null;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand())
                {
                    comando.CommandText = "dbo.ssp_Curso_ListarPorAlumno";
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            CursoEncontrado = new Curso()
                            {
                                Id = (int)resultado["id_curso"],
                                Nombre = (string)resultado["nombre_curso"],
                                Seccion = (string)resultado["seccion_curso"],
                                Aula = (string)resultado["aula_curso"],
                                Horario = (string)resultado["horario_curso"],
                                Docente = new WCF_DocenteService.Dominio.Docente()
                                {
                                    Id = (int)resultado["id_docente"],
                                    Nombres = (string)resultado["nombres_docente"],
                                    Apellidos = (string)resultado["apellidos_docente"]
                                }
                            };
                            cursosEncontrados.Add(CursoEncontrado);
                        }
                    }
                }
            }
            return cursosEncontrados;
        }
    }
}