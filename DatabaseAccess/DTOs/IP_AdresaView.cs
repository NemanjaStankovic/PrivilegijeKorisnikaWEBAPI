using Privilegije_korisnika.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class IP_AdresaView
    {
        public int Adresa { get; set; }
        public GrupaKorisnikaView ImaGrupuKorisnika { get; set; }


        public KorisnikView ImaKorisnika { get; set; }

        public IP_AdresaView()
        {
        }
        public IP_AdresaView(IP_Adresa adresa)
        {
            Adresa = adresa.Adresa;
            //ImaGrupuKorisnika = new GrupaKorisnikaView(adresa.ImaGrupuKorisnika);
            //ImaKorisnika = new KorisnikView(adresa.ImaKorisnika);
        }
    }
}
