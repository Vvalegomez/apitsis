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
    
    public class ImpuestosController : Controller
    {
        private readonly AppDbContext context;
        public ImpuestosController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Impuestos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{IdImpuesto}", Name = "GetImpuestos")]
        public ActionResult Get(int IdImpuesto)
        {
            try
            {
                var impuestos = context.Impuestos.FirstOrDefault(g => g.IdImpuesto == IdImpuesto);
                return Ok(impuestos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Impuestos impuestos)
        {
            try
            {
                context.Impuestos.Add(impuestos);
                context.SaveChanges();
                return CreatedAtRoute("GetImpuestos", new { IdImpuesto = impuestos.IdImpuesto }, impuestos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{IdImpuesto}")]
        public ActionResult Put(int IdImpuesto, [FromBody] Impuestos impuestos)
        {
            try
            {
                if (impuestos.IdImpuesto == IdImpuesto)
                {
                    context.Entry(impuestos).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetImpuestos", new { IdImpuesto = impuestos.IdImpuesto }, impuestos);
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
        [HttpDelete("{IdImpuesto}")]
        public ActionResult Delete(int IdImpuesto)
        {
            try
            {
                var impuesto = context.Impuestos.FirstOrDefault(g => g.IdImpuesto == IdImpuesto);
                if (impuesto != null)
                {
                    context.Impuestos.Remove(impuesto);
                    context.SaveChanges();
                    return Ok(IdImpuesto);
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
