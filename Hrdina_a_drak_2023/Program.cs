using Hrdina_a_drak_2023.Postavy;
using Hrdina_a_drak_2023.Veci;
using System;
using System.IO;

namespace Hrdina_a_drak_2023
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hrdina hrdina = new Hrdina();
            //hrdina.Zdravi = 2000;
            //Console.WriteLine(hrdina.Zdravi);
            //hrdina.Zdravi = 1000;
            //Console.WriteLine(hrdina.Zdravi);


            //try
            //{
            //    Hrdina hrdinaDocasny = new Hrdina(100, null);
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


            Mec mec = new Mec("Excalibur", 25);
            mec = new Mec("obycejny mec", 20);
            Hrdina hrdina = new Hrdina(100, mec);
            Drak drak = new Drak(120, 15);

            using (StreamWriter streamWriter = File.CreateText("zaznam boje.txt"))
            {
                string udajeOzacatku = $"Zdraví hrdiny je {hrdina.Zdravi}, zdraví draka je {drak.Zdravi},maximální útok meče '{mec.Nazev}' je {mec.MaxUtok} a maximální útok draka je {drak.MaxUtok}." + Environment.NewLine;
                streamWriter.WriteLine(udajeOzacatku);
                Console.WriteLine(udajeOzacatku);
                while (hrdina.JeZiva() && drak.JeZiva())
                {
                    double utokHrdiny = hrdina.Utok(drak);
                    string textKvypisu = $"Hrdina zaútočil hodnotou: {utokHrdiny}. Drak má {drak.Zdravi} zdraví." + Environment.NewLine;
                    Console.WriteLine(textKvypisu);
                    streamWriter.WriteLine(textKvypisu);

                    if (drak.JeZiva())
                    {
                        double utokDraka = drak.Utok(hrdina);
                        string textKvypisu1 = $"Drak zaútočil hodnotou: {utokDraka}. Hrdina má {hrdina.Zdravi} zdraví.";
                        Console.WriteLine(textKvypisu1);
                        streamWriter.WriteLine(textKvypisu1);
                    }
                    Console.WriteLine(Environment.NewLine + Environment.NewLine);
                }
            }
        }
    }
}
