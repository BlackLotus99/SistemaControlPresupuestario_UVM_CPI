using Antlr.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sistema_UVM_Control_Presupuestario.Servicios
{
    public class DETALLE_RENDICION_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<DETALLE_RENDICION> Listar()
        {
            return db.DETALLE_RENDICION.ToList();
        }
        public DETALLE_RENDICION Buscar(int? id)
        {
            if (id == null) 
                return null;
            return db.DETALLE_RENDICION.Find(id);
        }
        public void Agregar(DETALLE_RENDICION detalle_rendicion)
        {
            db.DETALLE_RENDICION.Add(detalle_rendicion);
            db.SaveChanges();
        }
        public void Editar(DETALLE_RENDICION detalle_rendicion)
        {
            db.Entry(detalle_rendicion).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            DETALLE_RENDICION detalle_rendicion = db.DETALLE_RENDICION.Find(id);
            db.DETALLE_RENDICION.Remove(detalle_rendicion);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}