using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;

namespace forTest {
    class Program {
        static void Main() {
            //    DateTime birthday1 = new DateTime(2000, 1, 1);
            //    DateTime birthday2 = new DateTime(2002, 3, 4);
            //    DateTime birthday3 = new DateTime(2003, 3, 4);

            //    Persoon p1 = new Persoon();
            //    p1.SetNaam("jonny");
            //    p1.SetGeboortedatum(birthday1);
            //    p1.SetWoonplaats("Gent");

            //    Persoon p2 = new Persoon();
            //    p2.SetNaam("Ploky");
            //    p2.SetGeboortedatum(birthday2);
            //    p2.SetWoonplaats("Oostende");

            //    Persoon p3 = new Persoon();
            //    p3.SetNaam("lokky");
            //    p3.SetGeboortedatum(birthday3);
            //    p3.SetWoonplaats("Nevele");

            //    Persoon p4 = new Persoon();
            //    p4.SetNaam("nocky");
            //    p4.SetGeboortedatum(birthday1);
            //    p4.SetWoonplaats("Lokeren");

            //    PrintInfo(p1);
            //    PrintInfo(p2);
            //    PrintInfo(p3);
            //    PrintInfo(p4);

            //}
            //static void PrintInfo(Persoon persoon) {
            //    Console.WriteLine(persoon.GetNaam());
            //    Console.WriteLine(persoon.GetGeboortedatum());
            //    Console.WriteLine(persoon.GetWoonplaats());
            //    //Console.WriteLine(persoon.GetLeeftijd());
            //}
            /********************************************************************
             * DEEL 14.2
            rechthoek rh1 = new rechthoek();
            rh1.SetBreedte(2.8);
            rh1.SetHoogte(3.4);
            PrintRechHoek(rh1);


        }
       static void PrintRechHoek(rechthoek b) {
            Console.WriteLine($"De breedte is {b.GetBreedte()}");
            Console.WriteLine($"De hoogte is {b.GetHoogte()}");
            Console.WriteLine(value: $"De Opp is {b.Oppervlakte()}");
        }
            *////////////////////////////////////////////////////////////////////////
              //DEEL 14.3
              //    Cirkel result = new Cirkel();
              //    result.SetStraal(4.5);
              //    PrintCirkel(result);

            //}
            //static void PrintCirkel(Cirkel g) {
            //    Console.WriteLine($"De straal = {g.GetStraal()}");
            //    Console.WriteLine($"De Opp  = {g.GetOpp()}");
            //    Console.WriteLine($"De cirkel = {g.GetOmtrek()}");


            //}
            /*//////////////////////////////////////////////////////////////////////
             * DEEL 14.4
             
            Artikel art1 = new Artikel();
            art1.SetProcentBtw(21m);
            art1.SetpriceExclBtw(1000m);
            PrintBtw(art1);
        }
        static void PrintBtw(Artikel h) {
            Console.WriteLine($"De btw percent is {h.GetProcentBtw()}");
            Console.WriteLine($"De price btw excl is {h.GetpriceExclBtw()}");
            Console.WriteLine($"De  btw percent is {h.GetProcentBtw()}");
            Console.WriteLine($"De  price inclusief btw is {h.prijsIncBtw()}");

        }
            */
            /*
             * DEEL 14.05
            Counter c1 = new Counter();
            Counter c2 = new Counter();
            c2.SetWaarde(100);
            Counter c3 = new Counter();

            c3.SetWaarde(1000);
            c3.SetStap(10);
            for (int i = 0; i < 10; i++) {
                c1.Advance();
                c2.Advance();
                c3.Advance();
            }
            Console.WriteLine(c1.GetWaarde());
            Console.WriteLine(c2.GetWaarde());
            Console.WriteLine(c3.GetWaarde());
        }*/
            /*
             * DEEL 14.06
        //    Persoon[]  person = new Persoon[5];
        //    person[0] = new Persoon(); person[0].SetNaam("Bear");
        //    person[1] = new Persoon(); person[1].SetNaam("Cat");
        //    person[2] = new Persoon(); person[2].SetNaam("dog");
        //    person[3] = new Persoon(); person[3].SetNaam("horse");
        //    person[4] = new Persoon(); person[4].SetNaam("lion");

        //    Persoon winner = SelectWinner(person);
        //    Console.WriteLine($"De winaar is {winner.GetNaam()}");
        //}
        //static Persoon SelectWinner(Persoon[] candid) {
        //    Random rand = new Random();
        //    int index = rand.Next(candid.Length);
        //    return candid[index];
        //}
            */
            /*DEEL 14.7
        //    Punt p1 = new Punt();
        //    p1.SetX(4);
        //    p1.SetY(6);

        //    Punt p2 = new Punt();
        //    p2.SetX(7);
        //    p2.SetY(2);

        //    double afstand = Punt.GetAfstandTussen(p1, p2);
        //    Console.WriteLine($"De afstand is {afstand}");
        //}*/

            Bankrekening b1 = new Bankrekening();
            Bankrekening b2 = new Bankrekening();
            decimal bedrag = 100m;

            b1.SchrijfOver(bedrag, b2);

            Console.WriteLine(b1.Saldo()==-100m);
            Console.WriteLine(b2.Saldo()== 100m);
            
        }

    
    }
}