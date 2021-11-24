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
    
    public class SucursalController : Controller
    {
        private readonly AppDbContext context;
        public SucursalController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Sucursales.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{SucCodigo}", Name = "GetSucursales")]
        public ActionResult Get(int SucCodigo)
        {
            try
            {
                var sucursal = context.Sucursales.FirstOrDefault(g => g.SucCodigo == SucCodigo);
                return Ok(sucursal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Sucursales sucursal)
        {
            try
            {
                context.Sucursales.Add(sucursal);
                context.SaveChanges();
                return CreatedAtRoute("GetSucursales", new { SucCodigo = sucursal.SucCodigo }, sucursal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{SucCodigo}")]
        public ActionResult Put(int SucCodigo, [FromBody] Sucursales sucursal)
        {
            try
            {
                if (sucursal.SucCodigo == SucCodigo)
                {
                    context.Entry(sucursal).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetSucursales", new { SucCodigo = sucursal.SucCodigo }, sucursal);
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
        [HttpDelete("{SucCodigo}")]
        public ActionResult Delete(int SucCodigo)
        {
            try
            {
                var sucursal = context.Sucursales.FirstOrDefault(g => g.SucCodigo == SucCodigo);
                if (sucursal != null)
                {
                    context.Sucursales.Remove(sucursal);
                    context.SaveChanges();
                    return Ok(SucCodigo);
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
