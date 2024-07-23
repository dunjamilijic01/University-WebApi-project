using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapiranja
{
    public class OrganizujeMapiranja :ClassMap<Organizuje>
    {
        public OrganizujeMapiranja()
        {
            Table("ORGANIZUJE");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            References(x => x.KreatorOrganizuje).Column("MODNI_KREATOR_ID").LazyLoad() ;
            References(x => x.OrganizujeRevija).Column("REVIJA_RBR").LazyLoad();
        }

    }
}
