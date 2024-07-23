using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class ProfesionalniModelView :OsobaView
    {
        public double Visina { get; set; }
        public double Tezine { get; set; }
        public string BojaOciju { get; set; }
        public string BojaKose { get; set; }
        public string KonfBroj { get; set; }
        public ModnaAgencijaView Agencija { get; set; }
        public virtual IList<NaslovnaStranaView> NaslovneStrane { get; set; }

        public ProfesionalniModelView()
        {
            NaslovneStrane = new List<NaslovnaStranaView>();
        }

        public ProfesionalniModelView(ProfesionalniModel p):base(p)
        {
            this.Visina = p.Visina;
            this.Tezine = p.Tezina;
            this.BojaKose = p.BojaKose;
            this.BojaOciju = p.BojaOciju;
            this.KonfBroj = p.KonfekcijskiBroj;
            this.Agencija = new ModnaAgencijaView( p.Agencija);
        }
    }
}
