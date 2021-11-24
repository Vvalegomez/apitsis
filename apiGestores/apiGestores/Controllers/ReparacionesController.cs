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
        [HttpGet("{RepaCodigo}", Name = "GetReparaciones")]
        public ActionResult Get(int RepaCodigo)
        {
            try
            {
                var reparaciones = context.Reparaciones.FirstOrDefault(g => g.RepaCodigo == RepaCodigo);
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
                return CreatedAtRoute("GetReparaciones", new { RepaCodigo = reparaciones.RepaCodigo }, reparaciones);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{RepaCodigo}")]
        public ActionResult Put(int RepaCodigo, [FromBody] Reparaciones reparaciones)
        {
            try
            {
                if (reparaciones.RepaCodigo == RepaCodigo)
                {
                    context.Entry(reparaciones).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetReparaciones", new { RepaCodigo = reparaciones.RepaCodigo }, reparaciones);
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
        [HttpDelete("{RepaCodigo}")]
        public ActionResult Delete(int RepaCodigo)
        {
            try
            {
                var reparaciones = context.Reparaciones.FirstOrDefault(g => g.RepaCodigo == RepaCodigo);
                if (reparaciones != null)
                {
                    context.Reparaciones.Remove(reparaciones);
                    context.SaveChanges();
                    return Ok(RepaCodigo);
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
