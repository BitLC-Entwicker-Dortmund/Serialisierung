using System;
namespace Serialisierung {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello Mitarbeiter!");

            Personalverwaltung pv = new Personalverwaltung();

            pv.Add(new Mitarbeiter() { MitarbeiterId = 1, Vorname = "Luke", Nachname = "Skywalker" });
            pv.Add(new Mitarbeiter() { MitarbeiterId = 2, Vorname = "Anekin", Nachname = "Skywalker" });
            pv.Add(new Mitarbeiter() { MitarbeiterId = 3, Vorname = "Lea", Nachname = "Skywalker" });
            pv.Add(new Mitarbeiter() { MitarbeiterId = 4, Vorname = "Martin", Nachname = "Mustermann" });

            pv.Persist();  // Speichern 

            foreach (var item in pv.ListePersonal()) {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Hole Daten aus Datei ...");
            Console.ReadLine();

            // Lese aus Datei
            pv.GetContentFromFile();

            foreach (var item in pv.ListePersonal()) {
                Console.WriteLine(item.ToString());
            }

            pv.Remove(1);

            foreach (var item in pv.ListePersonal()) {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }
    }

}