using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.Mapiranja
{
    class SadrziMapiranja : ClassMap<Sadrzi>
    {
        public SadrziMapiranja()
        {
            Table("SADRZI");

            Id(x => x.ID, "ID").GeneratedBy.TriggerIdentity();

            References(x => x.Grupa, "JEDINSTVENO_IME").Unique();

            References(x => x.Kor, "JMBG").Unique();

        }
    }
}
