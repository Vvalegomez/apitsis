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
    
    public class UsuariosController : Controller
    {
        private readonly AppDbContext context;
        public UsuariosController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Usuarios.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{UsuCodigo}", Name = "GetUsuarios")]
        public ActionResult Get(int UsuCodigo)
        {
            try
            {
                var usuarios = context.Usuarios.FirstOrDefault(g => g.UsuCodigo == UsuCodigo);
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Usuarios usuarios)
        {
            try
            {
                context.Usuarios.Add(usuarios);
                context.SaveChanges();
                return CreatedAtRoute("GetUsuarios", new { UsuCodigo = usuarios.UsuCodigo }, usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{UsuCodigo}")]
        public ActionResult Put(int UsuCodigo, [FromBody] Usuarios usuarios)
        {
            try
            {
                if (usuarios.UsuCodigo == UsuCodigo)
                {
                    context.Entry(usuarios).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetUsuarios", new { UsuCodigo = usuarios.UsuCodigo }, usuarios);
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
        [HttpDelete("{UsuCodigo}")]
        public ActionResult Delete(int UsuCodigo)
        {
            try
            {
                var usuarios = context.Usuarios.FirstOrDefault(g => g.UsuCodigo == UsuCodigo);
                if (usuarios != null)
                {
                    context.Usuarios.Remove(usuarios);
                    context.SaveChanges();
                    return Ok(UsuCodigo);
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
