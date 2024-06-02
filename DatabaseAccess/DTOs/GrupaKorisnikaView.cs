using System;
using System.Collections.Generic;
using System.Text;
using Privilegije_korisnika.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class GrupaKorisnikaView
    {
        public string JedinstvenoIme { get; set; }
        public string KratakOpis { get; set; }
        public DateTime PeriodPocetka { get; set; }
        public DateTime PeriodZavrsetka { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public IList<KorisnikView> Korisnici { get; set; }
        public IList<IP_AdresaView> IpAdrese { get; set; }
        public IList<DodeliView> DodeljujeSeG { get; set; }
        public GrupaKorisnikaView()
        {
            Korisnici = new List<KorisnikView>();
            IpAdrese = new List<IP_AdresaView>();
            DodeljujeSeG = new List<DodeliView>();

        }
        public GrupaKorisnikaView(GrupaKorisnika gk)
        {
            JedinstvenoIme = gk.JedinstvenoIme;
            KratakOpis = gk.KratakOpis;
            PeriodPocetka = gk.PeriodPocetka;
            PeriodZavrsetka = gk.PeriodZavrsetka;
            DatumKreiranja = gk.DatumKreiranja;
            //DodeljujeSeG = new DodeliView(gk.DodeljujeSeG);
        }
    }
}
