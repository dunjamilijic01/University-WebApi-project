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
    public class ProfesionalniModelController:ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiProfesionalnogModela/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetModela(int id)
        {
            try
            {
                return new JsonResult(DataProvider.vratiManekena(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajProfesionalnogModelaReviji/{rbr}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddProfesinalniModelNaReviji([FromBody] ProfesionalniModelView model, int rbr)
        {
            try
            {
                DataProvider.dodajProfModela(model, rbr);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajProfesionalnogModela")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddProfesinalniModel([FromBody] ProfesionalniModelView model)
        {
            try
            {
                DataProvider.dodajProfModela(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("UkloniProfesionalnogModela/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteProfesionalnogModela(int id)
        {
            try
            {
                DataProvider.obrisiManekena(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPut]
        [Route("IzmeniProfesionalnogModela")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeRevija([FromBody] ProfesionalniModelView model)
        {
            try
            {
                DataProvider.azurirajProfesionalnogModela(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
