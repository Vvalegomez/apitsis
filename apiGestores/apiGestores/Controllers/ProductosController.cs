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
                return Ok(context.Articulos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{ArtCodigo}", Name = "GetProductos")]
        public ActionResult Get(int ArtCodigo)
        {
            try
            {
                var productos = context.Articulos.FirstOrDefault(g => g.ArtCodigo == ArtCodigo);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Articulos productos)
        {
            try
            {
                context.Articulos.Add(productos);
                context.SaveChanges();
                return CreatedAtRoute("GetProductos", new { ArtCodigo = productos.ArtCodigo }, productos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{ArtCodigo}")]
        public ActionResult Put(int ArtCodigo, [FromBody] Articulos productos)
        {
            try
            {
                if (productos.ArtCodigo == ArtCodigo)
                {
                    context.Entry(productos).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetProductos", new { ArtCodigo = productos.ArtCodigo }, productos);
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
        [HttpDelete("{ArtCodigo}")]
        public ActionResult Delete(int ArtCodigo)
        {
            try
            {
                var productos = context.Articulos.FirstOrDefault(g => g.ArtCodigo == ArtCodigo);
                if (productos != null)
                {
                    context.Articulos.Remove(productos);
                    context.SaveChanges();
                    return Ok(ArtCodigo);
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
