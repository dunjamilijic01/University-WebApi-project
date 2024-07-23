using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess;
using Microsoft.AspNetCore.Http;
using DatabaseAccess.DTOs;

namespace OracleWebAPIService_ModnaRevija.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModnaRevijaController : ControllerBase
    {
       [HttpGet]
       [Route("PreuzmiModneRevije")]
       [ProducesResponseType(StatusCodes.Status400BadRequest)]
       public IActionResult GetRevije()
        {
            try
            {
                return new JsonResult(DataProvider.vratiSveRevije());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajReviju")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddRevija([FromBody] ModnaRevijaView revija)
        {
            try
            {
                DataProvider.dodajReviju(revija);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniReviju")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeRevija([FromBody] ModnaRevijaView revija)
        {
            try
            {
                DataProvider.izmeniReviju(revija);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiReviju/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteRevija(int id)
        {
            try
            {
                DataProvider.obrisiReviju(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpGet]
        [Route("PreuzmiKreatoreRevije/{rbr}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetKreatoreRevije(int rbr)
        {
            try
            {
                return new JsonResult(DataProvider.vratiKretoreRevije(rbr));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpGet]
        [Route("PreuzmiRevijeSaVipom/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRevijeVipa(int id)
        {
            try
            {
                return new JsonResult(DataProvider.vratiSveRevijeSaVip(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpGet]
        [Route("PreuzmiReviju/{rbr}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRevija(int rbr)
        {
            try
            {
                return new JsonResult(DataProvider.vratiReviju(rbr));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
