using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sistema_UVM_Control_Presupuestario.Servicios
{
    public class PERSONA_JURIDICA_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<PERSONA_JURIDICAs> Listar()
        {
            return db.PERSONA_JURIDICAs.ToList();
        }
        public PERSONA_JURIDICAs Buscar(int? id)
        {
            if (id == null)
                return null;
            return db.PERSONA_JURIDICAs.Find(id);
        }
        public void Agregar(PERSONA_JURIDICAs persona_juridica)
        {
            db.PERSONA_JURIDICAs.Add(persona_juridica);
            db.SaveChanges();
        }
        public void Editar(PERSONA_JURIDICAs persona_juridica)
        {
            db.Entry(persona_juridica).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            PERSONA_JURIDICAs pERSONA_JURIDICA = db.PERSONA_JURIDICAs.Find(id);
            db.PERSONA_JURIDICAs.Remove(pERSONA_JURIDICA);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}