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
    public class OPEX_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<OPEX> Listar()
        {
            var opex = db.OPEXes.Include(o => o.PERSONA_NATURAL);
            return opex.ToList();
        }
        public OPEX Buscar(int? id)
        {
            if (id == null)
                return null;
            return db.OPEXes.Find(id);
        }
        public void Agregar(OPEX opex)
        {
            db.OPEXes.Add(opex);
            db.SaveChanges();
        }
        public void Editar(OPEX opex)
        {
            db.Entry(opex).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            OPEX opex = db.OPEXes.Find(id);
            db.OPEXes.Remove(opex);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}