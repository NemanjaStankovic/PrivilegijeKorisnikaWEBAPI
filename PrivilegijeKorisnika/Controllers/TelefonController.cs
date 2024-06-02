using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess;
using PrivilegijeKorisnika;
using DatabaseAccess.DTOs;
using Privilegije_korisnika;

namespace PrivilegijeKorisnika.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelefonController:ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiBrojeveKorisnika/{jmbg}")]
        [ProducesResponseType(400)]
        public IActionResult GetTelKor(int jmbg)
        {
            try
            {
                return new JsonResult(DTOManager.vratiSveTelefoneKorisnika(jmbg));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajBrojKorisniku/{jmbg}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult DodajKorisnika(int jmbg,[FromBody] TelefonView tel)
        {
            try
            {
                DTOManager.dodajTelefon(jmbg, tel);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniBrojKorisnika")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult PromeniKorisnika([FromBody] TelefonView tel)
        {
            try
            {
                DTOManager.azurirajTelefon(tel);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }



        }

        [HttpDelete]
        [Route("ObrisiTelefon/{tel}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult ObrisiKorisnika(int tel)
        {
            try
            {
                DTOManager.obrisiTelefon(tel);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }



        }


    }

}

