using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Negocio.Interfaces;

namespace Negocio.Servicios
{
    public class ServiceUsuario: IUsuario
    {
        private SorteosDbContext db;
        public ServiceUsuario(SorteosDbContext db) {
            
            this.db = db;
        }

        public Usuario CreateUsuario(Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            db.SaveChanges();
            return usuario;
        }

        public Usuario GetUsuarioId(int idUsuario)
        {
            Usuario ? usuario = db.Usuarios.FirstOrDefault(n => n.IdUsuario == idUsuario);
            if (usuario == null)
            {
                throw new InvalidOperationException("No se encontró el usuario");
            }
            return usuario;
        }

        public List<Usuario> GetUsuarios()
        {
            return db.Usuarios.ToList();
        }
    }
}
