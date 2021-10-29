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
    
    public class ProductoRepaController : Controller
    {
        private readonly AppDbContext context;
        public ProductoRepaController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.ProductoRepa.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{IdProductoRep}", Name = "GetProductoRepa")]
        public ActionResult Get(int IdProductoRep)
        {
            try
            {
                var productoRep = context.ProductoRepa.FirstOrDefault(g => g.IdProductoRep == IdProductoRep);
                return Ok(productoRep);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] ProductoRepa productoRep)
        {
            try
            {
                context.ProductoRepa.Add(productoRep);
                context.SaveChanges();
                return CreatedAtRoute("GetProductoRepa", new { IdProductoRep = productoRep.IdProductoRep }, productoRep);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{IdProductoRep}")]
        public ActionResult Put(int IdProductoRep, [FromBody] ProductoRepa productoRep)
        {
            try
            {
                if (productoRep.IdProductoRep == IdProductoRep)
                {
                    context.Entry(productoRep).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetProductoRepa", new { IdProductoRep = productoRep.IdProductoRep }, productoRep);
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
        [HttpDelete("{IdProductoRep}")]
        public ActionResult Delete(int IdProductoRep)
        {
            try
            {
                var productoRep = context.ProductoRepa.FirstOrDefault(g => g.IdProductoRep == IdProductoRep);
                if (productoRep != null)
                {
                    context.ProductoRepa.Remove(productoRep);
                    context.SaveChanges();
                    return Ok(IdProductoRep);
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
