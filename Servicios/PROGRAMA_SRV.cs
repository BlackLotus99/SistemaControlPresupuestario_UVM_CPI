using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sistema_UVM_Control_Presupuestario.Servicios
{
    public class PROGRAMA_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<PROGRAMA> Listar()
        {
            return db.PROGRAMAs.ToList();
        }
        public PROGRAMA Buscar(int? id)
        {
            if(id == null)
                return null;
            return db.PROGRAMAs.Find(id);
        }
        public void Agregar(PROGRAMA programa)
        {
            db.PROGRAMAs.Add(programa);
            db.SaveChanges();
        }
        public void Editar(PROGRAMA programa)
        {
            db.Entry(programa).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            PROGRAMA pROGRAMA = db.PROGRAMAs.Find(id);
            db.PROGRAMAs.Remove(pROGRAMA);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}