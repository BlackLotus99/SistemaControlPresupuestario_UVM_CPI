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
    public class RENDICION_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<RENDICION> Listar()
        {
            var rendicion = db.RENDICIONs.Include(r => r.PERSONA_JURIDICA).Include(r => r.PERSONA_NATURAL);
            return rendicion.ToList();
        }
        public RENDICION Buscar(int? id)
        {
            if (id == null)
                return null;
            return db.RENDICIONs.Find(id);
        }
        public void Agregar(RENDICION rencidion)
        {
            db.RENDICIONs.Add(rencidion);
            db.SaveChanges();
        }
        public void Editar(RENDICION rendicion)
        {
            db.Entry(rendicion).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            RENDICION rENDICION = db.RENDICIONs.Find(id);
            db.RENDICIONs.Remove(rENDICION);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}