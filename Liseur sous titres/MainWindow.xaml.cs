using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Liseur_sous_titres
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Film.Source = new Uri(OuvrirFichier.OuvrirFichierLecture(OuvrirFichier.choixTypesFichiers.video));
            List<Sous_titre> sous_titres_complets = Lire_srt.Lire_fichier_srt(OuvrirFichier.OuvrirFichierLecture(OuvrirFichier.choixTypesFichiers.sous_titre));
            //while (!Film.IsLoaded)
            //{}
            Go(sous_titres_complets);
        }
        
        async void Go(List<Sous_titre> st)
        {

            for (int i = 0; i < st.Count; i++)
            {
                
                await (Task.Delay(st[i].apparition));
                this.sous_titre.Text = st[i].texte;
  
                await (Task.Delay(st[i].disparition));
                this.sous_titre.Text = "";
            }
        }
    }
}
