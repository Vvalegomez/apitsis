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
    
    public class CiudadController : Controller
    {
        private readonly AppDbContext context;
        public CiudadController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Ciudades.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{ciu_codigo}", Name = "GetCiudad")]
        public ActionResult Get(int CiuCodigo)
        {
            try
            {
                var ciudad = context.Ciudades.FirstOrDefault(g => g.ciu_codigo == CiuCodigo);
                return Ok(ciudad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Ciudades ciudad)
        {
            try
            {
                context.Ciudades.Add(ciudad);
                context.SaveChanges();
                return CreatedAtRoute("GetCiudad", new { CiuCodigo = ciudad.ciu_codigo }, ciudad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{CiuCodigo}")]
        public ActionResult Put(int CiuCodigo, [FromBody] Ciudades ciudad)
        {
            try
            {
                if (ciudad.ciu_codigo == CiuCodigo)
                {
                    context.Entry(ciudad).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { CiuCodigo = ciudad.ciu_codigo }, ciudad);
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
        [HttpDelete("{CiuCodigo}")]
        public ActionResult Delete(int CiuCodigo)
        {
            try
            {
                var ciudad = context.Ciudades.FirstOrDefault(g => g.ciu_codigo == CiuCodigo);
                if (ciudad != null)
                {
                    context.Ciudades.Remove(ciudad);
                    context.SaveChanges();
                    return Ok(CiuCodigo);
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
