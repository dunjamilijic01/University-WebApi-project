using DatabaseAccess.Entiteti;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccess.DTOs
{
    public class PoslujeUView
    {
        public int Id { get; set; }

        public ModnaAgencijaView Agencija { get; set; }
        public string NazivZemlje { get; set; }

        public PoslujeUView()
        {

        }

        public PoslujeUView(PoslujeU p)
        {
            Id = p.Id;
            Agencija = new ModnaAgencijaView( p.AgencijaPoslujeU);
            NazivZemlje = p.NazivZemlje;
        }
    }
}
