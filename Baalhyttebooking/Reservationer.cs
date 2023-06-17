using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baalhyttebooking
{
    public class Reservationer
    {
        Dictionary<int,Reservation> _reservationer;

        List<int> lovligeTidspunkter = new List<int>() {12,14,16,18,20};

        public int ID { get; private set; }
        public Reservationer(int id)
        {
            _reservationer = new Dictionary<int,Reservation>();
            ID = id;    
        }
       
        public Reservationer()
        {
            _reservationer = new Dictionary<int,Reservation>();
            ID = DateTime.Now.Year;
        }

        public void RegisterReservation(Reservation reservation)
        {
            ReservationOK(reservation);

            if (!_reservationer.ContainsKey(reservation.ID))
            {
                _reservationer.Add(reservation.ID, reservation);
            }
        }

        public void PrintReservationer()
        {
            foreach (Reservation reservation in _reservationer.Values)
            {
                Console.WriteLine(reservation);
            }            
        }

        public void FjernReservation(Reservation reservation)
        {
            if (_reservationer.ContainsKey(reservation.ID))
            {
                _reservationer.Remove(reservation.ID);
            }
        }

        public int AntalReservationer(BoerneGruppe bGruppe)
        {
            int result = 0;

            foreach (Reservation res in _reservationer.Values)
            {
                if (res.BoerneGruppe.ID == bGruppe.ID)
                {
                    result++;
                }
            }

            return result;
        }

        public bool ReservationLedig(Reservation reservation)
        {
            foreach (Reservation res in _reservationer.Values)
            {
                if (res.Tidspunkt == reservation.Tidspunkt)
                {
                    return false;
                }
            }
            return true;
        }

        public bool ReservationsTidspunktOK(Reservation reservation)
        {
            if (reservation.Tidspunkt.Year != ID)
            {
                return false;
            }

            if (reservation.Tidspunkt.DayOfWeek != DayOfWeek.Thursday)
            {
                return false;
            }

            if (!lovligeTidspunkter.Contains(reservation.Tidspunkt.Hour))
            {
                return false;
            }

            if (   reservation.Tidspunkt.Minute != 0
                || reservation.Tidspunkt.Second != 0
                || reservation.Tidspunkt.Millisecond != 0)
            {
                return false;
            }

            return true;
        }

        public bool ReservationOK(Reservation reservation)
        {
            string message = "";
            
            if (reservation.BoerneGruppe == null)
            {
                message = "Reservation IKKE mulig: Boernegruppe object er null"; 
                
                //Opgave 8:
                //Console.WriteLine(message);
                //return false;

                //Opgave 9:
                throw new Exception(message);
            }

            if(AntalReservationer(reservation.BoerneGruppe) >= 2)
            {
                message = "Reservation IKKE mulig: Max. antal allerede nået";

                //Opgave 8:
                //Console.WriteLine(message);
                //return false;

                //Opgave 9:
                throw new Exception(message);
            }

            if (!ReservationLedig(reservation) )
            {
                message = "Reservation IKKE mulig: Er allerede reserveret";

                //Opgave 8:
                //Console.WriteLine(message);
                //return false;

                //Opgave 9:
                throw new Exception(message);
            }

            if (!ReservationsTidspunktOK(reservation))
            {
                message = "Reservation IKKE mulig: Ugyldigt tidspunkt";

                //Opgave 8:
                //Console.WriteLine(message);
                //return false;

                //Opgave 9:
                throw new Exception(message);
            }

            return true;
        }
    }
}
