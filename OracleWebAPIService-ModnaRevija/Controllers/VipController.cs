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
    public class VipController : ControllerBase
    {

        [HttpPost]
        [Route("DodajVipModela/{rbr}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddRevija([FromBody] VipView vip,int rbr)
        {
            try
            {
                DataProvider.dodajVipModela(vip,rbr);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiVip/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetVip(int id)
        {
            try
            {
                return new JsonResult(DataProvider.vratiVip(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPut]
        [Route("PromeniVip")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ChangeVip([FromBody] VipView vip)
        {
            try
            {
                DataProvider.IzmeniVipNaReviji(vip);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("IzbrisiVip/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteVip(int id)
        {
            try
            {
                DataProvider.obrisiVip(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
