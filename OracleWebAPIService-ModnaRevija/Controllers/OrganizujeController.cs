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
    public class OrganizujeController: ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiRevijeKojeOrganizujeKreator/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRevijeKojeOrganizuje(int id)
        {
            try
            {
                return new JsonResult(DataProvider.vratiSveRevijeKreatora(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajPostojecegKreatoraReviji/{id}/{rbr}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddNaslovnaStranaModelu(int id,int rbr)
        {
            try
            {
                DataProvider.dodajPostojecegKreatora(DataProvider.vratiKreatora(id),DataProvider.vratiReviju(rbr));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniRevijuKojuOrganizujeKreator")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeRevija([FromBody] OrganizujeView org)
        {
            try
            {
                DataProvider.izmeniOrganizuje(org);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("UkloniKreatoraSaRevije/{id}/{rbr}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteKreatorsaRevije(int id,int rbr)
        {
            try
            {
                DataProvider.ukloniKreatoraSaRevije(id,rbr);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
