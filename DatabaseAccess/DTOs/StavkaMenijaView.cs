using Privilegije_korisnika.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class StavkaMenijaView //:KoriscenjeKorisnickogInterfejsaView
    {
        public int? SM_FK { get; set; }
        public StavkaMenijaView Roditelj { get; set; }
        public  IList<StavkaMenijaView> Deca { get; set; }
        public StavkaMenijaView()
        {
            Deca = new List<StavkaMenijaView>();
        }
        public StavkaMenijaView(StavkaMenija? sm)
        {
            SM_FK = sm.SM_FK;
            //Roditelj = new StavkaMenijaView(sm.Roditelj);
        }
    }
}
