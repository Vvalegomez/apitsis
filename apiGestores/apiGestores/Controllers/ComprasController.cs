using apiGestores.Context;
using apiGestores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiGestores.Controllers
{
    [Route("api/[controller]")]
    public class ComprasController : Controller
    {
        private readonly AppDbContext context;
        public ComprasController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Compras.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{IdCompra}", Name = "GetCompras")]
        public ActionResult Get(int IdCompra)
        {
            try
            {
                var compras = context.Compras.FirstOrDefault(g => g.IdCompra == IdCompra);
                return Ok(compras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Compras compras)
        {
            try
            {
                context.Compras.Add(compras);
                context.SaveChanges();
                return CreatedAtRoute("GetCompras", new { IdCompra = compras.IdCompra }, compras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{IdCompra}")]
        public ActionResult Put(int IdCompra, [FromBody] Compras compras)
        {
            try
            {
                if (compras.IdCompra == IdCompra)
                {
                    context.Entry(compras).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCompras", new { IdCompra = compras.IdCompra }, compras);
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
        [HttpDelete("{IdCompra}")]
        public ActionResult Delete(int IdCompra)
        {
            try
            {
                var compras = context.Compras.FirstOrDefault(g => g.IdCompra == IdCompra);
                if (compras != null)
                {
                    context.Compras.Remove(compras);
                    context.SaveChanges();
                    return Ok(IdCompra);
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
