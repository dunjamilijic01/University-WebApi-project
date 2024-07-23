using System;
using System.Collections.Generic;
using System.Text;
using DatabaseAccess.Entiteti;

namespace DatabaseAccess.DTOs
{
    public class UcestvujeNaView
    {
        public  int Id { get; set; }

        public  OsobaView OsobaUcestvujeNa { get; set; }
        public  ModnaRevijaView UcestvujeNaRevija { get; set; }
        public char SpecijalniGost { get; set; }

        public UcestvujeNaView()
        {

        }

        public UcestvujeNaView(UcestvujeNa u)
        {
            Id = u.Id;
            OsobaUcestvujeNa = new OsobaView( u.OsobaUcestvujeNa);
            UcestvujeNaRevija = new ModnaRevijaView( u.UcestvujeNaRevija);
            SpecijalniGost = u.SpecijalniGost;
        }

    }
}
