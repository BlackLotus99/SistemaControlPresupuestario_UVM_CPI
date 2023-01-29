using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sistema_UVM_Control_Presupuestario.Servicios
{
    public class CONSOLIDADO_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<CONSOLIDADO> Listar()
        {
            return db.CONSOLIDADOs.ToList();
        }
        public CONSOLIDADO Buscar(int? id)
        {
            if (id == null)
                return null;
            return db.CONSOLIDADOs.Find(id);
        } 
        public void Agregar(CONSOLIDADO consolidado)
        {
            db.CONSOLIDADOs.Add(consolidado);
            db.SaveChanges();
        }
        public void Editar(CONSOLIDADO consolidado)
        {
            db.Entry(consolidado).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            CONSOLIDADO consolidado = db.CONSOLIDADOs.Find(id);
            db.CONSOLIDADOs.Remove(consolidado);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}