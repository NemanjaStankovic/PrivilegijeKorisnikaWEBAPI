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
    public class KorisnikController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiKorisnike")]
        [ProducesResponseType(400)]
        public IActionResult GetKorisnici()
        {
            try
            {
                return new JsonResult(DTOManager.vratiSveKorisnike());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajKorisnika")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult DodajKorisnika([FromBody]KorisnikView korisnik) 
        {
            try
            {
                DTOManager.dodajKorisnika(korisnik);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajKorisnika/{adresa}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult DodajKorisnika([FromRoute(Name="adresa")]int adresa,[FromBody] KorisnikView korisnik)
        {
            try
            {
                var ip = DTOManager.vratiAdresu(adresa);
                korisnik.Adresa = ip;
                DTOManager.dodajKorisnika(korisnik);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniKorisnika")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult PromeniKorisnika([FromBody] KorisnikView korisnik)
        {
            try
            {
                DTOManager.azurirajKorisnika(korisnik);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }



        }

        [HttpDelete]
        [Route("ObrisiKorisnika/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult ObrisiKorisnika([FromRoute(Name="id")]int id)
        {
            try
            {
                DTOManager.obrisiKorisnika(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }



        }


    }
}
