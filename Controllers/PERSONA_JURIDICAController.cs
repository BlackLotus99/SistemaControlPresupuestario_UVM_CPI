using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_UVM_Control_Presupuestario;
using Sistema_UVM_Control_Presupuestario.Servicios;

namespace Sistema_UVM_Control_Presupuestario.Controllers
{
    public class PERSONA_JURIDICAController : Controller
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        // GET: PERSONA_JURIDICA
        public ActionResult Index()
        {
            //return View(db.PERSONA_JURIDICAs.ToList());
            return View(new PERSONA_JURIDICA_SRV().Listar());
        }

        // GET: PERSONA_JURIDICA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PERSONA_JURIDICAs pERSONA_JURIDICA = db.PERSONA_JURIDICAs.Find(id);
            PERSONA_JURIDICAs pERSONA_JURIDICA = new PERSONA_JURIDICA_SRV().Buscar(id);
            if (pERSONA_JURIDICA == null)
            {
                return HttpNotFound();
            }
            return View(pERSONA_JURIDICA);
        }

        // GET: PERSONA_JURIDICA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PERSONA_JURIDICA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ESTADO,NOMBRE,RUT,DIGITO_VERIFICADOR")] PERSONA_JURIDICAs pERSONA_JURIDICA)
        {
            if (ModelState.IsValid)
            {
                //db.PERSONA_JURIDICAs.Add(pERSONA_JURIDICA);
                //db.SaveChanges();
                new PERSONA_JURIDICA_SRV().Agregar(pERSONA_JURIDICA);
                return RedirectToAction("Index");
            }

            return View(pERSONA_JURIDICA);
        }

        // GET: PERSONA_JURIDICA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PERSONA_JURIDICAs pERSONA_JURIDICA = db.PERSONA_JURIDICAs.Find(id);
            PERSONA_JURIDICAs pERSONA_JURIDICA = new PERSONA_JURIDICA_SRV().Buscar(id);
            if (pERSONA_JURIDICA == null)
            {
                return HttpNotFound();
            }
            return View(pERSONA_JURIDICA);
        }

        // POST: PERSONA_JURIDICA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ESTADO,NOMBRE,RUT,DIGITO_VERIFICADOR")] PERSONA_JURIDICAs pERSONA_JURIDICA)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(pERSONA_JURIDICA).State = EntityState.Modified;
                //db.SaveChanges();
                new PERSONA_JURIDICA_SRV().Editar(pERSONA_JURIDICA);
                return RedirectToAction("Index");
            }
            return View(pERSONA_JURIDICA);
        }

        // GET: PERSONA_JURIDICA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PERSONA_JURIDICAs pERSONA_JURIDICA = db.PERSONA_JURIDICAs.Find(id);
            PERSONA_JURIDICAs pERSONA_JURIDICA = new PERSONA_JURIDICA_SRV().Buscar(id);
            if (pERSONA_JURIDICA == null)
            {
                return HttpNotFound();
            }
            return View(pERSONA_JURIDICA);
        }

        // POST: PERSONA_JURIDICA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //PERSONA_JURIDICAs pERSONA_JURIDICA = db.PERSONA_JURIDICAs.Find(id);
            //db.PERSONA_JURIDICAs.Remove(pERSONA_JURIDICA);
            //db.SaveChanges();
            new PERSONA_JURIDICA_SRV().Eliminar(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                new PERSONA_JURIDICA_SRV().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
