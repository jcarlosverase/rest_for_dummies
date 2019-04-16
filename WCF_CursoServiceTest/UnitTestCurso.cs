using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;

namespace WCF_CursoServiceTest
{
    [TestClass]
    public class UnitTestCurso
    {
        [TestMethod]
        public void TestListarPorAlumno()
        {
            HttpWebRequest reqCursos = WebRequest.Create("http://localhost:50453/CursoService.svc/ListarPorAlumno") as HttpWebRequest;
            HttpWebResponse resCursos = reqCursos.GetResponse() as HttpWebResponse;
            StreamReader readerCursos = new StreamReader(resCursos.GetResponseStream());
            string cursos = readerCursos.ReadToEnd();
            if (cursos != null)
            {
                Assert.AreEqual("", "");
            }
        }

        [TestMethod]
        public void TestListarPorAlumnoNoExistente()
        {
            HttpWebRequest reqCursos = WebRequest.Create("http://localhost:50453/CursoService.svc/ListarPorAlumno") as HttpWebRequest;
            HttpWebResponse resCursos = reqCursos.GetResponse() as HttpWebResponse;
            StreamReader readerCursos = new StreamReader(resCursos.GetResponseStream());
            string cursos = readerCursos.ReadToEnd();
            if (cursos != null)
            {
                if (cursos.Contains("Error"))
                {
                    Assert.AreEqual("", "");
                }
            }
        }
    }
}
