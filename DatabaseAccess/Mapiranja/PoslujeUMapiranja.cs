using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapiranja
{
    public class PoslujeUMapiranja : ClassMap<PoslujeU>
    {
        public PoslujeUMapiranja()
        {
            Table("POSLUJE_U");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();
            Map(x => x.NazivZemlje, "NAZIV_ZEMLJE");
            References(x => x.AgencijaPoslujeU).Column("MODNA_AGENCIJA_PIB").LazyLoad();
           

        }
    }
}
