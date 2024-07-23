using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public 
        class ModnaRevijaView
    {
        public int RbrRevije { get; set; }
        public string Naziv { get; set; }
        public string MestoOdrzavanja { get; set; }
        public DateTime? DatumVremeOdrzavanja { get; set; }
        public char? PrvaZajednickaRevija { get; set; }

        public virtual IList<PojavljujeSeNaView> VipNaReviji { get; set; }
        public virtual IList<OrganizujeView> OrganizovanaOdStrane { get; set; }
        public virtual IList<UcestvujeNaView> UcesniciRevije { get; set; }

        public ModnaRevijaView()
        {
            VipNaReviji = new List<PojavljujeSeNaView>();
            OrganizovanaOdStrane = new List<OrganizujeView>();
            UcesniciRevije = new List<UcestvujeNaView>();
        }

        public ModnaRevijaView(ModnaRevija m)
        {
            this.RbrRevije = m.RbrRevije;
            this.Naziv = m.Naziv;
            this.MestoOdrzavanja = m.MestoOdrzavanja;
            this.DatumVremeOdrzavanja = m.DatumVreme;
            this.PrvaZajednickaRevija = m.PrvaZajRevija;
        }
    }
}
