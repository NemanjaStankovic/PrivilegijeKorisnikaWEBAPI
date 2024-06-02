using DatabaseAccess.Entiteti;
using Privilegije_korisnika.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class SpisakElemenataGrafickogInterfejsaView
    {
        public KorisnikView Vlasnik { get; set; }
        public ProfilView Profil { get; set; }
        public string ElGrafInt { get; set; }

        public SpisakElemenataGrafickogInterfejsaView()
        {

        }
        public SpisakElemenataGrafickogInterfejsaView(SpisakElemenataGrafickogInterfejsa p)
        {
            Vlasnik = new KorisnikView(p.Vlasnik);
            Profil = new ProfilView(p.Profil);
            ElGrafInt = p.ElGrafInt;
        }
    }
}
