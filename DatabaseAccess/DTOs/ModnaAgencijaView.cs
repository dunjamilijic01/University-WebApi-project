using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class ModnaAgencijaView
    {
        public int PIB { get; set; }
        public string Naziv { get; set; }
        public string Sediste { get; set; }
        public DateTime? DatumOsnivanja { get; set; }
        public string Tip { get; set; }
        public virtual IList<ProfesionalniModelView> ProfesionalniModeli { get; set; }

        public ModnaAgencijaView()
        {
            ProfesionalniModeli = new List<ProfesionalniModelView>();
        }
        public ModnaAgencijaView(ModnaAgencija a)
        {
            this.PIB = a.PIB;
            this.Naziv = a.Naziv;
            this.Sediste = a.Sediste;
            this.DatumOsnivanja = a.DatumOsnivanja;
            //this.Tip = a.TIP;
        }
    }
}
