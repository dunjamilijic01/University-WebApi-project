using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class PojavljujeSeNaView
    {
        public  int Id { get; set; }

        public  VipView VipPojavljujeSeNa { get; set; }
        public  ModnaRevijaView PojavljujuSeNaRevija { get; set; }

        public PojavljujeSeNaView()
        {

        }
        public PojavljujeSeNaView(PojavljujeSeNa p)
        {
            Id = p.Id;
            VipPojavljujeSeNa = new VipView(p.VipPojavljujeSeNa);
            PojavljujuSeNaRevija = new ModnaRevijaView(p.PojavljujuSeNaRevija);

        }
    }
}
