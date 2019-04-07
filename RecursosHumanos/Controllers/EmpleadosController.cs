using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecursosHumanos.Models;

namespace RecursosHumanos.Controllers
{
    public class EmpleadosController : Controller
    {
        private RecursosHEntities db = new RecursosHEntities();

        // GET: Empleados
        public ActionResult Index()
        {
            var empleados = db.Empleados.Include(e => e.Cargos).Include(e => e.Departamentos);
            return View(empleados.ToList());
        }

        // GET: Empleados/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.cargo = new SelectList(db.Cargos, "nombre", "nombre");
            ViewBag.departamento = new SelectList(db.Departamentos, "id", "codigo");
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigoEmp,nombre,apellido,telefono,departamento,cargo,fechaIngreso,salario,estatus")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cargo = new SelectList(db.Cargos, "nombre", "nombre", empleados.cargo);
            ViewBag.departamento = new SelectList(db.Departamentos, "id", "codigo", empleados.departamento);
            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.cargo = new SelectList(db.Cargos, "nombre", "nombre", empleados.cargo);
            ViewBag.departamento = new SelectList(db.Departamentos, "id", "codigo", empleados.departamento);
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigoEmp,nombre,apellido,telefono,departamento,cargo,fechaIngreso,salario,estatus")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cargo = new SelectList(db.Cargos, "nombre", "nombre", empleados.cargo);
            ViewBag.departamento = new SelectList(db.Departamentos, "id", "codigo", empleados.departamento);
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados empleados = db.Empleados.Find(id);
            if (empleados == null)
            {
                return HttpNotFound();
            }
            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Empleados empleados = db.Empleados.Find(id);
            db.Empleados.Remove(empleados);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
