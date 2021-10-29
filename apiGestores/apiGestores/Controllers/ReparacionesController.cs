using apiGestores.Context;
using apiGestores.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiGestores.Controllers
{
    [Route("api/[controller]")]
    
    public class ReparacionesController : Controller
    {
        private readonly AppDbContext context;

        public ReparacionesController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Reparaciones.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{IdReparacion}", Name = "GetReparaciones")]
        public ActionResult Get(int IdReparacion)
        {
            try
            {
                var reparaciones = context.Reparaciones.FirstOrDefault(g => g.IdReparacion == IdReparacion);
                return Ok(reparaciones);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Reparaciones reparaciones)
        {
            try
            {
                context.Reparaciones.Add(reparaciones);
                context.SaveChanges();
                return CreatedAtRoute("GetReparaciones", new { IdReparacion = reparaciones.IdReparacion }, reparaciones);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{IdReparacion}")]
        public ActionResult Put(int IdReparacion, [FromBody] Reparaciones reparaciones)
        {
            try
            {
                if (reparaciones.IdReparacion == IdReparacion)
                {
                    context.Entry(reparaciones).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetReparaciones", new { IdReparacion = reparaciones.IdReparacion }, reparaciones);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{IdReparacion}")]
        public ActionResult Delete(int IdReparacion)
        {
            try
            {
                var reparaciones = context.Reparaciones.FirstOrDefault(g => g.IdReparacion == IdReparacion);
                if (reparaciones != null)
                {
                    context.Reparaciones.Remove(reparaciones);
                    context.SaveChanges();
                    return Ok(IdReparacion);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
