using System;
using System.Collections.Generic;
using System.Text;
using Privilegije_korisnika.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class KoriscenjeKorisnickogInterfejsaView : PrivilegijaView
    {
        //public StavkaMenijaView? Stavka { get; set; }
        //public String TipKKI { get; set; }
        public KoriscenjeKorisnickogInterfejsaView() { }
        public KoriscenjeKorisnickogInterfejsaView(KoriscenjeKorisnickogInterfejsa kki) : base(kki) 
        {
            //Stavka = new StavkaMenijaView(kki.Stavka);
            //TipKKI = kki.TipKKI;
        }
    }
}
