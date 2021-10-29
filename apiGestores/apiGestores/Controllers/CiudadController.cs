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
    
    public class CiudadController : Controller
    {
        private readonly AppDbContext context;
        public CiudadController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Ciudad.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{idCiudad}", Name = "GetCiudad")]
        public ActionResult Get(int idCiudad)
        {
            try
            {
                var ciudad = context.Ciudad.FirstOrDefault(g => g.idCiudad == idCiudad);
                return Ok(ciudad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Ciudad ciudad)
        {
            try
            {
                context.Ciudad.Add(ciudad);
                context.SaveChanges();
                return CreatedAtRoute("GetCiudad", new { idCiudad = ciudad.idCiudad }, ciudad);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{idCiudad}")]
        public ActionResult Put(int idCiudad, [FromBody] Ciudad ciudad)
        {
            try
            {
                if (ciudad.idCiudad == idCiudad)
                {
                    context.Entry(ciudad).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { idCiudad = ciudad.idCiudad }, ciudad);
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
        [HttpDelete("{idCiudad}")]
        public ActionResult Delete(int idCiudad)
        {
            try
            {
                var ciudad = context.Ciudad.FirstOrDefault(g => g.idCiudad == idCiudad);
                if (ciudad != null)
                {
                    context.Ciudad.Remove(ciudad);
                    context.SaveChanges();
                    return Ok(idCiudad);
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
