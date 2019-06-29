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
    [RoutePrefix("api/Evento")]
    public class EventoApiController : ApiController
    {
        //GET api/Evento/Eventos
        [HttpGet]
        [Route("Eventos")]
        public List<Evento> Eventos()
        {
            return EventoDAO.RetornarEventos();
        }

        //GET api/Evento/EventoPorId
        [HttpGet]
        [Route("EventoPorId/{id}")]
        public Evento EventoPorId(int id)
        {
            return EventoDAO.BuscarEventoPorId(id);
        }

    }
}
