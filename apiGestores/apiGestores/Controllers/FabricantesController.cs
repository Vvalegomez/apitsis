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
        [HttpGet("{IdFabricante}", Name = "GetFabricantes")]
        public ActionResult Get(int IdFabricante)
        {
            try
            {
                var fabricantes = context.Fabricantes.FirstOrDefault(g => g.IdFabricante == IdFabricante);
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
                return CreatedAtRoute("GetFabricantes", new { IdFabricante = fabricantes.IdFabricante }, fabricantes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{IdFabricante}")]
        public ActionResult Put(int IdFabricante, [FromBody] Fabricantes fabricantes)
        {
            try
            {
                if (fabricantes.IdFabricante == IdFabricante)
                {
                    context.Entry(fabricantes).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetFabricantes", new { IdFabricante = fabricantes.IdFabricante }, fabricantes);
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
        [HttpDelete("{IdFabricante}")]
        public ActionResult Delete(int IdFabricante)
        {
            try
            {
                var fabricantes = context.Fabricantes.FirstOrDefault(g => g.IdFabricante == IdFabricante);
                if (fabricantes != null)
                {
                    context.Fabricantes.Remove(fabricantes);
                    context.SaveChanges();
                    return Ok(IdFabricante);
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
