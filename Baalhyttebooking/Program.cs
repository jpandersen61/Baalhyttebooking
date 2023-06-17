namespace Baalhyttebooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Opgave 1:");
            
            //Opgave 1
            //BoerneGruppe bg1 = new BoerneGruppe("Gruppe1", "Bamserne", "Pusling", 10);
            //BoerneGruppe bg2 = new BoerneGruppe("Gruppe2", "Sommerfuglene", "Tumling", 14);

            //Opgave 12
            BoerneGruppe bg1 = new BoerneGruppe("Gruppe1", "Bamserne", AldersGruppe.Pusling , 10);
            BoerneGruppe bg2 = new BoerneGruppe("Gruppe2", "Sommerfuglene", AldersGruppe.Tumling, 14);

            Console.WriteLine(bg1);
            Console.WriteLine(bg2);
            Console.WriteLine();

            Console.WriteLine("Opgave 2:");
            Reservation reservation1 = new Reservation(1, new DateTime(2023,7,20,14,0,0),bg1);
            Reservation reservation2 = new Reservation(2, new DateTime(2023,7,27,16,0,0),bg1);
            Reservation reservation3 = new Reservation(3, new DateTime(2023,7,13,12,0,0),bg2);
            Reservation reservation4 = new Reservation(4, new DateTime(2023,7,6,18,0,0),bg2);
            Console.WriteLine(reservation1);
            Console.WriteLine(reservation2);
            Console.WriteLine(reservation3);
            Console.WriteLine(reservation4);
            Console.WriteLine();

            Console.WriteLine("Opgave 6:");
            Console.WriteLine();
            Reservationer resListe = new Reservationer();

            Console.WriteLine("Registrerer 4 reservationer");
            resListe.RegisterReservation(reservation1);
            resListe.RegisterReservation(reservation2);
            resListe.RegisterReservation(reservation3);
            resListe.RegisterReservation(reservation4);
            resListe.PrintReservationer();
            Console.WriteLine();

            Console.WriteLine("Fjern 1 reservation");            
            resListe.FjernReservation(reservation3);
            resListe.PrintReservationer();
            Console.WriteLine();

            Console.WriteLine("Opgave 7:");
            Console.WriteLine();
            Console.WriteLine("Tester AntalReservationer");
            Console.WriteLine($"Antal reservationer for {bg1.Navn} : {resListe.AntalReservationer(bg1)}");
            Console.WriteLine($"Antal reservationer for {bg2.Navn} : {resListe.AntalReservationer(bg2)}");
            Console.WriteLine();

            Console.WriteLine("Tester ReservationLedig");
            Console.WriteLine($"Reservation #{reservation1.ID} ledig: {resListe.ReservationLedig(reservation1)}");
            resListe.FjernReservation(reservation3);
            Console.WriteLine($"Reservation #{reservation3.ID} ledig: {resListe.ReservationLedig(reservation3)}");
            resListe.RegisterReservation(reservation3);
            Console.WriteLine();

            Console.WriteLine("Tester ReservationsTidspunktOK");
            Console.WriteLine($"OK tidspunkt: {resListe.ReservationsTidspunktOK(new Reservation(5, new DateTime(2023, 7, 20, 16, 0, 0, 0), null))}");
            Console.WriteLine($"Forkert årstal: {resListe.ReservationsTidspunktOK(new Reservation(5, new DateTime(2022, 7, 20, 16, 0, 0, 0), null))}");
            Console.WriteLine($"Forkert ugedag: {resListe.ReservationsTidspunktOK(new Reservation(5, new DateTime(2023, 7, 21, 16, 0, 0, 0), null))}");
            Console.WriteLine($"Forkert tidspunkt på dagen: {resListe.ReservationsTidspunktOK(new Reservation(5, new DateTime(2023, 7, 20, 17, 0, 0, 0), null))}");
            Console.WriteLine($"Forkert minuttal: {resListe.ReservationsTidspunktOK(new Reservation(5, new DateTime(2023, 7, 20, 16, 1, 0, 0), null))}");
            Console.WriteLine($"Forkert sekundtal: {resListe.ReservationsTidspunktOK(new Reservation(5, new DateTime(2023, 7, 20, 16, 0, 1, 0), null))}");
            Console.WriteLine($"Forkert millisekundtal: {resListe.ReservationsTidspunktOK(new Reservation(5, new DateTime(2023, 7, 20, 16, 0, 0, 1), null))}");
            Console.WriteLine();


            //Console.WriteLine("Opgave 8:");
            //Console.WriteLine();
            //Console.WriteLine("Tester ReservationOK");
            //Console.WriteLine($"Intet Boernegruppe object tilknyttet: {resListe.ReservationOK(new Reservation(5, new DateTime(2023, 7, 20, 16, 0, 0), null))}");
            //Console.WriteLine($"Max. antal reservationer IKKE overskredet: {resListe.ReservationOK(new Reservation(5, new DateTime(2023, 7, 20, 16, 0, 0), bg1))}");
            //Console.WriteLine($"Reservation ledig: {resListe.ReservationOK(reservation3)}");


            Console.WriteLine("Opgave 9:");

            Reservation testReservation1 = new Reservation(5, new DateTime(2023, 7, 20, 16, 0, 0), null);
            Reservation testReservation2 = new Reservation(5, new DateTime(2023, 7, 20, 16, 0, 0), bg1);
            Reservation testReservation3 = new Reservation(5, new DateTime(2023, 7, 20, 16, 0, 0), bg1);

            Console.WriteLine("Tester ReservationOK");

            try
            {
                Console.WriteLine("Intet Boernegruppe object tilknyttet");
                resListe.ReservationOK(testReservation1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Max. antal reservationer overskrides");
                resListe.ReservationOK(testReservation2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Reservation er IKKE ledig");
                resListe.ReservationOK(testReservation3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();

            Console.WriteLine("Tester RegisterReservation");

            try
            {
                Console.WriteLine("Intet Boernegruppe object tilknyttet");
                resListe.RegisterReservation(testReservation1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Max. antal reservationer overskrides");
                resListe.RegisterReservation(testReservation2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine("Reservation er IKKE ledig");
                resListe.RegisterReservation(testReservation3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}