using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sistema_UVM_Control_Presupuestario.Servicios
{
    public class PERSONA_NATURAL_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<PERSONA_NATURALes> Listar()
        {
            return db.PERSONA_NATURALes.ToList();
        }
        public PERSONA_NATURALes Buscar(int? id)
        {
            if (id == null)
                return null;
            return db.PERSONA_NATURALes.Find(id);
        }
        public void Agregar(PERSONA_NATURALes persona_natural)
        {
            db.PERSONA_NATURALes.Add(persona_natural);
            db.SaveChanges();
        }
        public void Editar(PERSONA_NATURALes persona_natural)
        {
            db.Entry(persona_natural).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            PERSONA_NATURALes pERSONA_NATURAL = db.PERSONA_NATURALes.Find(id);
            db.PERSONA_NATURALes.Remove(pERSONA_NATURAL);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}