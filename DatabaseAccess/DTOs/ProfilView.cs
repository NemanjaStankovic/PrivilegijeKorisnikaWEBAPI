using System;
using System.Collections.Generic;
using System.Text;
using Privilegije_korisnika.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class ProfilView
    {
        public int Redni_broj { get; set; }
        public String Boja_pozadine { get; set; }
        public KorisnikView KorisnikJMBG { get; set; }


        public ProfilView() 
        {
        }
        public ProfilView(Profil p)
        {
            Redni_broj = p.Redni_broj;
            Boja_pozadine = p.Boja_pozadine;
            KorisnikJMBG = new KorisnikView(p.KorisnikJMBG);
            
        }
    }
}
