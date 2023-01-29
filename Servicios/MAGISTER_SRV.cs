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
    public class MAGISTER_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<MAGISTER> Listar()
        {
            var magister = db.MAGISTERs.Include(m => m.CONSOLIDADO);
            return magister.ToList();
        }
        public MAGISTER Buscar(int? id)
        {
            if (id == null)
                return null;
            return db.MAGISTERs.Find(id);
        }
        public void Agregar(MAGISTER magister)
        {
            db.MAGISTERs.Add(magister);
            db.SaveChanges();
        }
        public void Editar(MAGISTER magister)
        {
            db.Entry(magister).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            MAGISTER magister = db.MAGISTERs.Find(id);
            db.MAGISTERs.Remove(magister);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}