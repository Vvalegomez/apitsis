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
    
    public class ArticulosController : Controller
    {
        private readonly AppDbContext context;
        public ArticulosController(AppDbContext context)
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
        [HttpGet("{ArtCodigo}", Name = "GetArticulos")]
        public ActionResult Get(int ArtCodigo)
        {
            try
            {
                var articulos = context.Articulos.FirstOrDefault(g => g.ArtCodigo == ArtCodigo);
                return Ok(articulos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Articulos articulos)
        {
            try
            {
                context.Articulos.Add(articulos);
                context.SaveChanges();
                return CreatedAtRoute("GetArticulos", new { ArtCodigo = articulos.ArtCodigo }, articulos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{ArtCodigo}")]
        public ActionResult Put(int ArtCodigo, [FromBody] Articulos articulos)
        {
            try
            {
                if (articulos.ArtCodigo == ArtCodigo)
                {
                    context.Entry(articulos).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetArticulos", new { ArtCodigo = articulos.ArtCodigo }, articulos);
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
                var articulos = context.Articulos.FirstOrDefault(g => g.ArtCodigo == ArtCodigo);
                if (articulos != null)
                {
                    context.Articulos.Remove(articulos);
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
