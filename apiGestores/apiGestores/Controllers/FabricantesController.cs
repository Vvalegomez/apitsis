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
    
    public class FabricantesController : Controller
    {
        private readonly AppDbContext context;
        public FabricantesController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Fabricantes.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{FabCodigo}", Name = "GetFabricantes")]
        public ActionResult Get(int FabCodigo)
        {
            try
            {
                var fabricantes = context.Fabricantes.FirstOrDefault(g => g.FabCodigo == FabCodigo);
                return Ok(fabricantes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Fabricantes fabricantes)
        {
            try
            {
                context.Fabricantes.Add(fabricantes);
                context.SaveChanges();
                return CreatedAtRoute("GetFabricantes", new { FabCodigo = fabricantes.FabCodigo }, fabricantes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{FabCodigo}")]
        public ActionResult Put(int FabCodigo, [FromBody] Fabricantes fabricantes)
        {
            try
            {
                if (fabricantes.FabCodigo == FabCodigo)
                {
                    context.Entry(fabricantes).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetFabricantes", new { FabCodigo = fabricantes.FabCodigo }, fabricantes);
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
        [HttpDelete("{FabCodigo}")]
        public ActionResult Delete(int FabCodigo)
        {
            try
            {
                var fabricantes = context.Fabricantes.FirstOrDefault(g => g.FabCodigo == FabCodigo);
                if (fabricantes != null)
                {
                    context.Fabricantes.Remove(fabricantes);
                    context.SaveChanges();
                    return Ok(FabCodigo);
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
