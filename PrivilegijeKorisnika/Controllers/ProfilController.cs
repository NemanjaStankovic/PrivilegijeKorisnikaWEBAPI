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
    public class ProfilController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiProfileKorisnika/{jmbg}")]
        [ProducesResponseType(400)]
        public IActionResult GetProfiliKorisnika(int jmbg)
        {
            try
            {
                return new JsonResult(DTOManager.vratiProfile(jmbg));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajProfil/{jmbg}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult DodajKorisnika(int jmbg, [FromBody] ProfilView pv)
        {
            try
            {
                DTOManager.dodajProfil(jmbg, pv);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniProfil")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult PromeniProfil([FromBody] ProfilView pv)
        {
            try
            {
                DTOManager.azurirajProfil(pv);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }



        }

        [HttpDelete]
        [Route("ObrisiProfil/{redbr}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult ObrisiProfil(int redbr)
        {
            try
            {
                DTOManager.obrisiProfil(redbr);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }



        }


    }
}
