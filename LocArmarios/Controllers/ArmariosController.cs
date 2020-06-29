using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LocArmarios.Models;

namespace LocArmarios.Controllers
{
    public class ArmariosController : Controller
    {
        public LocArmarios.Context.Context db = new Context.Context();

        // GET: Armarios
        public ActionResult Index()
        {
            ViewBag.ListaArmariosLocados = db.ArmarioAlunos.Where(x => x.DataFimLocacao == null).ToList();
            return View(db.Armario.ToList());
        }

        // GET: Armarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armario armario = db.Armario.Find(id);
            if (armario == null)
            {
                return HttpNotFound();
            }
            return View(armario);
        }

        // GET: Armarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Armarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Bloco,Numero")] Armario armario)
        {
            if (ModelState.IsValid)
            {
                db.Armario.Add(armario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(armario);
        }

        // GET: Armarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armario armario = db.Armario.Find(id);
            if (armario == null)
            {
                return HttpNotFound();
            }
            return View(armario);
        }

        // POST: Armarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Bloco,Numero")] Armario armario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(armario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(armario);
        }

        // GET: Armarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Armario armario = db.Armario.Find(id);
            if (armario == null)
            {
                return HttpNotFound();
            }
            return View(armario);
        }

        // POST: Armarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Armario armario = db.Armario.Find(id);
            db.Armario.Remove(armario);
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
