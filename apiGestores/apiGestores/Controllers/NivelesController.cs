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
    
    public class NivelesController : Controller
    {
        private readonly AppDbContext context;
        public NivelesController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Niveles.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{NivCodigo}", Name = "GetNiveles")]
        public ActionResult Get(int NivCodigo)
        {
            try
            {
                var niveles = context.Niveles.FirstOrDefault(g => g.NivCodigo == NivCodigo);
                return Ok(niveles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Niveles niveles)
        {
            try
            {
                context.Niveles.Add(niveles);
                context.SaveChanges();
                return CreatedAtRoute("GetNiveles", new { NivCodigo = niveles.NivCodigo }, niveles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{NivCodigo}")]
        public ActionResult Put(int NivCodigo, [FromBody] Niveles niveles)
        {
            try
            {
                if (niveles.NivCodigo == NivCodigo)
                {
                    context.Entry(niveles).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetNiveles", new { NivCodigo = niveles.NivCodigo }, niveles);
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
        [HttpDelete("{NivCodigo}")]
        public ActionResult Delete(int NivCodigo)
        {
            try
            {
                var niveles = context.Niveles.FirstOrDefault(g => g.NivCodigo == NivCodigo);
                if (niveles != null)
                {
                    context.Niveles.Remove(niveles);
                    context.SaveChanges();
                    return Ok(NivCodigo);
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
