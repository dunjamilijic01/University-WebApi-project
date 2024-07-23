using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class OsobaView
    {
        public int Id { get; set; }
        public string Mbr { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime? DatRodjenja { get; set; }
        public char Pol { get; set; }
        public IList<UcestvujeNaView> UcestvujeNaReviji { get; set; }

        public OsobaView()
        {
            UcestvujeNaReviji = new List<UcestvujeNaView>();
        }

        public OsobaView(Osoba o)
        {
            Id = o.Id;
            Mbr = o.Mbr;
            Ime = o.Ime;
            Prezime = o.Prezime;
            DatRodjenja = o.DatRodjenja;
            Pol = o.Pol;
        }
    }
}
