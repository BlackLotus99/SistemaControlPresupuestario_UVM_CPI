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
    public class REEMBOLSO_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<REEMBOLSO> Listar()
        {
            var reembolso = db.REEMBOLSOs.Include(r => r.PERSONA_NATURAL);
            return reembolso.ToList();
        }
        public REEMBOLSO Buscar(int? id)
        {
            if (id == null)
                return null;
            return db.REEMBOLSOs.Find(id);
        }
        public void Agregar(REEMBOLSO reembolso)
        {
            db.REEMBOLSOs.Add(reembolso);
            db.SaveChanges();
        }
        public void Editar(REEMBOLSO reembolso)
        {
            db.Entry(reembolso).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            REEMBOLSO rEEMBOLSO = db.REEMBOLSOs.Find(id);
            db.REEMBOLSOs.Remove(rEEMBOLSO);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}