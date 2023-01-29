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
    public class PROP_DIPLOMADO_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();
        public List<PROP_DIPLOMADO> Listar()
        {
            var prop_diplomado = db.PROP_DIPLOMADOs.Include(p => p.PERSONA_NATURAL);
            return prop_diplomado.ToList();
        }
        public PROP_DIPLOMADO Buscar(int? id)
        {
            if (id == null)
                return null;
            return db.PROP_DIPLOMADOs.Find(id);

        }
        public void Agregar(PROP_DIPLOMADO prop_diplomado)
        {
            db.PROP_DIPLOMADOs.Add(prop_diplomado);
            db.SaveChanges();
        }
        public void Editar(PROP_DIPLOMADO prop_diplomado)
        {
            db.Entry(prop_diplomado).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            PROP_DIPLOMADO pROP_DIPLOMADO = db.PROP_DIPLOMADOs.Find(id);
            db.PROP_DIPLOMADOs.Remove(pROP_DIPLOMADO);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}