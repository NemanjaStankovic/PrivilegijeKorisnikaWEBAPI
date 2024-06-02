using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess;
using PrivilegijeKorisnika;
using DatabaseAccess.DTOs;

namespace Privilegije_korisnika
{
    [ApiController]
    [Route("[controller]")]
    public class IPAdresaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiIPAdreseGrupe/{grupa}")]
        [ProducesResponseType(400)]
        public IActionResult GetIPGrupe(string grupa)
        {
            try
            {
                return new JsonResult(DTOManager.vratiSveAdreseGrupe(grupa));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajAdresu")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult DodajAdresu([FromBody] IP_AdresaView pv)
        {
            try
            {
                DTOManager.dodajAdresu(pv);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodeliAdresuGrupi/{grupa}/{adresa}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult DodeliAdresuGrupi(string grupa, int adresa)
        {
            try
            {
                DTOManager.dodeliAdresuGrupi(grupa, adresa);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniAdresuKorisnika/{jmbg}/{adresa}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult PromeniAdresu(int jmbg, int adresa)
        {
            try
            {
                DTOManager.promeniAdresuKorisnika(jmbg, adresa);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }



        }

        [HttpPut]
        [Route("PromeniAdresu")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult PromeniAdresu([FromBody] IP_AdresaView pv)
        {
            try
            {
                DTOManager.azurirajAdresu(pv);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }



        }

        [HttpDelete]
        [Route("ObrisiAdresu/{adresa}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult ObrisiProfil(int adresa)
        {
            try
            {
                DTOManager.obrisiAdresu(adresa);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }



        }


    }
}
