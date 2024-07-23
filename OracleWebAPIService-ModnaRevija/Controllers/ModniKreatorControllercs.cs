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
    public class ModniKreatorControllercs:ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiModneKreatore")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetKreatori()
        {
            try
            {
                return new JsonResult(DataProvider.vratiSveKreatore());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajKreatora")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddKreator([FromBody] KreatorView kreator)
        {
            try
            {
                DataProvider.dodajKreatora(kreator);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPut]
        [Route("PromeniKreatora")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeKreator([FromBody] KreatorView kreator)
        {
            try
            {
                DataProvider.izmeniKreatora(kreator);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiKrearora/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteKreator(int id)
        {
            try
            {
                DataProvider.obrisiKreatora(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
