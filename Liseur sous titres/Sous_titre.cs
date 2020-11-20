using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liseur_sous_titres
{
    class Sous_titre
    {
        public TimeSpan apparition = new TimeSpan();
        public TimeSpan disparition = new TimeSpan();
        public string texte = "";

        public Sous_titre(TimeSpan apparition, TimeSpan disparition, string texte)
        {

            this.texte = texte;
            this.apparition = apparition;
            this.disparition = disparition;
        }
    }
}
