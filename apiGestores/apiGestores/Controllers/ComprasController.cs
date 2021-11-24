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
        [HttpGet("{ComCodigo}", Name = "GetCompras")]
        public ActionResult Get(int ComCodigo)
        {
            try
            {
                var compras = context.Compras.FirstOrDefault(g => g.ComCodigo == ComCodigo);
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
                return CreatedAtRoute("GetCompras", new { ComCodigo = compras.ComCodigo }, compras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{ComCodigo}")]
        public ActionResult Put(int ComCodigo, [FromBody] Compras compras)
        {
            try
            {
                if (compras.ComCodigo == ComCodigo)
                {
                    context.Entry(compras).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCompras", new { ComCodigo = compras.ComCodigo }, compras);
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
        [HttpDelete("{ComCodigo}")]
        public ActionResult Delete(int ComCodigo)
        {
            try
            {
                var compras = context.Compras.FirstOrDefault(g => g.ComCodigo == ComCodigo);
                if (compras != null)
                {
                    context.Compras.Remove(compras);
                    context.SaveChanges();
                    return Ok(ComCodigo);
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
