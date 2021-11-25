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
    
    public class EstadosController : Controller
    {
        private readonly AppDbContext context;
        public EstadosController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Estados.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{EstaCodigo}", Name = "GetEstados")]
        public ActionResult Get(int EstaCodigo)
        {
            try
            {
                var estados = context.Estados.FirstOrDefault(g => g.EstaCodigo == EstaCodigo);
                return Ok(estados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Estados estados)
        {
            try
            {
                context.Estados.Add(estados);
                context.SaveChanges();
                return CreatedAtRoute("GetEstados", new { EstaCodigo = estados.EstaCodigo }, estados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{EstaCodigo}")]
        public ActionResult Put(int EstaCodigo, [FromBody] Estados estados)
        {
            try
            {
                if (estados.EstaCodigo == EstaCodigo)
                {
                    context.Entry(estados).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetEstados", new { EstaCodigo = estados.EstaCodigo }, estados);
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
        [HttpDelete("{EstaCodigo}")]
        public ActionResult Delete(int EstaCodigo)
        {
            try
            {
                var estados = context.Estados.FirstOrDefault(g => g.EstaCodigo == EstaCodigo);
                if (estados != null)
                {
                    context.Estados.Remove(estados);
                    context.SaveChanges();
                    return Ok(EstaCodigo);
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
