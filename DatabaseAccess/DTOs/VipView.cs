using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class VipView :OsobaView
    {
        public string Zanimanje { get; set; }
        public virtual IList<PojavljujeSeNaView> VipNaRevijama { get; set; }

        public VipView()
        {
            VipNaRevijama = new List<PojavljujeSeNaView>();
        }
        public VipView(Vip v):base(v)
        {
            this.Zanimanje = v.Zanimanje;
            
        }
    }
}
