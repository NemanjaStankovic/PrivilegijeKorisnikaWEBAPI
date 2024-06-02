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
    public class StavkaMenijaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiStavkeMenija")]
        [ProducesResponseType(400)]
        public IActionResult PreuzmiStavkeMenija()
        {
            try
            {
                return new JsonResult(DTOManager.vratiSveStavkeMenija());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        //[HttpPost]
        //[Route("DodajStavkuMenija/{kkiID}")]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(200)]
        //public IActionResult DodajStavkuMenija(int kkiID, [FromBody] StavkaMenijaView smv)
        //{
        //    try
        //    {
        //        DTOManager.dodajStavkuMenija(kkiID,smv);
        //        return Ok();

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.ToString());
        //    }
        //}

        //[HttpPut]
        //[Route("PromeniStavkuMenija")]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(200)]
        //public IActionResult PromeniKorisnika([FromBody] StavkaMenijaView smv)
        //{
        //    try
        //    {
        //        DTOManager.azurirajStavkuMenija(smv);
        //        return Ok();

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.ToString());
        //    }



        //}

        [HttpDelete]
        [Route("ObrisiStavkuMenija/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult ObrisiKorisnika(int id)
        {
            try
            {
                DTOManager.obrisiStavkuMenija(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }



        }


    }

}
