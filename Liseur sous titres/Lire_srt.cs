using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Liseur_sous_titres
{
    class Lire_srt
    {
        static TimeSpan derniereBorne = new TimeSpan();
        public static List<Sous_titre> Lire_fichier_srt(string chemin)
        {
            List<Sous_titre> retour = new List<Sous_titre>();
            List<string> blocLu = new List<string>();
            string lecture;
            using (StreamReader sr = new StreamReader(chemin))
            {
                do
                {
                    int i = 0;
                    do
                    {
                        i++;
                        lecture = sr.ReadLine();
                        blocLu.Add(lecture);

                    } while (lecture != "" && !sr.EndOfStream);

                    retour.Add(Lire_bloc_st(blocLu));
                    blocLu.Clear();


                } while (!sr.EndOfStream);
                return retour;
            }
        }

        static Sous_titre Lire_bloc_st(List<string> bloc)
        {
            string texte = "";

            char[] fleche = { ' ', '-', '-', '>', ' '};
            List<string> debutFin = new List<string>();
            foreach (string s in bloc[1].Split(fleche))
            {
                if(s != "")
                {
                    debutFin.Add(s);
                }
            }


            TimeSpan decalageDebut = TimeSpan.Parse(debutFin[0]) - derniereBorne;
            derniereBorne = TimeSpan.Parse(debutFin[0]);
            TimeSpan decalageFin = TimeSpan.Parse(debutFin[1]) - derniereBorne;
            derniereBorne = TimeSpan.Parse(debutFin[1]);

            for (int i = 2; i < bloc.Count; i++)
            {
                texte = string.Concat(texte, bloc[i]);
                texte = string.Concat(texte, " ");
            }
            Sous_titre retour = new Sous_titre(decalageDebut, decalageFin, texte);
            return retour;
        }
    }
}
