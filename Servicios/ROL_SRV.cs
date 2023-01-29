using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sistema_UVM_Control_Presupuestario.Servicios
{
    public class ROL_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<ROL> Listar()
        {
            return db.ROLes.ToList();
        }
        public ROL Buscar(int? id)
        {
            if (id == null)
                return null;
            return db.ROLes.Find(id);
        }
        public void Agregar(ROL rol)
        {
            db.ROLes.Add(rol);
            db.SaveChanges();
        }
        public void Editar(ROL rol)
        {
            db.Entry(rol).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            ROL rOL = db.ROLes.Find(id);
            db.ROLes.Remove(rOL);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}