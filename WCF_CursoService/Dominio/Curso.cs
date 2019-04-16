using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WCF_DocenteService.Dominio;

namespace WCF_CursoService.Dominio
{
    [DataContract]
    public class Curso
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Seccion { get; set; }
        [DataMember]
        public string Aula { get; set; }
        [DataMember]
        public string Horario { get; set; }
        [DataMember]
        public Docente Docente { get; set; }
    }
}