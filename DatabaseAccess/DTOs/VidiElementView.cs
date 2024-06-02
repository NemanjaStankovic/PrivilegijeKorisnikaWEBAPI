using System;
using System.Collections.Generic;
using System.Text;
using Privilegije_korisnika.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class VidiElementView :KoriscenjeKorisnickogInterfejsaView
    {
        public VidiElementView() { }
        public VidiElementView(VidiElement v):base(v) { }
    }
}
