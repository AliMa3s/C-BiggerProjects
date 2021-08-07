using System;
using static System.Console;

namespace TestingOef {
    class Program {
        static void ToonTitel(string title) {
            WriteLine(title);
            string lijntje = new string('-', title.Length);
            WriteLine(lijntje);
        }
        static string VraagStringAntwoord(string vraag) {
            string result;
            Write($"{vraag}");
            result = ReadLine().Trim();
            return result;
        }
        static string VraagNietLeegStringAntwoord(string vraag) {
            string result;
            do {
                result = VraagStringAntwoord(vraag);
            } while (result.Length == 0);
            return result;
        }

        static string VraagKeuzeMetCase(string vraag, string[] keuzes, bool isCaseInsensitive) {
            string result;
            string[] keuzesOmTeChecken;
            if (isCaseInsensitive) {
                keuzesOmTeChecken = new string[keuzes.Length];
                for (int i = 0; i < keuzes.Length; i++) {
                    keuzesOmTeChecken[i] = keuzes[i].ToLower();
                }
            } else {
                keuzesOmTeChecken = keuzes;
            }
            int index;
            do {
                string keuzesTekst = string.Join('/', keuzes);
                Write($"{vraag} ({keuzesTekst}) : ");
                string antwoord = ReadLine().Trim();
                if (isCaseInsensitive) {
                    antwoord = antwoord.ToLower();
                }
                index = Array.IndexOf(keuzesOmTeChecken, antwoord);
            } while (index == -1);
            result = keuzes[index];
            return result;
        }

        static string VraagKeuze(string vraag, string[] keuzes) {
            string result = VraagKeuzeMetCase(vraag, keuzes, true);
            return result;
        }

        static int VraagIntAntwoord(string vraag, int min, int max) {
            int result;
            bool isCorrectAntwoord;
            do {
                Console.Write($"{vraag} : ");
                string getalAlsTekst = Console.ReadLine().Trim();
                if (getalAlsTekst.Length > 0) {
                    // gebruiker heeft iets ingetypt, is het een getal in [min, max]?
                    bool isGeldig = int.TryParse(getalAlsTekst, out result);
                    isCorrectAntwoord = isGeldig && (result >= min && result <= max);
                } else {
                    // gebruiker heeft een lege string ingevoerd
                    isCorrectAntwoord = true;
                    result = int.MinValue; // we gebruiken deze waarde om aan te geven dat er niks werd ingevoerd
                }
            } while (!isCorrectAntwoord);

            return result;
        }

        static int VraagNietLeegIntAntwoord(string vraag, int min, int max) {
            int result;
            do {
                result = VraagIntAntwoord(vraag, min, max);
            } while (result == int.MinValue);

            return result;
        }

        static void ToonPersoonDetails(int index, string[] voornamen, string[] familienamen, bool[] isVrouwen, string[] postcodes, string[] gemeenten, int[] aantalKinderen) {
            Console.WriteLine("voornaam    : " + voornamen[index]);
            Console.WriteLine("familienaam : " + familienamen[index]);
            Console.WriteLine("geslacht    : " + (isVrouwen[index] ? "vrouw" : "man"));
            Console.WriteLine("postcode    : " + postcodes[index]);
            Console.WriteLine("gemeente    : " + gemeenten[index]);
            Console.WriteLine("kinderen    : " + aantalKinderen[index]);
        }

        static void Main(string[] args) {

            string[] geslachtKeuzes = { "m", "v" };
            string[] geslachtLeegKeuzes = { "m", "v", "" };
            string[] jaNeeKeuzes = { "j", "n" };

            const int maxPersonen = 20;

            const int keuzeVoegToe = 1;
            const int keuzeVerwijder = 2;
            const int keuzeBewerk = 3;
            const int keuzeToon = 4;
            const int keuzeStop = 5;

            string[] voornamen = new string[maxPersonen];
            string[] familienamen = new string[maxPersonen];
            bool[] isVrouwen= new bool[maxPersonen];
            string[] postcodes = new string[maxPersonen];
            string[] gemeente = new string[maxPersonen];
            int[] aantalKinderen = new int[maxPersonen];
            int aantalPersonen = 0;

            voornamen[aantalPersonen] = "Jen";
            familienamen[aantalPersonen] = "Jogern";
            isVrouwen[aantalPersonen] = false;
            postcodes[aantalPersonen] = "9000";
            gemeente[aantalPersonen] = "Gent";
            aantalKinderen[aantalPersonen] = 0;
            aantalPersonen++;
            
            voornamen[aantalPersonen] = "Mieke";
            familienamen[aantalPersonen] = "Mickelsen";
            isVrouwen[aantalPersonen] = true;
            postcodes[aantalPersonen] = "3500";
            gemeente[aantalPersonen] = "Hasselt";
            aantalKinderen[aantalPersonen] = 2;
            aantalPersonen++;

            int keuze = 0;
            bool isCorrectAntwoord;
            do {
                Clear();
                ToonTitel("Gekende personen");
                for (int i = 0; i < aantalPersonen; i++) {
                    WriteLine($"{i,2} {voornamen[i]} {familienamen[i]} {gemeente[i]}");
                }
                WriteLine();
                WriteLine("Hoofdmenu");
                WriteLine("---------");
                WriteLine("1) een persoon toevoegen");
                WriteLine("2) een persoon verwijderen");
                WriteLine("3) een persoon aanpassen");
                WriteLine("4) alle details van een persoon zien");
                WriteLine("5) stoppen");
                WriteLine();

                keuze = VraagNietLeegIntAntwoord("Wat wil u doen", keuzeVoegToe, keuzeStop);
                WriteLine();
                
                if (keuze == keuzeVoegToe) {
                    ToonTitel("Persoon toevegen");
                    string antwoord;

                    antwoord = VraagNietLeegStringAntwoord("Voornaam");
                    voornamen[aantalPersonen] = antwoord;
                    
                    antwoord = VraagNietLeegStringAntwoord("Familienaam");
                    familienamen[aantalPersonen] = antwoord;

                    antwoord = VraagNietLeegStringAntwoord("Geslacht");
                    isVrouwen[aantalPersonen] = (antwoord == "v");

                    antwoord = VraagNietLeegStringAntwoord("Posecode");
                    gemeente[aantalPersonen] = antwoord;

                    antwoord = VraagNietLeegStringAntwoord("Gemeente");
                    familienamen[aantalPersonen] = antwoord;

                    int aantal = VraagNietLeegIntAntwoord("Aantal kinderen", 0, int.MaxValue);
                    aantalKinderen[aantalPersonen] = aantal;

                    WriteLine();
                    WriteLine("Ingevoerde gegevens");
                    WriteLine("*******************");
                    WriteLine("voornaam     : " + voornamen[aantalPersonen]);
                    WriteLine("familienaam  : " + familienamen[aantalPersonen]);
                    WriteLine("geslacht     : " + (isVrouwen[aantalPersonen]? "vrouw" : "man"));
                    WriteLine("postcode     : " + postcodes[aantalPersonen]);
                    WriteLine("gemeente     : " + gemeente[aantalPersonen]);
                    WriteLine("kinderen     : " + aantalKinderen[aantalPersonen]);

                    antwoord = VraagKeuze("Wil u deze gegevens bewaren", jaNeeKeuzes);

                    if (antwoord == "j") {
                        aantalPersonen++;
                    }

                    } else if (keuze == keuzeVerwijder) {
                    ToonTitel("Persoon verwijderen");

                        int index = VraagNietLeegIntAntwoord("Welke persoon wil u verwijderen",0, aantalPersonen -1);

                    ToonPersoonDetails(index, voornamen, familienamen, isVrouwen, postcodes, gemeente, aantalKinderen);
                    string antwoord = VraagKeuze("Wil u de gegevens van deze persoon daadwerkelijk verwijderen? ", jaNeeKeuzes);

                        if (antwoord =="j") {
                            for (int i = index; i < aantalPersonen -1; i++) {
                                voornamen[i] = voornamen[i + 1];
                                familienamen[i] = familienamen[i + 1];
                                isVrouwen[i] = isVrouwen[i + 1];
                                postcodes[i] = postcodes[i + 1];
                                gemeente[i] = gemeente[i + 1];
                                aantalKinderen[i] = aantalKinderen[i + 1];

                            }
                            aantalPersonen--;
                        }

                    }else if(keuze == keuzeBewerk) {
                        
                    ToonTitel("Persoon bewerken");
                    int index = VraagNietLeegIntAntwoord("Welke persoon wil u bewerken", 0, aantalPersonen - 1);
                    WriteLine("Indien u een gegeven ongewijzigd wil laten, druk dan gewoon op enter.");

                    string voornaam = VraagStringAntwoord("Voornaam");
                    string familienaam = VraagStringAntwoord("Familienaam");
                    string geslacht = VraagKeuze("Geslacht",geslachtLeegKeuzes);
                    string postcode = VraagStringAntwoord("Postcode");
                    string gemeent = VraagStringAntwoord("Gemeente");
                    int aantal = VraagIntAntwoord("Aantal kinderen",0,int.MaxValue);

                    
                    WriteLine();
                    ToonTitel("Gewijzigde gegevens");
                    if(voornaam != "") {
                        WriteLine("voornaam     : " + voornaam);
                    }
                    if (familienaam != "") {
                        WriteLine("familinaam   : " + familienamen);
                    }
                    if (geslacht != "") {
                        WriteLine("geslacht     : " + (geslacht == "v" ? "vrouw" : "man"));
                    }
                    if (postcode != "") {
                        WriteLine("postcode     : " + postcode);
                    }
                    if (gemeent != "") {
                        WriteLine("gemeente     : " + gemeent);
                    }
                    if (aantal != -1) {
                        WriteLine("kinderen     : " + aantal);
                    }
                    string antwoord = VraagKeuze("Wil u deze wijziging(en) bewaren", jaNeeKeuzes);
                    
                    if (antwoord =="j") {
                        if (voornaam != "") {
                            voornamen[index] = voornaam;
                        }
                        if (familienaam != "") {
                            familienamen[index] = familienaam;
                        }
                        if (geslacht != "") {
                            isVrouwen[index] = (geslacht =="v");
                        }
                        if (postcode != "") {
                            postcodes[index] = postcode;
                        }
                        if (gemeent != "") {
                            gemeente[index] = gemeent;
                        }
                        if (aantal != -1) {
                            aantalKinderen[index] = aantal;
                        }
                    }


                }else if(keuze == keuzeToon) {
                    int index = VraagNietLeegIntAntwoord("Van Welke persoon wil u deatils zien", 0, aantalPersonen);

                    ToonPersoonDetails(index, voornamen, familienamen, isVrouwen, postcodes, gemeente, aantalKinderen);
                    
                    WriteLine();
                    WriteLine("Druk op enter om terug te keren naar het hoofdmenu");
                    ReadLine();
                }


                
            } while (keuze != keuzeStop);

        }
    }
}
