using INSTITUCION_ACADEMIA_XTUDIA.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INSTITUCION_ACADEMIA_XTUDIA.Controllers
{
    public class TutorController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tutores modelTutor)
        {
            string path = Request.Url.ToString();
            string lastPart = path.Split('/').Last();
            Guid estId = Guid.Parse(lastPart);

            string tutFoto = saveFotografia(modelTutor.fotografia);
            var taTut = new InstitucionDataSetTableAdapters.TutoresTableAdapter();
            var tutId = Guid.NewGuid();

            taTut.insertTutores(
                tutId,
                modelTutor.cedula,
                modelTutor.nombre,
                modelTutor.apellido,
                modelTutor.fechanacimiento,
                modelTutor.lugarnacimientoid,
                tutFoto,
                modelTutor.estadocivilid,
                modelTutor.lugartrabajo,
                modelTutor.direccion,
                modelTutor.tipotutorid
                );

            var taEstTut = new InstitucionDataSetTableAdapters.EstudianteTutorTableAdapter();
            taEstTut.insertEstudianteTutor(
                estId,
                tutId
                );

            return RedirectToAction("Index");
        }

        public string saveFotografia(HttpPostedFileBase image)
        {
            string fileName = Path.GetFileNameWithoutExtension(image.FileName);
            string imagePath = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            image.SaveAs(fileName);
            return imagePath;

        }


        // GET: Tutor
        public ActionResult Index()
        {
            return View();
        }
    }
}