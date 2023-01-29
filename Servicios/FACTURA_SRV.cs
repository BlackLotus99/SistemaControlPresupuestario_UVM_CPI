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
    public class FACTURA_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<FACTURA> Listar()
        {
            var factura = db.FACTURAs.Include(f => f.OPEX).Include(f => f.CAPEX);
            return factura.ToList();
        }
        public FACTURA buscar(int? id)
        {
            if (id == null)
                return null;
            return db.FACTURAs.Find(id);
        }
        public void Agregar(FACTURA factura)
        {
            db.FACTURAs.Add(factura);
            db.SaveChanges();
        }
        public void Editar(FACTURA factura)
        {
            db.Entry(factura).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            FACTURA fACTURA = db.FACTURAs.Find(id);
            db.FACTURAs.Remove(fACTURA);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}