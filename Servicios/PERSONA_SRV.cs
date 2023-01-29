using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sistema_UVM_Control_Presupuestario.Servicios
{
    public class PERSONA_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<PERSONA> Listar()
        {
            return db.PERSONAs.ToList();
        }
        public PERSONA Buscar(int? id)
        {
            if (id == null) 
                return null;
            return db.PERSONAs.Find(id);
        }
        public void Agregar(PERSONA persona)
        {
            db.PERSONAs.Add(persona);
            db.SaveChanges();
        }
        public void Editar(PERSONA persona)
        {
            db.Entry(persona).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            PERSONA pERSONA = db.PERSONAs.Find(id);
            db.PERSONAs.Remove(pERSONA);
            db.SaveChanges();
        }
        public void Dispose()
        {

        }
    }
}