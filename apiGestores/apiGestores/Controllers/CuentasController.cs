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
    
    public class CuentasController : Controller
    {
        private readonly AppDbContext context;
        public CuentasController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Cuentas.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{CueCodigo}", Name = "GetCuentas")]
        public ActionResult Get(int CueCodigo)
        {
            try
            {
                var cuentas = context.Cuentas.FirstOrDefault(g => g.CueCodigo == CueCodigo);
                return Ok(cuentas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Cuentas cuentas)
        {
            try
            {
                context.Cuentas.Add(cuentas);
                context.SaveChanges();
                return CreatedAtRoute("GetCuentas", new { CueCodigo = cuentas.CueCodigo }, cuentas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{CueCodigo}")]
        public ActionResult Put(int CueCodigo, [FromBody] Cuentas cuentas)
        {
            try
            {
                if (cuentas.CueCodigo == CueCodigo)
                {
                    context.Entry(cuentas).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetCuentas", new { CueCodigo = cuentas.CueCodigo }, cuentas);
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
        [HttpDelete("{CueCodigo}")]
        public ActionResult Delete(int CueCodigo)
        {
            try
            {
                var cuentas = context.Cuentas.FirstOrDefault(g => g.CueCodigo == CueCodigo);
                if (cuentas != null)
                {
                    context.Cuentas.Remove(cuentas);
                    context.SaveChanges();
                    return Ok(CueCodigo);
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
