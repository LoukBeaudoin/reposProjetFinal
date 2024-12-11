using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageStats : Page
    {
        public ObservableCollection<KeyValuePair<string, int>> AdherentActivite { get; set; }
        public ObservableCollection<KeyValuePair<string, int>> ActiviteNote { get; set; }
        public PageStats()
        {
            this.InitializeComponent();
            Statistique();
        }

        private void Statistique()
        {
            //Total Adherent
            var totalAdherent = SingletonBD.getInstance().getTotalAdherent();

            nbTotalAdherent.Text = $"{totalAdherent}";

            //Total Activite
            var totalActivite = SingletonBD.getInstance().getTotalActivite();

            nbTotalActivite.Text = $"{totalAdherent}";

            //Nombre adherent par activités
            var adherentCategorie = SingletonBD.getInstance().getNbAdherentActivite();
            AdherentActivite = new ObservableCollection<KeyValuePair<string, int>>(adherentCategorie);
            this.DataContext = this;

            foreach (var activites in adherentCategorie)
            {
                TextBlock adherentText = new TextBlock
                {
                    Text = $"{activites.Key} : ",
                    FontSize = 20,
                };
                TextBlock activiteResultat = new TextBlock
                {
                    Text = $"{activites.Value}",
                    FontSize = 20,
                };
                stk_nbAdherentActivite.Children.Add(adherentText);
                stk_nbAdherentActiviteResultat.Children.Add(activiteResultat);
            }

            //Adherent avec le plus de seance 
            var adherentPlusSeance = SingletonBD.getInstance().getAdherentMaxSeance();
            tbx_adherentPlusSeance.Text = $"{adherentPlusSeance}";

            //Age moyen des adhérents
            var ageMoyenAdherent = SingletonBD.getInstance().getAgeMoyenAdherent();

            moyenneAge.Text = $"{ageMoyenAdherent}";

            //Note moyenne des activités
            var noteMoyenneActivite = SingletonBD.getInstance().getNoteMoyenneActivites();
            ActiviteNote = new ObservableCollection<KeyValuePair<string, int>>(noteMoyenneActivite);
            this.DataContext = this;

            foreach (var activites in noteMoyenneActivite)
            {
                TextBlock activiteText = new TextBlock
                {
                    Text = $"{activites.Key} : ",
                    FontSize = 20,
                };
                TextBlock noteMoyenne = new TextBlock
                {
                    Text = $"{activites.Value}",
                    FontSize = 20,
                };
                stk_moyenneNoteActivite.Children.Add(activiteText);
                stk_moyenneNoteActiviteResultat.Children.Add(noteMoyenne);
            }

            var totalInscription = SingletonBD.getInstance().getTotalInscription();

            nbTotalInscription.Text = $"{totalInscription}";


        }
    }
}
