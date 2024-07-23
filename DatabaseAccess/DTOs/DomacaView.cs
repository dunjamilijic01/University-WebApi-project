using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class DomacaView:ModnaAgencijaView
    {
        public DomacaView()
        {
            this.Tip = "DOMACA";
        }
        public DomacaView(ModnaAgencija d):base(d)
        {
            this.Tip = "DOMACA";
        }
    }
}
