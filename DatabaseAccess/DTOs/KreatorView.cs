using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class KreatorView : OsobaView
    {

        public string zemljaPorekla { get; set; }
        public string nazivKuce { get; set; }

        public KreatorView()
        {

        }
        public KreatorView(ModniKreator m):base(m)
        {
            this.zemljaPorekla = m.ZemljaPorekla;
            this.nazivKuce = m.NazivModneKuce;
        }


    }
}
