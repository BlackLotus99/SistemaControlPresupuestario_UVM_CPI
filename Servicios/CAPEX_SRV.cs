using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Sistema_UVM_Control_Presupuestario.Servicios
{
    public class CAPEX_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();
        
        public List<CAPEX> Listar()
        {
            var capex = db.CAPEXes.Include(c => c.PERSONA_JURIDICA);
            return capex.ToList();
        }
        public CAPEX Buscar(int? id)
        {
            if (id == null) 
                return null;
            return db.CAPEXes.Find(id);
        }
        public void Agregar(CAPEX capex)
        {
            db.CAPEXes.Add(capex);
            db.SaveChanges();
        }
        public void Editar(CAPEX capex)
        {
            db.Entry(capex).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            CAPEX capex = db.CAPEXes.Find(id);
            db.CAPEXes.Remove(capex);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}