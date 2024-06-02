using Privilegije_korisnika.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class PrivilegijaView
    {
        public int Id { get; set; }
        public String Ime { get; set; }
        public String Tip { get; set; }
        public IList<DodeliView> DodeljujeP { get; set; }
        public PrivilegijaView()
        {
            DodeljujeP = new List<DodeliView>();
        }
        public PrivilegijaView(Privilegija dodeljujuSePrivilegija)
        {
            Id = dodeljujuSePrivilegija.Id;
            Ime = dodeljujuSePrivilegija.Ime;
            Tip = dodeljujuSePrivilegija.Tip;
        }
    }
}
