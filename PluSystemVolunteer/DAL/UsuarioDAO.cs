using PluSystemVolunteer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PluSystemVolunteer.DAL
{
    public class UsuarioDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static void CadastrarUsuario(Usuario user)
        {
            ctx.Usuarios.Add(user);
            ctx.SaveChanges();
        }

        public static Usuario BuscarUsuarioPorLoginSenha(Usuario usuario)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Login.Equals(usuario.Login) && x.Senha.Equals(usuario.Senha));
        }
        public static Usuario Login(Usuario login)
        {
            try
            {
                Usuario user = ctx.Usuarios.Find(login);
                if (user != null)
                {

                    if (user.Senha.Equals(login.Senha))
                    {
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
        }
        public static List<Usuario> RetornarUsuarios()
        {
            return ctx.Usuarios.ToList();
        }

        public static List<Usuario> RetornarUsuariosPorPontuacao()
        {
            return ctx.Usuarios.OrderByDescending(x => x.Pontuacao).ToList() ;
        }
       
        public static Usuario BuscarUsuarioPorId(int? id)
        {
            return ctx.Usuarios.Find(id);
        }
        public static void RemoverUsuario(Usuario u)
        {
            ctx.Usuarios.Remove(u);
            ctx.SaveChanges();
        }

        public static void AlterarUsuario(Usuario u)
        {
            ctx.Entry(u).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}