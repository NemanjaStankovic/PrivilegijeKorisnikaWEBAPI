using Privilegije_korisnika.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class AdministrativneView : PrivilegijaView
    {
        public AdministrativneView() : base() { }
        public AdministrativneView(Privilegija a) : base(a) { }
    }
}
