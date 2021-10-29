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
                return Ok(context.Sucursal.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{IdSucursal}", Name = "GetSucursales")]
        public ActionResult Get(int IdSucursal)
        {
            try
            {
                var sucursal = context.Sucursal.FirstOrDefault(g => g.IdSucursal == IdSucursal);
                return Ok(sucursal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Sucursal sucursal)
        {
            try
            {
                context.Sucursal.Add(sucursal);
                context.SaveChanges();
                return CreatedAtRoute("GetSucursales", new { IdSucursal = sucursal.IdSucursal }, sucursal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{IdSucursal}")]
        public ActionResult Put(int IdSucursal, [FromBody] Sucursal sucursal)
        {
            try
            {
                if (sucursal.IdSucursal == IdSucursal)
                {
                    context.Entry(sucursal).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetSucursales", new { IdSucursal = sucursal.IdSucursal }, sucursal);
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
        [HttpDelete("{IdSucursal}")]
        public ActionResult Delete(int IdSucursal)
        {
            try
            {
                var sucursal = context.Sucursal.FirstOrDefault(g => g.IdSucursal == IdSucursal);
                if (sucursal != null)
                {
                    context.Sucursal.Remove(sucursal);
                    context.SaveChanges();
                    return Ok(IdSucursal);
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
