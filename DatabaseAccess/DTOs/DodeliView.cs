using System;
using System.Collections.Generic;
using System.Text;
using Privilegije_korisnika.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class DodeliView
    {
        public int Id { get; set; }
        public GrupaKorisnikaView DodeljujeGrupi { get; set; }
        public KorisnikView DodeljujeKorisnik { get; set; }
        public PrivilegijaView DodeljujuSePrivilegija { get; set; }

        public DateTime Datum_Dodeljivanja { get; set; }

        public DodeliView() { }
        public DodeliView(Dodeli dv) {
            Id = dv.Id;
            DodeljujeGrupi = new GrupaKorisnikaView(dv.DodeljujeGrupi);
            DodeljujeKorisnik = new KorisnikView(dv.DodeljujeKorisnik);
            DodeljujuSePrivilegija = new PrivilegijaView(dv.DodeljujuSePrivilegija);
            Datum_Dodeljivanja = dv.Datum_Dodeljivanja;
        }
    }
}
