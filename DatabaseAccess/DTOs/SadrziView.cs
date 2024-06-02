using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entiteti;
using Privilegije_korisnika.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class SadrziView
    {
        public int Id { get; set; }
        public KorisnikView Kor { get; set; }
        public GrupaKorisnikaView GrKor { get; set; }

        public SadrziView() { }
        public SadrziView(Sadrzi dv)
        {
            Id = dv.ID;
            Kor = new KorisnikView(dv.Kor);
            GrKor = new GrupaKorisnikaView(dv.Grupa);
        }
    }
}
