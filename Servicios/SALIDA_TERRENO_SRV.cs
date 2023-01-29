using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sistema_UVM_Control_Presupuestario.Servicios
{
    public class SALIDA_TERRENO_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<SALIDA_TERRENO> Listar()
        {
            return db.SALIDA_TERRENOs.ToList();
        }
        public SALIDA_TERRENO Buscar(int? id)
        {
            if (id == null)
                return null;
            return db.SALIDA_TERRENOs.Find(id);
        }
        public void Agregar(SALIDA_TERRENO salida_terreno)
        {
            db.SALIDA_TERRENOs.Add(salida_terreno);
            db.SaveChanges();
        }
        public void Editar(SALIDA_TERRENO salida_terreno)
        {
            db.Entry(salida_terreno).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            SALIDA_TERRENO sALIDA_TERRENO = db.SALIDA_TERRENOs.Find(id);
            db.SALIDA_TERRENOs.Remove(sALIDA_TERRENO);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}