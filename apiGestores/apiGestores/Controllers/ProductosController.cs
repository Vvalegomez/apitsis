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
    
    public class ProductosController : Controller
    {
        private readonly AppDbContext context;
        public ProductosController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Productos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{IdProducto}", Name = "GetProductos")]
        public ActionResult Get(int IdProducto)
        {
            try
            {
                var productos = context.Productos.FirstOrDefault(g => g.IdProducto == IdProducto);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Productos productos)
        {
            try
            {
                context.Productos.Add(productos);
                context.SaveChanges();
                return CreatedAtRoute("GetProductos", new { IdProducto = productos.IdProducto }, productos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{IdProducto}")]
        public ActionResult Put(int IdProducto, [FromBody] Productos productos)
        {
            try
            {
                if (productos.IdProducto == IdProducto)
                {
                    context.Entry(productos).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetProductos", new { IdProducto = productos.IdProducto }, productos);
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
        [HttpDelete("{IdProducto}")]
        public ActionResult Delete(int IdProducto)
        {
            try
            {
                var productos = context.Productos.FirstOrDefault(g => g.IdProducto == IdProducto);
                if (productos != null)
                {
                    context.Productos.Remove(productos);
                    context.SaveChanges();
                    return Ok(IdProducto);
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
