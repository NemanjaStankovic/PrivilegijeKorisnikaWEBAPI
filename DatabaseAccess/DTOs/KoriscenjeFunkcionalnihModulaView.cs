using System;
using System.Collections.Generic;
using System.Text;
using Privilegije_korisnika.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class KoriscenjeFunkcionalnihModulaView :PrivilegijaView
    {
        public KoriscenjeFunkcionalnihModulaView() { }
        public KoriscenjeFunkcionalnihModulaView(KoriscenjeFunkcionalnihModula kfm) : base(kfm) { }
    }
}
