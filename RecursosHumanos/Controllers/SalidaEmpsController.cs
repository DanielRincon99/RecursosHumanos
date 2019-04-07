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
    public class SalidaEmpsController : Controller
    {
        private RecursosHEntities db = new RecursosHEntities();

        // GET: SalidaEmps
        public ActionResult Index()
        {
            var salidaEmp = db.SalidaEmp.Include(s => s.Empleados);
            return View(salidaEmp.ToList());
        }

        // GET: SalidaEmps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmp salidaEmp = db.SalidaEmp.Find(id);
            if (salidaEmp == null)
            {
                return HttpNotFound();
            }
            return View(salidaEmp);
        }

        // GET: SalidaEmps/Create
        public ActionResult Create()
        {
            ViewBag.codigoEmp = new SelectList(db.Empleados, "codigoEmp", "nombre");
            return View();
        }

        // POST: SalidaEmps/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigoEmp,tipoSalida,motivo,fechaSalida")] SalidaEmp salidaEmp)
        {
            if (ModelState.IsValid)
            {
                db.SalidaEmp.Add(salidaEmp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigoEmp = new SelectList(db.Empleados, "codigoEmp", "nombre", salidaEmp.codigoEmp);
            return View(salidaEmp);
        }

        // GET: SalidaEmps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmp salidaEmp = db.SalidaEmp.Find(id);
            if (salidaEmp == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigoEmp = new SelectList(db.Empleados, "codigoEmp", "nombre", salidaEmp.codigoEmp);
            return View(salidaEmp);
        }

        // POST: SalidaEmps/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigoEmp,tipoSalida,motivo,fechaSalida")] SalidaEmp salidaEmp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salidaEmp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigoEmp = new SelectList(db.Empleados, "codigoEmp", "nombre", salidaEmp.codigoEmp);
            return View(salidaEmp);
        }

        // GET: SalidaEmps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmp salidaEmp = db.SalidaEmp.Find(id);
            if (salidaEmp == null)
            {
                return HttpNotFound();
            }
            return View(salidaEmp);
        }

        // POST: SalidaEmps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalidaEmp salidaEmp = db.SalidaEmp.Find(id);
            db.SalidaEmp.Remove(salidaEmp);
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
