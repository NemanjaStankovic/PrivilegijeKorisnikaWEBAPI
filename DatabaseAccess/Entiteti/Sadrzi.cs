using Privilegije_korisnika.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.Entiteti
{
    public class Sadrzi
    {
        public virtual int ID { get; set; }
        public virtual Korisnik Kor { get; set; }
        public virtual GrupaKorisnika Grupa { get; set; }
        public Sadrzi() { }
    }
}
