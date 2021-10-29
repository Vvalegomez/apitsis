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
    
    public class ReportesController : Controller
    {
        private readonly AppDbContext context;
        public ReportesController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Reportes.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{IdReporte}", Name = "GetReportes")]
        public ActionResult Get(int IdReporte)
        {
            try
            {
                var reportes = context.Reportes.FirstOrDefault(g => g.IdReporte == IdReporte);
                return Ok(reportes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody] Reportes reportes)
        {
            try
            {
                context.Reportes.Add(reportes);
                context.SaveChanges();
                return CreatedAtRoute("GetReportes", new { IdReporte = reportes.IdReporte }, reportes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{IdReporte}")]
        public ActionResult Put(int IdReporte, [FromBody] Reportes reportes)
        {
            try
            {
                if (reportes.IdReporte == IdReporte)
                {
                    context.Entry(reportes).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetReportes", new { IdReporte = reportes.IdReporte }, reportes);
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
        [HttpDelete("{IdReporte}")]
        public ActionResult Delete(int IdReporte)
        {
            try
            {
                var reportes = context.Reportes.FirstOrDefault(g => g.IdReporte == IdReporte);
                if (reportes != null)
                {
                    context.Reportes.Remove(reportes);
                    context.SaveChanges();
                    return Ok(IdReporte);
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
