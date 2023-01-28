using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sistema_UVM_Control_Presupuestario.Servicios
{
    public class CAMBIO_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<CAMBIO> Listar()
        {
            return db.CAMBIOs.ToList(); 
        }
        public CAMBIO Buscar(int? id)
        {
            if (id == null)
                return null;
            return db.CAMBIOs.Find(id);
        }
        public void Agregar(CAMBIO cambio)
        {
            db.CAMBIOs.Add(cambio);
            db.SaveChanges();
        }
        public void Editar(CAMBIO cambio)
        {
            db.Entry(cambio).State= EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            CAMBIO cambio = db.CAMBIOs.Find(id);
            db.CAMBIOs.Remove(cambio);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}