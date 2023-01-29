using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Sistema_UVM_Control_Presupuestario.Servicios
{
    public class CARRERA_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();
        
        public List<CARRERA> Listar()
        {
            var carrera = db.CARRERAs.Include(c => c.CONSOLIDADO);
            return carrera.ToList();
        }
        public CARRERA Buscar(int? id)
        {
            if (id == null)
                return null;
            return db.CARRERAs.Find(id);
        }
        public void Agregar(CARRERA carrera)
        {
            db.CARRERAs.Add(carrera);
            db.SaveChanges();
        }
        public void Editar(CARRERA carrera)
        {
            db.Entry(carrera).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            CARRERA carrera = db.CARRERAs.Find(id);
            db.CARRERAs.Remove(carrera);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}