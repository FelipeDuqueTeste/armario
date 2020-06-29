using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LocArmarios.Context;
using LocArmarios.Models;

namespace LocArmarios.Controllers
{
    public class ArmarioAlunoesController : Controller
    {
        private readonly LocArmarios.Context.Context db = new LocArmarios.Context.Context();

        // GET: ArmarioAlunoes
        public ActionResult Index()
        {
            ViewBag.Title = "Página Inicial";
            ViewBag.ListaArmariosLocados = db.ArmarioAlunos.Include("Aluno").Where(x => x.DataFimLocacao == null).ToList();
            return View(db.Armario.ToList());
        }

        // GET: ArmarioAlunoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArmarioAluno armarioAluno = db.ArmarioAlunos.Find(id);
            if (armarioAluno == null)
            {
                return HttpNotFound();
            }
            return View(armarioAluno);
        }

        // GET: ArmarioAlunoes/Create
        public ActionResult Create(int Id)
        {

            ViewBag.AlunoId = new SelectList(db.Alunos, "Id", "Nome");
            ViewBag.ArmarioId = new SelectList(db.Armario.Where(x => x.Id == Id), "Id", "Numero", Id);
            return View();
        }

        // POST: ArmarioAlunoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AlunoId,ArmarioId")] ArmarioAluno armarioAluno)
        {
            if (ModelState.IsValid)
            {
                armarioAluno.DataLocacao = DateTime.Now;
                armarioAluno.Id = 0;
                db.ArmarioAlunos.Add(armarioAluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var armarioAlunoes = db.ArmarioAlunos.ToList();

            ViewBag.AlunoId = new SelectList(db.Alunos, "Id", "Nome", armarioAluno.AlunoId);
            ViewBag.ArmarioId = new SelectList(db.Armario.Where(p => !armarioAlunoes.Where(x => x.DataFimLocacao == null).Select(y => y.ArmarioId).ToList().Contains(p.Id)), "Id", "Id", armarioAluno.ArmarioId);

            //ViewBag.AlunoId = new SelectList(db.Alunos, "Id", "Nome", armarioAluno.AlunoId);
            //ViewBag.ArmarioId = new SelectList(db.Armario, "Id", "Id", armarioAluno.ArmarioId);
            return View(armarioAluno);
        }

        // GET: ArmarioAlunoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArmarioAluno armarioAluno = db.ArmarioAlunos.Where(x => x.Id == id).FirstOrDefault();       
            if (armarioAluno == null)
            {
                return HttpNotFound();
            }  

            ViewBag.AlunoId = new SelectList(db.Alunos, "Id", "Nome", armarioAluno.AlunoId);
            ViewBag.ArmarioId = new SelectList(db.Armario, "Id", "Numero", armarioAluno.ArmarioId);

            return View(armarioAluno);
        }

        // POST: ArmarioAlunoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AlunoId,ArmarioId,DataLocacao")] ArmarioAluno armarioAluno)
        {
            if (ModelState.IsValid)
            {
                armarioAluno.DataFimLocacao = DateTime.Now;
                db.Entry(armarioAluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var armarioAlunoes = db.ArmarioAlunos.ToList();

            ViewBag.AlunoId = new SelectList(db.Alunos, "Id", "Nome", armarioAluno.AlunoId);
            ViewBag.ArmarioId = new SelectList(db.Armario.Where(p => !armarioAlunoes.Where(x => x.DataFimLocacao == null).Select(y => y.ArmarioId).ToList().Contains(p.Id)), "Id", "Id", armarioAluno.ArmarioId);

            return View(armarioAluno);
        }

        // GET: ArmarioAlunoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArmarioAluno armarioAluno = db.ArmarioAlunos.Find(id);
            if (armarioAluno == null)
            {
                return HttpNotFound();
            }
            return View(armarioAluno);
        }

        // POST: ArmarioAlunoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArmarioAluno armarioAluno = db.ArmarioAlunos.Find(id);
            db.ArmarioAlunos.Remove(armarioAluno);
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
