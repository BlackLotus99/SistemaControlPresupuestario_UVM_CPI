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
    public class DIPLOMADO_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<DIPLOMADO> Listar()
        {
            var diplomado = db.DIPLOMADOs.Include(d => d.CONSOLIDADO);
            return diplomado.ToList();
        }
        public DIPLOMADO Buscar(int? id)
        {
            if (id == null)
                return null;
            return db.DIPLOMADOs.Find(id);
        }
        public void Agregar (DIPLOMADO diplomado)
        {
            db.DIPLOMADOs.Add(diplomado);
            db.SaveChanges();
        }
        public void Editar(DIPLOMADO diplomado)
        {
            db.Entry(diplomado).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar (int id)
        {
            DIPLOMADO dIPLOMADO = db.DIPLOMADOs.Find(id);
            db.DIPLOMADOs.Remove(dIPLOMADO);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}