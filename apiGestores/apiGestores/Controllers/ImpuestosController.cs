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
        [HttpGet("{ImpCodigo}", Name = "GetImpuestos")]
        public ActionResult Get(int ImpCodigo)
        {
            try
            {
                var impuestos = context.Impuestos.FirstOrDefault(g => g.ImpCodigo == ImpCodigo);
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
                return CreatedAtRoute("GetImpuestos", new { ImpCodigo = impuestos.ImpCodigo }, impuestos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{ImpCodigo}")]
        public ActionResult Put(int ImpCodigo, [FromBody] Impuestos impuestos)
        {
            try
            {
                if (impuestos.ImpCodigo == ImpCodigo)
                {
                    context.Entry(impuestos).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetImpuestos", new { ImpCodigo = impuestos.ImpCodigo }, impuestos);
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
        [HttpDelete("{ImpCodigo}")]
        public ActionResult Delete(int ImpCodigo)
        {
            try
            {
                var impuesto = context.Impuestos.FirstOrDefault(g => g.ImpCodigo == ImpCodigo);
                if (impuesto != null)
                {
                    context.Impuestos.Remove(impuesto);
                    context.SaveChanges();
                    return Ok(ImpCodigo);
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
