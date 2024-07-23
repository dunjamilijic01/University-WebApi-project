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
    public class UcestvujeNaController:ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiSveUcesnikeRevije/{rbr}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetUcesnikeRevije(int rbr)
        {
            try
            {
                return new JsonResult(DataProvider.vratiSveUcesnikeRevije(rbr));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("IzbrisiUcesnikaRevije/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteUcesnika(int id)
        {
            try
            {
                DataProvider.obrisiUcesnikaRevije(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPut]
        [Route("PromeniUcestvujeNa/{id}/{rbr}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeUcestvujeNa(int id,int rbr)
        {
            try
            {
                DataProvider.izmeniUcestvujeNaReviji(id,rbr);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPost]
        [Route("DodajUcesnikaRevije/{id}/{rbr}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddUcesnikRevije(int id, int rbr)
        {
            try
            {
                DataProvider.dodajUcesnikaReviji(id,rbr);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
