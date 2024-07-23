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
    public class PoslujeUController:ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiPoslujeU/{pib}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetNaslovneStrane(int pib)
        {
            try
            {
                return new JsonResult(DataProvider.vratiPoslujeU(pib));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajZemlju/{naziv}/{pib}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddNaslovnaStranaModelu(string naziv, int pib)
        {
            try
            {
                DataProvider.dodajZemlju(naziv,pib);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }



        [HttpDelete]
        [Route("UkloniZemlju/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteKreatorsaRevije(int id)
        {
            try
            {
                DataProvider.obrisiZemlju(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPut]
        [Route("IzmeniNazivZemlje")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeRevija([FromBody] PoslujeUView posluje)
        {
            try
            {
                DataProvider.izmeniZemlju(posluje);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
