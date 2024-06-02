using Privilegije_korisnika.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class TelefonView
    {
        public KorisnikView Vlasnik { get; set; }
        public int BrojTelefona { get; set; }
        public int ID { get; set; }
        public TelefonView()
        {
            
        }
        public TelefonView(Telefon t)
        {
            Vlasnik = new KorisnikView(t.Vlasnik);
            BrojTelefona = t.BrojTelefona;
            ID = t.ID;
        }
    }
}
