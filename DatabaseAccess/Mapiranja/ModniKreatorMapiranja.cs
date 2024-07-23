using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapiranja
{
    public class ModniKreatorMapiranja : SubclassMap<ModniKreator>
    {
        public ModniKreatorMapiranja()
        {
            Table("MODNI_KREATOR");
            KeyColumn("ID");
            Map(x => x.ZemljaPorekla, "ZEMLJA_POREKLA");
            Map(x => x.NazivModneKuce, "NAZIV_MODNE_KUCE");

            HasMany(x => x.OrganizujeReviju).KeyColumn("MODNI_KREATOR_ID").LazyLoad().Cascade.All().Inverse();
        }
    }
}
