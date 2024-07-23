using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class NaslovnaStranaView
    {
        public int Id { get; set; }

        public ProfesionalniModelView Model { get; set; }

        public string NazivCasopisa { get; set; }

        public NaslovnaStranaView()
        {

        }
        public NaslovnaStranaView(NaslovnaStrana n)
        {
            Id = n.Id;
            Model = new ProfesionalniModelView(n.ModelNaNaslovnojStrani);
            NazivCasopisa = n.NazivCasopisa;
        }
    }
}
