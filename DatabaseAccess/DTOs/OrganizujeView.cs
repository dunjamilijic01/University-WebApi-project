using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class OrganizujeView
    {
        public int id { set; get; }
        public KreatorView KreatorOrganizuje { get; set; }
        public ModnaRevijaView OrganizujeRevija { get; set; }
        
        public OrganizujeView()
        {

        }
        public OrganizujeView(Organizuje o)
        {
            this.id = o.Id;
            KreatorOrganizuje = new KreatorView(o.KreatorOrganizuje);
            OrganizujeRevija = new ModnaRevijaView(o.OrganizujeRevija);
        }
    }
}
