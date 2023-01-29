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
    public class PAGO_DIPLOMADO_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<PAGO_DIPLOMADO> Listar()
        {
            var pago_diplomado = db.PAGO_DIPLOMADOs.Include(p => p.PERSONA_NATURAL);
            return pago_diplomado.ToList();
        }
        public PAGO_DIPLOMADO Buscar(int? id)
        {
            if (id == null)
                return null;
            return db.PAGO_DIPLOMADOs.Find(id);
        }
        public void Agregar(PAGO_DIPLOMADO pago_diplomado)
        {
            db.PAGO_DIPLOMADOs.Add(pago_diplomado);
            db.SaveChanges();
        }
        public void Editar(PAGO_DIPLOMADO pago_diplomado)
        {
            db.Entry(pago_diplomado).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            PAGO_DIPLOMADO pAGO_DIPLOMADO = db.PAGO_DIPLOMADOs.Find(id);
            db.PAGO_DIPLOMADOs.Remove(pAGO_DIPLOMADO);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}