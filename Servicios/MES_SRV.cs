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
    public class MES_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<MES> Listar()
        {
            var mes = db.MEs.Include(m => m.CONSOLIDADO);
            return mes.ToList();
        }
        public MES Buscar(int? id)
        {
            if (id == null)
                return null;
            return db.MEs.Find(id);
        }
        public void Agregar(MES mes)
        {
            db.MEs.Add(mes);
            db.SaveChanges();
        }
        public void Editar(MES mes)
        {
            db.Entry(mes).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            MES mES = db.MEs.Find(id);
            db.MEs.Remove(mES);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}