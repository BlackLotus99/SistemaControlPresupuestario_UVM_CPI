using Sistema_UVM_Control_Presupuestario.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace Sistema_UVM_Control_Presupuestario.Servicios
{
    public class BOLETA_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<BOLETA> Listar()
            {
                var boleta = db.BOLETAs.Include(b => b.OPEX).Include(b => b.CAPEX);
                return boleta.ToList();
            }
        public BOLETA Buscar(int? id)
            {
                if (id == null)
                    return null;
                return db.BOLETAs.Find(id);
            }
        public void Agregar(BOLETA boleta)
            {
                db.BOLETAs.Add(boleta);
                db.SaveChanges();
            }
        public void Editar(BOLETA boleta)
            {
                db.Entry(boleta).State= EntityState.Modified;
                db.SaveChanges();
            }
        public void Eliminar(int id)
            {
                BOLETA boleta = db.BOLETAs.Find(id);
                db.BOLETAs.Remove(boleta);
                db.SaveChanges();
            }
        public void Dispose()
            {
                db.Dispose();
            }
    }
}