using FluentNHibernate.Mapping;
using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Mapiranja
{
    public class ModnaRevijaMapiranja :ClassMap<ModnaRevija>
    {
        public ModnaRevijaMapiranja()
        {
            Table("MODNA_REVIJA");

            Id(x => x.RbrRevije, "RBR_REVIJE").GeneratedBy.Assigned();

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.MestoOdrzavanja, "MESTO_ODRZAVANJA");
            Map(x => x.DatumVreme, "DATUM_I_VREME");
            Map(x => x.PrvaZajRevija, "PRVA_ZAJEDNICKA_REVIJA");

            HasMany(x => x.OrganizovanaOdStrane).KeyColumn("REVIJA_RBR").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.VipNaReviji).KeyColumn("REVIJA_RBR").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.UcesniciRevije).KeyColumn("REVIJA_RBR").LazyLoad().Cascade.All().Inverse();
        }
    }
}
