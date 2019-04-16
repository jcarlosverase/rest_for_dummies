using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_CursoService.Dominio;
using WCF_CursoService.Errores;
using WCF_CursoService.Persistencia;

namespace WCF_CursoService
{
    public class CursoService : ICursoService
    {
        private CursoDAO cursoDAO = new CursoDAO();

        public List<Curso> ListarPorAlumno(int idAlumno)
        {
            if (idAlumno > 1) // Ya existe
            {
                throw new FaultException<ExisteException>
                    (
                        new ExisteException()
                        {
                            Codigo = "101",
                            Descripcion = "El alumno no existe"
                        },
                        new FaultReason("Error al intentar listar cursos")
                    );
            }
            return cursoDAO.ListarPorAlumno(idAlumno);
        }
    }
}
