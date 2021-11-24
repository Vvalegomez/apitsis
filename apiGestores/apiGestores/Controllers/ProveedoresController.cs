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
    
    public class ProveedoresController : Controller
    {
        private readonly AppDbContext context;
        public ProveedoresController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Proveedores.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{ProveCodigo}", Name = "GetProveedores")]
        public ActionResult Get(int ProveCodigo)
        {
            try
            {
                var proveedores = context.Proveedores.FirstOrDefault(g => g.ProveCodigo == ProveCodigo);
                return Ok(proveedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Proveedores proveedores)
        {
            try
            {
                context.Proveedores.Add(proveedores);
                context.SaveChanges();
                return CreatedAtRoute("GetProveedores", new { ProveCodigo = proveedores.ProveCodigo }, proveedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{ProveCodigo}")]
        public ActionResult Put(int ProveCodigo, [FromBody] Proveedores proveedores)
        {
            try
            {
                if (proveedores.ProveCodigo == ProveCodigo)
                {
                    context.Entry(proveedores).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetProveedores", new { ProveCodigo = proveedores.ProveCodigo }, proveedores);
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
        [HttpDelete("{ProveCodigo}")]
        public ActionResult Delete(int ProveCodigo)
        {
            try
            {
                var proveedores = context.Proveedores.FirstOrDefault(g => g.ProveCodigo == ProveCodigo);
                if (proveedores != null)
                {
                    context.Proveedores.Remove(proveedores);
                    context.SaveChanges();
                    return Ok(ProveCodigo);
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
