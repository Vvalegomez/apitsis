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
    
    public class PaisesController : Controller
    {
        private readonly AppDbContext context;
        public PaisesController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Paises.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{PaisCodigo}", Name = "GetPaises")]
        public ActionResult Get(int PaisCodigo)
        {
            try
            {
                var paises = context.Paises.FirstOrDefault(g => g.PaisCodigo == PaisCodigo);
                return Ok(paises);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Paises paises)
        {
            try
            {
                context.Paises.Add(paises);
                context.SaveChanges();
                return CreatedAtRoute("GetPaises", new { PaisCodigo = paises.PaisCodigo }, paises);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{PaisCodigo}")]
        public ActionResult Put(int PaisCodigo, [FromBody] Paises paises)
        {
            try
            {
                if (paises.PaisCodigo == PaisCodigo)
                {
                    context.Entry(paises).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetPaises", new { PaisCodigo = paises.PaisCodigo }, paises);
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
        [HttpDelete("{PaisCodigo}")]
        public ActionResult Delete(int PaisCodigo)
        {
            try
            {
                var paises = context.Paises.FirstOrDefault(g => g.PaisCodigo == PaisCodigo);
                if (paises != null)
                {
                    context.Paises.Remove(paises);
                    context.SaveChanges();
                    return Ok(PaisCodigo);
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
