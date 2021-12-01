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
    public class ProvinciasController : Controller
    {
        private readonly AppDbContext context;
        public ProvinciasController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Provincias.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{ProvCodigo}", Name = "GetProvincias")]
        public ActionResult Get(int ProvCodigo)
        {
            try
            {
                var provincias = context.Provincias.FirstOrDefault(g => g.ProvCodigo == ProvCodigo);
                return Ok(provincias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Provincias provincias)
        {
            try
            {
                context.Provincias.Add(provincias);
                context.SaveChanges();
                return CreatedAtRoute("GetProvincias", new { ProvCodigo = provincias.ProvCodigo }, provincias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{ProvCodigo}")]
        public ActionResult Put(int ProvCodigo, [FromBody] Provincias provincias)
        {
            try
            {
                if (provincias.ProvCodigo == ProvCodigo)
                {
                    context.Entry(provincias).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetProvincias", new { ProvCodigo = provincias.ProvCodigo }, provincias);
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
        [HttpDelete("{ProvCodigo}")]
        public ActionResult Delete(int ProvCodigo)
        {
            try
            {
                var provincias = context.Provincias.FirstOrDefault(g => g.ProvCodigo == ProvCodigo);
                if (provincias != null)
                {
                    context.Provincias.Remove(provincias);
                    context.SaveChanges();
                    return Ok(ProvCodigo);
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
