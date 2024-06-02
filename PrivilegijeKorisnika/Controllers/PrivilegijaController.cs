using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Mvc;
using Privilegije_korisnika;
using System;

namespace PrivilegijeKorisnika.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrivilegijaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiAdministrativne/{grupa}")]
        [ProducesResponseType(400)]
        public IActionResult GetAdministrativne(string grupa)
        {
            try
            {
                return new JsonResult(DTOManager.vratiAdms(grupa));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajADM/{korisnik}/{grupa}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult DodajAdministrativnu(int korisnik, string grupa,[FromBody] AdministrativneView adm)
        {
            try
            {
                var id = DTOManager.dodajAdm(adm);
                var a = DTOManager.vratiAdm(id);
                var k = DTOManager.vratiKorisnika(korisnik);
                var g = DTOManager.vratiGrupuKorisnika(grupa);
                var dodeli = new DodeliView { DodeljujeGrupi = g, DodeljujeKorisnik = k, DodeljujuSePrivilegija = a };
                DTOManager.dodajDodeliAdm(dodeli);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }



        }

        [HttpGet]
        [Route("PreuzmiKFM/{grupa}")]
        [ProducesResponseType(400)]
        public IActionResult GetFunkMod(string grupa)
        {
            try
            {
                return new JsonResult(DTOManager.vratiKFMGrupe(grupa));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajKFM")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult DodajFunkMod([FromBody] KoriscenjeFunkcionalnihModulaView kfm)
        {
            try
            {
                DTOManager.dodajKFM(kfm);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }



        }

        [HttpPost]
        [Route("DodajKFMUGrupu/{korisnik}/{grupa}/{kfmu}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult DodajKFMUGrupu(int korisnik, string grupa, int kfmu)
        {
            try
            {
                var k = DTOManager.vratiKFM(kfmu);
                var g = DTOManager.vratiGrupuKorisnika(grupa);
                var kor = DTOManager.vratiKorisnika(korisnik);
                var dodeli = new DodeliView { DodeljujeGrupi = g, DodeljujeKorisnik = kor, DodeljujuSePrivilegija = k };
                DTOManager.dodajDodeliKFM(dodeli);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }



        }

        [HttpGet]
        [Route("PreuzmiKKI/{id}")]
        [ProducesResponseType(400)]
        public IActionResult GetKKI(int id)
        {
            try
            {
                return new JsonResult(DTOManager.vratiKKI(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajKKI/{korisnik}/{grupa}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult DodajKKI(int korisnik, string grupa, [FromBody] VidiElementView adm)//bilo kkiview
        {
            try
            {
                var id=DTOManager.dodajKKI(adm);
                var a = DTOManager.vratiKKIJ(id);
                var k = DTOManager.vratiKorisnika(korisnik);
                var g = DTOManager.vratiGrupuKorisnika(grupa);
                var dodeli = new DodeliView { DodeljujeGrupi = g, DodeljujeKorisnik = k, DodeljujuSePrivilegija = a };
                DTOManager.dodajDodeliAdm(dodeli);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }



        }
    }
}
