using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class InternacionalnaView:ModnaAgencijaView
    {
        public virtual IList<PoslujeUView> AgencijaPoslujeU { get; set; }

        public InternacionalnaView()
        {
            AgencijaPoslujeU = new List<PoslujeUView>();
            this.Tip = "INTERNACIONALNA";
        }
        public InternacionalnaView(ModnaAgencija m):base(m)
        {
            this.Tip = "INTERNACIONALNA";
        }
    }
}
