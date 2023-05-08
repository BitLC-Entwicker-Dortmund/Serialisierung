using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialisierung {
    [Serializable]
    class Mitarbeiter {
        public int MitarbeiterId { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }

        // Überschreiben der ToString-Methode für eine optisch ansprechende - Darstellung
        public virtual string ToString() {
            return ($"{MitarbeiterId}\t{Nachname}\t{Vorname} ");
        }
    }


    class Personalverwaltung {
        private List<Mitarbeiter> Personal = new List<Mitarbeiter>();

        public void Add(Mitarbeiter m) {
            Personal.Add(m);
        }

        public List<Mitarbeiter> ListePersonal() {
            return Personal;
        }

        public bool Contains(Mitarbeiter mitarbeiter) {
            bool istDa = Personal.Contains(mitarbeiter);
            return istDa;
        }

        public void Remove(Mitarbeiter mitarbeiter) {
            if (Personal.Contains(mitarbeiter)) {
                Personal.Remove(mitarbeiter);
                this.Persist();
            }
        }

        public void Remove(int mid) {
            Mitarbeiter m = null;
            foreach (var item in Personal) {
                if (item.MitarbeiterId == mid) {
                    m = item;
                    break;
                }
            }
            this.Remove(m);
        }


        // Schreiben mittels BinaryFormater
        public void Persist() {
            // Datei zum Schreiben öffnen
            FileStream fileOutputStream = new FileStream(@"Peronal.dat", FileMode.OpenOrCreate, FileAccess.Write);
            // BinaryFormater-Objekt erzeugen
            BinaryFormatter binFttr = new BinaryFormatter();
            // Objekt-Geflecht schreiben - keine Schleife erforderlich!
            binFttr.Serialize(fileOutputStream, Personal);
            Console.WriteLine("Datei geschrieben ...");
            // wichtig ! DataStream immer schließen!
            fileOutputStream.Close();
        }

        // Lesen mittels BinaryFormater
        public void GetContentFromFile() {
            FileStream fileInputStream = new FileStream(@"Peronal.dat", FileMode.Open, FileAccess.Read);
            // hier wären andere Varianten möglich, wie XML oder DataContract
            BinaryFormatter binFttr = new BinaryFormatter();

            // Lösche vorhandene Liste 
            Personal.Clear();

            // Ersetze vorhandene Liste durch den Inhalt der Datei
            // Objeke werden neu erzeugt und in das List-Objekt geschrieben
            Personal = (List<Mitarbeiter>)binFttr.Deserialize(fileInputStream);
            fileInputStream.Close();
        }
    }


}
