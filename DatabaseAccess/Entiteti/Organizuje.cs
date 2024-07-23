using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class Organizuje
    {
        public virtual int Id { get; set; }

        public virtual ModniKreator KreatorOrganizuje { get; set; }
        public virtual ModnaRevija OrganizujeRevija { get; set; }

    }
}
