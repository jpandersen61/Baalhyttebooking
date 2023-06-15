using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baalhyttebooking
{
    public class BoerneGruppe
    {
        public string ID { get; private set; } //Gruppens ID
        public string Navn { get; private set; } // Gruppens navn

        //Opgave 1
        //public string Aldersgruppe { get; private set; } //Kan antage en af streng-værdierne:”pusling”, ”tumling” , ”pilt”, ”væbner” eller  ”seniorvæbner”

        //Opgave 12
        public AldersGruppe Aldersgruppe { get; private set; } //Kan antage en af (enum) værdierne: Pusling, Tumling , Pilt, Væbner, Seniorvæbner

        public int AntalDeltagere { get; private set; } //Antallet af personer i gruppen

        //Opgave 1
        //public BoerneGruppe(string iD, string navn, string aldersgruppe, int antalDeltagere)
        //{
        //    ID = iD;
        //    Navn = navn;
        //    Aldersgruppe = aldersgruppe;
        //    AntalDeltagere = antalDeltagere;
        //}

        //Opgave 12
        public BoerneGruppe(string iD, string navn, AldersGruppe aldersgruppe, int antalDeltagere)
        {
            ID = iD;
            Navn = navn;
            Aldersgruppe = aldersgruppe;
            AntalDeltagere = antalDeltagere;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Navn: {Navn}, Aldersgruppe: {Aldersgruppe}, Antal deltagere: {AntalDeltagere}";
        }
    }
}
