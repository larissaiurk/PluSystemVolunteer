using PluSystemVolunteer.DAL;
using PluSystemVolunteer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PluSystemVolunteer.Controllers
{
    [RoutePrefix("api/Usuario")]
    public class UsuarioApiController : ApiController
    {
        //GET api/Usuario/Usuarios
        [HttpGet]
        [Route("Usuarios")]
        public List<Usuario> Usuarios()
        {
            return UsuarioDAO.RetornarUsuarios();
        }

        //GET api/Usuario/UsuarioPorId
        [HttpGet]
        [Route("UsuarioPorId/{id}")]
        public Usuario UsuarioPorId(int id)
        {
            return UsuarioDAO.BuscarUsuarioPorId(id);
        }
    }
}
