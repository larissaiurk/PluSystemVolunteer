using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PluSystemVolunteer.utils
{
    public class Sessao
    {
        

        public static int Login(string idUsuario, bool administrador)
        {
            //inicia os sessions com o id do usuario e o status de administrador
            HttpContext.Current.Session["usuario"] = idUsuario;
            string admin = "";
            if (administrador == true) { admin = "1"; } else { admin = "0"; }
            HttpContext.Current.Session["administrador"] = admin;
            return Convert.ToInt32(HttpContext.Current.Session[idUsuario]);

        }
        public static int RetornarUsuario()
        {
            if (HttpContext.Current.Session["usuario"] == null)
            {
                return 0;
            }
            //retornando id do usuario 
            return Convert.ToInt32(HttpContext.Current.Session["usuario"]);
        }
        public static int RetornarStatus()
        {
            
            if (HttpContext.Current.Session["administrador"] == null)
            {
                return 0;
            }
            //retornando status de administrador "1"=administrador  "0"=usuario comum converter para int Convert.ToInt32(
            return Convert.ToInt32(HttpContext.Current.Session["administrador"]); 
        }

        public static void ZerarSessao()
        {
            HttpContext.Current.Session["usuario"] = null;
            HttpContext.Current.Session["administrador"] = null;

        }

    }

}