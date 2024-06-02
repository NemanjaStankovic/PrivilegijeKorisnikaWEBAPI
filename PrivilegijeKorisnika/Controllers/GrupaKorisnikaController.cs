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
    public class GrupaKorisnikaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiGrupeKorisnika")]
        [ProducesResponseType(400)]
        public IActionResult GetGrupeKorisnika()
        {
            try
            {
                return new JsonResult(DTOManager.vratiSveGrupeKorisnike());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiKorisnikeGrupe/{grupa}")]
        [ProducesResponseType(400)]
        public IActionResult GetKorisniciGrupe(string grupa)
        {
            try
            {
                return new JsonResult(DTOManager.vratiKorisnikeGrupe(grupa));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajGrupuKorisnika")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult DodajKorisnika([FromBody] GrupaKorisnikaView gkor)
        {
            try
            {
                DTOManager.dodajGrupu(gkor);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajKorisnikaUGrupu/{jmbg}/{grupa}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult DodajKorisnikaUGrupu(int jmbg, string grupa)
        {
            try
            {
                DTOManager.dodajKorisnikaUGrupu(jmbg, grupa);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniGrupuKorisnika")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult PromeniGrupu([FromBody] GrupaKorisnikaView gkor)
        {
            try
            {
                DTOManager.azurirajGrupuKorisnika(gkor);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }



        }

        [HttpDelete]
        [Route("ObrisiGrupu/{jedIme}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult ObrisiGrupu(string jedIme)
        {
            try
            {
                DTOManager.obrisiGrupuKorisnika(jedIme);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }



        }


    }
}
