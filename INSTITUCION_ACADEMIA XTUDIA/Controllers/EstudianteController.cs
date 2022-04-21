using INSTITUCION_ACADEMIA_XTUDIA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INSTITUCION_ACADEMIA_XTUDIA.Controllers
{
    public class EstudianteController : Controller
    {

        [HttpGet]
        public ActionResult Create()
        {
            getLugarNacimientoPaises();
            getCursoNombres();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Estudiante modelEstudiante)
        {
            var taEst = new InstitucionDataSetTableAdapters.EstudiantesTableAdapter();
            var estId = Guid.NewGuid();
            taEst.insertEstudiantes(
                estId,
                modelEstudiante.matricula,
                modelEstudiante.nombre,
                modelEstudiante.apellido,
                modelEstudiante.fechanacimiento,
                1,
                modelEstudiante.correo,
                modelEstudiante.fotografia,
                1,
                modelEstudiante.seccion,
                modelEstudiante.nacionalidadid,
                modelEstudiante.tiposangreid
                );

            return RedirectToAction("Index");
        }


        // GET: Estudiante
        public ActionResult Index()
        {

            getLugarNacimientoPaises();
            getCursoNombres();

            //List<SelectListItem> items = listnum.ConvertAll(d =>
            //{
            //    return new SelectListItem()
            //    {
            //        Text = listnum
            //        Value = listnum[0].ToString(),
            //        Selected = false
            //    };
            //});


            return View();
        }

        public void getLugarNacimientoPaises()
        {
            List<SelectListItem> listItem = new List<SelectListItem>();
            var ta = new InstitucionDataSetTableAdapters.LugaresNacimientoTableAdapter();
            var dt = ta.getLugarNacimientoPaises();
            foreach (InstitucionDataSet.LugaresNacimientoRow row in dt.Rows)
            {
                SelectListItem item = new SelectListItem();
                item.Text = row.pais;
                item.Value = row.lugarnacimientoid.ToString();
                item.Selected = false;
                listItem.Add(item);
            }
            ViewBag.Nacimiento = listItem;
        }

        public void getCursoNombres()
        {
            List<SelectListItem> listItem = new List<SelectListItem>();
            var ta = new InstitucionDataSetTableAdapters.CursosTableAdapter();
            var dt = ta.getCursoNombres();
            foreach (InstitucionDataSet.CursosRow row in dt.Rows)
            {
                SelectListItem item = new SelectListItem();
                item.Text = row.nombre;
                item.Value = row.nombre;
                item.Selected = false;
                listItem.Add(item);
            }
            ViewBag.Curso = listItem;
        }

        public void getSeccionByCurso()
        {
            //List<SelectListItem> listItem = new List<SelectListItem>();
            //var ta = new InstitucionDataSetTableAdapters.SeccionTableAdapter();
            //var dt = ta.getSeccionByCurso();
            //foreach (InstitucionDataSet.CursosRow row in dt.Rows)
            //{
            //    SelectListItem item = new SelectListItem();
            //    item.Text = row.nombre;
            //    item.Value = row.nombre;
            //    item.Selected = false;
            //    listItem.Add(item);
            //}
            //ViewBag.Curso = listItem;
        }

        public void getNacionalidadNombres()
        {
            List<SelectListItem> listItem = new List<SelectListItem>();
            var ta = new InstitucionDataSetTableAdapters.CursosTableAdapter();
            var dt = ta.getCursoNombres();
            foreach (InstitucionDataSet.CursosRow row in dt.Rows)
            {
                SelectListItem item = new SelectListItem();
                item.Text = row.nombre;
                item.Value = row.cursoid.ToString();
                item.Selected = false;
                listItem.Add(item);
            }
            ViewBag.Curso = listItem;
        }

        public void getTipoSangreNombres()
        {

        }
    }
}