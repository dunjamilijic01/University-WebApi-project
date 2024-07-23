using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;


namespace OracleWebAPIService_ModnaRevija.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModnaAgencijaController : ControllerBase
    {
            [HttpGet]
            [Route("PreuzmiModneAgencije")]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public IActionResult GetAgencije()
            {
                try
                {
                    return new JsonResult(DataProvider.vratiSveAgencije());
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.ToString());
                }
            }
        [HttpGet]
        [Route("PreuzmiModnuAgenciju/{pib}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAgencija(int pib)
        {
            try
            {
                return new JsonResult(DataProvider.vratiModnuAgenciju(pib));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
            [Route("DodajAgenciju")]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public IActionResult AddRevija([FromBody] ModnaAgencijaView agencija)
            {
                try
                {
                    DataProvider.dodajModnuAgenciju(agencija);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.ToString());
                }
            }

            [HttpPut]
            [Route("PromeniAgenciju")]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public IActionResult ChangeRevija([FromBody] ModnaAgencijaView agencija)
            {
                try
                {
                    DataProvider.izmeniModnuAgenciju(agencija);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.ToString());
                }
            }

            [HttpDelete]
            [Route("IzbrisiAgenciju/{pib}")]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public IActionResult DeleteAgencija(int pib)
            {
                try
                {
                    DataProvider.obrisiAgenciju(pib);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.ToString());
                }
            }
        [HttpGet]
        [Route("PreuzmiAktivneZemlje/{pib}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAktivneZemlje(int pib)
        {
            try
            {
                return new JsonResult(DataProvider.vratiAktivneZemlje(pib));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPost]
        [Route("DodajDomacu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddDomaca([FromBody] DomacaView agencija)
        {
            try
            {
                DataProvider.dodajDomacu(agencija);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPost]
        [Route("DodajIntenacinalnu")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddInternacinalna([FromBody] InternacionalnaView agencija)
        {
            try
            {
                DataProvider.dodajInternacinalnu(agencija);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
    }
