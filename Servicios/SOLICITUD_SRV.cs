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
    public class SOLICITUD_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<SOLICITUD> Listar()
        {
            var solicitud = db.SOLICITUDs.Include(s => s.CAPEX).Include(s => s.OPEX).Include(s => s.PERSONA_JURIDICA);
            return solicitud.ToList();
        }
        public SOLICITUD Buscar(int? id)
        {
            if (id == null)
                return null;
            return db.SOLICITUDs.Find(id);
        }
        public void Agregar(SOLICITUD solicitud)
        {
            db.SOLICITUDs.Add(solicitud);
            db.SaveChanges();
        }
        public void Editar(SOLICITUD solicitud)
        {
            db.Entry(solicitud).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            SOLICITUD sOLICITUD = db.SOLICITUDs.Find(id);
            db.SOLICITUDs.Remove(sOLICITUD);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}