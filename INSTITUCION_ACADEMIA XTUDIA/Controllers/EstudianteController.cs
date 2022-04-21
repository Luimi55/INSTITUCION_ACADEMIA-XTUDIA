using INSTITUCION_ACADEMIA_XTUDIA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace INSTITUCION_ACADEMIA_XTUDIA.Controllers
{
    public class EstudianteController : Controller
    {
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            getLugarNacimientoPaises();
            getCursoNombres();

            Estudiante est = new Estudiante();
            var ta = new InstitucionDataSetTableAdapters.EstudiantesTableAdapter();
            var dt = ta.getEstudianteById(id);
            foreach (InstitucionDataSet.EstudiantesRow row in dt.Rows)
            {
                est.estudianteid = row.estudianteid;
                est.matricula = row.matricula;
                est.nombre = row.nombre;
                est.apellido = row.apellido;
                est.fechanacimiento = row.fechanacimiento;
                est.lugarnacimientoid = row.lugarnacimientoid.ToString();
                est.correo = row.correo;
                est.fotografia = row.fotografia;
                est.cursoid = row.cursoid.ToString();
                est.seccion = row.seccion;
                est.nacionalidadid = row.nacionalidadid;
                est.tiposangreid = row.tiposangreid;
            }
            return View(est);
        }

        [HttpPost]
        public ActionResult Edit(Estudiante modelEstudiante)
        {
            var ta = new InstitucionDataSetTableAdapters.EstudiantesTableAdapter();
            int estLug = Int32.Parse(modelEstudiante.lugarnacimientoid);
            int estCur = Int32.Parse(modelEstudiante.cursoid);
            var dt = ta.updateEstudiantes(
                modelEstudiante.estudianteid,
                modelEstudiante.matricula,
                modelEstudiante.nombre,
                modelEstudiante.apellido,
                modelEstudiante.fechanacimiento,
                estLug,
                modelEstudiante.correo,
                modelEstudiante.fotografia,
                estCur,
                modelEstudiante.seccion,
                modelEstudiante.nacionalidadid,
                modelEstudiante.tiposangreid
                );
            return RedirectToAction("Index");
        }


            [HttpGet]
        public ActionResult getEstudiantes()
        {
            List<Estudiante> estList = new List<Estudiante>();
            var ta = new InstitucionDataSetTableAdapters.EstudiantesTableAdapter();
            var dt = ta.GetData();
            foreach (InstitucionDataSet.EstudiantesRow row in dt.Rows)
            {
                Estudiante est = new Estudiante();
                est.estudianteid = row.estudianteid;
                est.matricula = row.matricula;
                est.nombre = row.nombre;
                est.apellido = row.apellido;
                est.fechanacimiento = row.fechanacimiento;
                est.lugarnacimientoid = row.lugarnacimientoid.ToString();
                est.correo = row.correo;
                est.fotografia = row.fotografia;
                est.cursoid = row.cursoid.ToString();
                est.seccion = row.seccion;
                est.nacionalidadid = row.nacionalidadid;
                est.tiposangreid = row.tiposangreid;
                estList.Add(est);
            }
            return Json(new { data = estList }, JsonRequestBehavior.AllowGet);
        }


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
            string estFoto = saveFotografia(modelEstudiante.fileBase);
            int estLug = Int32.Parse(modelEstudiante.lugarnacimientoid);
            int estCur = Int32.Parse(modelEstudiante.cursoid);

            var taEst = new InstitucionDataSetTableAdapters.EstudiantesTableAdapter();
            var estId = Guid.NewGuid();
            taEst.insertEstudiantes(
                estId,
                modelEstudiante.matricula,
                modelEstudiante.nombre,
                modelEstudiante.apellido,
                modelEstudiante.fechanacimiento,
                estLug,
                modelEstudiante.correo,
                estFoto,
                estCur,
                modelEstudiante.seccion,
                modelEstudiante.nacionalidadid,
                modelEstudiante.tiposangreid
                );

            return RedirectToAction("../Tutor/Create/" + estId);
        }

        public string saveFotografia(HttpPostedFileBase image)
        {
            string fileName = Path.GetFileNameWithoutExtension(image.FileName);
            string imagePath = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            image.SaveAs(fileName);
            return imagePath;

        }


        // GET: Estudiante
        public ActionResult Index()
        {
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
                item.Value = row.cursoid.ToString();
                item.Selected = false;
                listItem.Add(item);
            }
            ViewBag.Curso = listItem;
        }

        //public void getSeccionByCurso()
        //{
        //    //List<SelectListItem> listItem = new List<SelectListItem>();
        //    //var ta = new InstitucionDataSetTableAdapters.SeccionTableAdapter();
        //    //var dt = ta.getSeccionByCurso();
        //    //foreach (InstitucionDataSet.CursosRow row in dt.Rows)
        //    //{
        //    //    SelectListItem item = new SelectListItem();
        //    //    item.Text = row.nombre;
        //    //    item.Value = row.nombre;
        //    //    item.Selected = false;
        //    //    listItem.Add(item);
        //    //}
        //    //ViewBag.Curso = listItem;
        //}

        //public void getNacionalidadNombres()
        //{
        //    List<SelectListItem> listItem = new List<SelectListItem>();
        //    var ta = new InstitucionDataSetTableAdapters.CursosTableAdapter();
        //    var dt = ta.getCursoNombres();
        //    foreach (InstitucionDataSet.CursosRow row in dt.Rows)
        //    {
        //        SelectListItem item = new SelectListItem();
        //        item.Text = row.nombre;
        //        item.Value = row.cursoid.ToString();
        //        item.Selected = false;
        //        listItem.Add(item);
        //    }
        //    ViewBag.Curso = listItem;
        //}

        //public void getTipoSangreNombres()
        //{

        //}
    }
}