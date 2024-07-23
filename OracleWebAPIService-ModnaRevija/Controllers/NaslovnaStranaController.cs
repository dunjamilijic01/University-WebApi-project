using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OracleWebAPIService_ModnaRevija.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NaslovnaStranaController: ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiNaslovneStraneModela/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetNaslovneStrane(int id)
        {
            try
            {
                return new JsonResult(DataProvider.vratiSveNaslovneStrane(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajNaslovnuStranuModelu/{id}/{naziv}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddNaslovnaStranaModelu(int id,string naziv)
        {
            try
            {
                DataProvider.dodajNaslovnuStranu(DataProvider.vratiManekena(id),naziv);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniNaslovnuStaru")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeNaslovnaStrana([FromBody] NaslovnaStranaView str)
        {
            try
            {
                DataProvider.IzmeniNaslovnuStranu(str);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiNaslovnuStranu/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteNaslovnaStrana(int id)
        {
            try
            {
                DataProvider.obrisiStranicu(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
