
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
    public class PojavljujeSeNaController:ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiSveRevijeGdeSePojavljujeVip/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetNaslovneStrane(int id)
        {
            try
            {
                return new JsonResult(DataProvider.vratiSveRevijeGdeSeVipPojavljuje(DataProvider.vratiVip(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodeliRevijuVipu/{rbr}/{id}/{idp}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddRevijaVipu(int rbr, int id,int idp)
        {
            try
            {
                DataProvider.dodeliRevijuVipu(rbr,id,idp);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }



        [HttpDelete]
        [Route("UkloniVipaSaRevije/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteVipaSaRevije(int id)
        {
            try
            {
                DataProvider.obrisiPojavljujeSeNa(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPut]
        [Route("PromeniRevijuNaKojojSePosjavljujeVip")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeRevijaNaKojojSeVipPojavljuje([FromBody] PojavljujeSeNaView p)
        {
            try
            {
                DataProvider.izmeniGdeSePojavljujeVip(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
