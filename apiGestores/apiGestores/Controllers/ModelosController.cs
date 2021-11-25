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
    
    public class ModelosController : Controller
    {
        private readonly AppDbContext context;
        public ModelosController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Modelos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{ModCodigo}", Name = "GetModelos")]
        public ActionResult Get(int ModCodigo)
        {
            try
            {
                var modelos = context.Modelos.FirstOrDefault(g => g.ModCodigo == ModCodigo);
                return Ok(modelos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Modelos modelos)
        {
            try
            {
                context.Modelos.Add(modelos);
                context.SaveChanges();
                return CreatedAtRoute("GetModelos", new { ModCodigo = modelos.ModCodigo }, modelos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{ModCodigo}")]
        public ActionResult Put(int ModCodigo, [FromBody] Modelos modelos)
        {
            try
            {
                if (modelos.ModCodigo == ModCodigo)
                {
                    context.Entry(modelos).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetModelos", new { ModCodigo = modelos.ModCodigo }, modelos);
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
        [HttpDelete("{ModCodigo}")]
        public ActionResult Delete(int ModCodigo)
        {
            try
            {
                var modelos = context.Modelos.FirstOrDefault(g => g.ModCodigo == ModCodigo);
                if (modelos != null)
                {
                    context.Modelos.Remove(modelos);
                    context.SaveChanges();
                    return Ok(ModCodigo);
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
