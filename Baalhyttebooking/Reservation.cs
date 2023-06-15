using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baalhyttebooking
{
    public class Reservation
    {
        public int ID { get; private set; }
        public DateTime Tidspunkt { get; private set; }
        public BoerneGruppe BoerneGruppe { get; private set; }

        public Reservation(int id, DateTime tidsPunkt, BoerneGruppe boerneGruppe)
        {
            ID = id;
            Tidspunkt = tidsPunkt;
            BoerneGruppe = boerneGruppe;
        }

        public override string ToString()
        {
            return $"Id: {ID}, Tidspunkt: {Tidspunkt}, Børnegruppe: {BoerneGruppe}";
        }
    }
}
