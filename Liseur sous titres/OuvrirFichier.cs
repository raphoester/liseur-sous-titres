using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Microsoft.Win32;

namespace Liseur_sous_titres
{
    partial class OuvrirFichier : Window
    {
        public enum choixTypesFichiers { video, sous_titre };
        public static string OuvrirFichierLecture(choixTypesFichiers typeFichier)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            switch(typeFichier)
            {
                case choixTypesFichiers.video:
                    dlg.Filter = "fichiers mp4|*.mp4|fichiers avi|*.avi";
                    break;
                case choixTypesFichiers.sous_titre:
                    dlg.Filter = "fichiers srt|*.srt";
                    break;
            }
           
            Nullable<bool> resultat = dlg.ShowDialog();
            if(resultat == true)
            {
                return dlg.FileName;
            }
            else
            {
                return null;
            }

        }
    }
}
