using DatabaseAccess.Entiteti;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.Mapiranja
{
    class SpisakElemenataGrafickogInterfejsaMapiranje : ClassMap<SpisakElemenataGrafickogInterfejsa>
    {
        public SpisakElemenataGrafickogInterfejsaMapiranje()
        {
            Table("SPISAK_EL_GRAF_INT");

            Map(x => x.ElGrafInt, "SPISAK_EL_GRAF_INT");

            Map(x => x.Profil, "REDNI_BROJ");

            Map(x => x.Vlasnik, "JMBG");

        }
    }
}
