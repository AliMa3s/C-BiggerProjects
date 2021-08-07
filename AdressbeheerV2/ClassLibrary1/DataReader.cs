using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ClassLibrary1 {
    public class DataReader {
        //public HashSet<Gemeente> gemeentes = new HashSet<Gemeente>();
        //public HashSet<Straat> straten = new HashSet<Straat>();
        public Dictionary<int, Adres> adressen = new Dictionary<int, Adres>();
        public Dictionary<int, Gemeente> gemeentes = new Dictionary<int, Gemeente>();
        public Dictionary<int, Straat> straten = new Dictionary<int, Straat>();
        public Dictionary<int, AdresLocatie> adreslocatie = new Dictionary<int, AdresLocatie>();

        //public Dictionary<int, Gemeente> gemeentes = new Dictionary<int, Gemeente>();

        string path = @"D:\Hogent\Test\CRAB_Adressenlijst_GML\GML\CrabAdr.gml";
        public Dictionary<int, Adres> readFile() {
            Dictionary<int, Adres> adressen = new Dictionary<int, Adres>();
            FileInfo file = new FileInfo(path);
            using (StreamReader sr = new StreamReader(file.FullName)) {
                string[] line;
                List<string> props = null;
                int id = 1;
                while (!sr.EndOfStream) {
                    line = sr.ReadLine().Split();
                    if (line[0] != "<?xml") {
                        if (Array.Exists(line, e => e == "<agiv:CrabAdr>")) {
                            props = new List<string>();
                        }
                        if (Array.Exists(line, e => e.Contains("<agiv:ID>"))) {
                            string gmlValue = line[9].Replace("<agiv:ID>", "").Replace("</agiv:ID>", "");
                            props.Add(gmlValue);
                        } // 0
                        if (Array.Exists(line, e => e.Contains("<agiv:STRAATNMID>"))) {
                            string gmlValue = line[9].Replace("<agiv:STRAATNMID>", "").Replace("</agiv:STRAATNMID>", "");
                            props.Add(gmlValue);
                        } // 1
                        if (Array.Exists(line, e => e.Contains("<agiv:STRAATNM>"))) {
                            string gmlValue = line[9].Replace("<agiv:STRAATNM>", "").Replace("</agiv:STRAATNM>", "");
                            props.Add(gmlValue);
                        } // 2
                        if (Array.Exists(line, e => e.Contains("<agiv:HUISNR>"))) {
                            string gmlValue = line[9].Replace("<agiv:HUISNR>", "").Replace("</agiv:HUISNR>", "");
                            props.Add(gmlValue);
                        } // 3
                        if (Array.Exists(line, e => e.Contains("<agiv:HNRLABEL>"))) {
                            string gmlValue = line[9].Replace("<agiv:HNRLABEL>", "").Replace("</agiv:HNRLABEL>", "");
                            props.Add(gmlValue);
                        } // 4
                        if (Array.Exists(line, e => e.Contains("<agiv:NISCODE>"))) {
                            string gmlValue = line[9].Replace("<agiv:NISCODE>", "").Replace("</agiv:NISCODE>", "");
                            props.Add(gmlValue);
                        } // 5
                        if (Array.Exists(line, e => e.Contains("<agiv:GEMEENTE>"))) {
                            string gmlValue = line[9].Replace("<agiv:GEMEENTE>", "").Replace("</agiv:GEMEENTE>", "");
                            props.Add(gmlValue);
                        } // 6
                        if (Array.Exists(line, e => e.Contains("<agiv:POSTCODE>"))) {
                            string gmlValue = line[9].Replace("<agiv:POSTCODE>", "").Replace("</agiv:POSTCODE>", "");
                            props.Add(gmlValue);
                        } // 7
                        if (Array.Exists(line, e => e.Contains("<gml:X>"))) {
                            string gmlValue = line[18].Replace("<gml:X>", "").Replace("</gml:X>", "");
                            props.Add(gmlValue);
                        } // 8
                        if (Array.Exists(line, e => e.Contains("<gml:Y>"))) {
                            string gmlValue = line[18].Replace("<gml:Y>", "").Replace("</gml:Y>", "");
                            props.Add(gmlValue);
                        } // 9
                        if (Array.Exists(line, e => e.Contains("</agiv:CrabAdr>"))) {
                            Gemeente newGemeente = new Gemeente(props[6], int.Parse(props[5]));
                            if (!gemeentes.ContainsKey(newGemeente.NIScode)) {
                                gemeentes.Add(newGemeente.NIScode, newGemeente);
                            }

                            Straat newStraat = new Straat(id, props[2], newGemeente.NIScode);
                            if (!straten.ContainsKey(newStraat.Id)) {
                                straten.Add(newStraat.Id, newStraat);
                            }
                            AdresLocatie newAdresLocatie = new AdresLocatie(id, double.Parse(props[8].Replace('.', ',')), double.Parse(props[9].Replace('.', ',')));
                            if (!adreslocatie.ContainsKey(newAdresLocatie.Id)) {
                                adreslocatie.Add(newAdresLocatie.Id, newAdresLocatie);
                            }

                            Adres newAdres;
                            try {
                                newAdres = new Adres(int.Parse(props[0]), props[3], props[4], int.Parse(props[7]), newStraat, newAdresLocatie);
                                if (!adressen.ContainsKey(newAdres.ID)) {
                                    adressen.Add(newAdres.ID, newAdres);
                                }
                            } catch (HuisnummerException) {
                                newAdres = new Adres(int.Parse(props[0]), "1" + props[3], props[4], int.Parse(props[7]), newStraat, newAdresLocatie);
                            }
                            //adressen.Add(newAdres.ID, newAdres);
                        }
                    }
                    id++;
                }
            }
            return adressen;
        }
    }
}

