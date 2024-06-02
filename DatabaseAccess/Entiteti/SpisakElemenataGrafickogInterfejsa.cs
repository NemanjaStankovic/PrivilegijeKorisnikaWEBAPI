using Privilegije_korisnika.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.Entiteti
{
    public class SpisakElemenataGrafickogInterfejsa
    {
        public virtual Korisnik Vlasnik { get; set; }
        public virtual Profil Profil { get; set; }
        public virtual string ElGrafInt { get; set; }
    }
}
