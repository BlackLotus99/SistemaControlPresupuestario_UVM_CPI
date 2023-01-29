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
    public class USUARIO_SRV
    {
        private SCP_UVMEntities db = new SCP_UVMEntities();

        public List<USUARIO> Listar()
        {
            var usuarios = db.USUARIOs.Include(u => u.ROL);
            return usuarios.ToList();
        }
        public USUARIO Buscar(int? id)
        {
            if (id == null)
                return null;
            return db.USUARIOs.Find(id);
        }
        public void Agregar(USUARIO usuario)
        {
            db.USUARIOs.Add(usuario);
            db.SaveChanges();
        }
        public void Editar(USUARIO usuario)
        {
            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Eliminar(int id)
        {
            USUARIO uSUARIO = db.USUARIOs.Find(id);
            db.USUARIOs.Remove(uSUARIO);
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}