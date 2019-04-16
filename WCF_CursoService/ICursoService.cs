using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF_CursoService.Dominio;

namespace WCF_CursoService
{
    [ServiceContract]
    public interface ICursoService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<Curso> ListarPorAlumno(int idAlumno);
    }
}
