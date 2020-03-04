using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.SqlClient;
using System.Data;
using MVCLaboratorio.Utilerias;

namespace MVCLaboratorio.Controllers
{
    public class VideoController : Controller
    {
        //
        // GET: /Video/

        public ActionResult Index()
        {
            //consultar la info en la bd
            ViewData["video"] = BaseHelper.ejecutarConsulta(
                  "Select * from video",
                  CommandType.Text);

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(int idVideo, string titulo, int repro, string url)
        {
            //guardar los datos
            List<SqlParameter> Parametros = new List<SqlParameter>();
            Parametros.Add(new SqlParameter("@idVideo", idVideo));
            Parametros.Add(new SqlParameter("@titulo", titulo));
            Parametros.Add(new SqlParameter("@repro", repro));
            Parametros.Add(new SqlParameter("@url", url));


            BaseHelper.ejecutarSentencia("sp_Video_insertar",
                CommandType.StoredProcedure, Parametros);

            return View();
        }
        public ActionResult Delete()
        {
          
            
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int idVideo)
        {
            //eliminar los datos
            List<SqlParameter> Parametros = new List<SqlParameter>();
            Parametros.Add(new SqlParameter("@idVideo", idVideo));

            BaseHelper.ejecutarSentencia("sp_Video_eliminarVideo",
            CommandType.StoredProcedure, Parametros);

            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int idVideo)
        {

            //Actualizzar los datos
            List<SqlParameter> Parametros = new List<SqlParameter>();
            Parametros.Add(new SqlParameter("@idVideo", idVideo));

            BaseHelper.ejecutarSentencia("sp_Video_ActualizarVideo",
            CommandType.StoredProcedure, Parametros);

            return View();
        }


    }
}
