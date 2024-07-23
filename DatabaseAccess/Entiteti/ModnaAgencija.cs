using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Entiteti
{
    public class ModnaAgencija
    {
        public virtual int PIB { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Sediste { get; set; }
        public virtual DateTime? DatumOsnivanja { get; set; }
        public virtual string TIP { get; set; }
        public virtual IList<ProfesionalniModel> ProfesionalniModeli { get; set; }
      
        public ModnaAgencija()
        {
            ProfesionalniModeli = new List<ProfesionalniModel>();
           
        }
    }

    public class Domaca : ModnaAgencija
    {

    }
    public class Internacionalna:ModnaAgencija
    {
        public virtual IList<PoslujeU> AgencijaPoslujeU { get; set; }

        public Internacionalna()
        {
            AgencijaPoslujeU = new List<PoslujeU>();
        }
    }

}
