using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Windows.UI.Core;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;
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
    public sealed partial class PageAdmin : Page
    {
        ObservableCollection<Adherent> listeAdherent = SingletonListeAdherent.GetInstance().GetListeAdherent();
        ObservableCollection<Activite> listeActivite = SingletonListeActivites.GetInstance().GetListeActivite();
        ObservableCollection<Seance> listeSeance = SingletonListeSeance.GetInstance().GetListeSeance();
        
        public PageAdmin()
        {
            this.InitializeComponent();
            Adherent adherentTest = new Adherent("mil", "mea", "assds", new DateTimeOffset(new DateTime(2006,07,19)));
            listeAdherent.Add(adherentTest);
            Activite activiteTest = new Activite("as", "ass", 12, 13);
            listeActivite.Add(activiteTest);
            Seance seanceTest = new Seance(DateTime.Now, new TimeSpan(14, 30, 0), 15, 3);
            listeSeance.Add(seanceTest);
        }
        private async void btn_ajout_adherent_Click(object sender, RoutedEventArgs e)
        {
            DialogAjoutAdherent dialog = new DialogAjoutAdherent();
            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Nouveau adhérent";
            dialog.PrimaryButtonText = "Ajouter";
            dialog.DateNaissance = DateTime.Now;
            dialog.DefaultButton = ContentDialogButton.Close;
            ContentDialogResult resultat = await dialog.ShowAsync();
            if (resultat == ContentDialogResult.Primary)
            {
                try
                {
                    SingletonListeAdherent.GetInstance().Liste.Add(new Adherent(dialog.Nom, dialog.Prenom, dialog.Adresse, dialog.DateNaissance));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (resultat == ContentDialogResult.Secondary)
            {
                Console.WriteLine("Action canceled.");
            }
        }
        private async void btn_ajout_activite_Click(object sender, RoutedEventArgs e)
        {
            DialogAjoutActivite dialog = new DialogAjoutActivite();
            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Nouvelle activité";
            dialog.PrimaryButtonText = "Ajouter";
            dialog.DefaultButton = ContentDialogButton.Close;
            ContentDialogResult resultat = await dialog.ShowAsync();
            if (resultat == ContentDialogResult.Primary)
            {
                try
                {
                    SingletonListeActivites.GetInstance().Liste.Add(new Activite(dialog.Nom, dialog.Type, dialog.PrixOrg, dialog.PrixVente));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (resultat == ContentDialogResult.Secondary)
            {
                Console.WriteLine("Action canceled.");
            }
        }
        private async void btn_ajout_seance_Click(object sender, RoutedEventArgs e)
        {
            DialogAjoutSeance dialog = new DialogAjoutSeance();
            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Nouvelle séance";
            dialog.PrimaryButtonText = "Ajouter";
            dialog.DateOrg = DateTime.Now;
            dialog.Heure = new TimeSpan();
            dialog.DefaultButton = ContentDialogButton.Close;
            ContentDialogResult resultat = await dialog.ShowAsync();
            Console.WriteLine(resultat);
            if (resultat == ContentDialogResult.Primary)
            {
                try
                {
                    new Seance(dialog.DateOrg, dialog.Heure, Int32.Parse(dialog.NbPlaces), dialog.NoteAppreciation);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (resultat == ContentDialogResult.Secondary)
            {
                Console.WriteLine("Action canceled.");
            }
        }

        private async void Gv_Affichage_Adherent_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Adherent clickedAdherent)
            {
                var dialog = new DialogAjoutAdherent
                {
                    Nom = clickedAdherent.Nom,
                    Prenom = clickedAdherent.Prenom,
                    Adresse = clickedAdherent.Adresse,
                    DateNaissance = clickedAdherent.DateNaissance,
                    XamlRoot = this.XamlRoot,
                    PrimaryButtonText = "Modifier",
                    SecondaryButtonText = "Supprimer"
                };
                var result = await dialog.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    clickedAdherent.Nom = dialog.Nom;
                    clickedAdherent.Prenom = dialog.Prenom;
                    clickedAdherent.Adresse = dialog.Adresse;
                    clickedAdherent.DateNaissance = dialog.DateNaissance;
                }
                else if (result == ContentDialogResult.Secondary)
                {
                    listeAdherent.Remove(clickedAdherent);
                }
                else
                {
                    Debug.WriteLine("Annulé (320)");
                }
            }
        }
        private async void Gv_Affichage_Activite_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Activite clickedActivite)
            {
                var dialog = new DialogAjoutActivite
                {
                    Nom = clickedActivite.Nom,
                    Type = clickedActivite.Type,
                    PrixOrg = clickedActivite.PrixOrganisation,
                    PrixVente = clickedActivite.PrixVente,
                    XamlRoot = this.XamlRoot,
                    PrimaryButtonText = "Modifier",
                    SecondaryButtonText = "Supprimer"
                };
                dialog.SetComboBoxSelection(clickedActivite.Type);
                var result = await dialog.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    clickedActivite.Nom = dialog.Nom;
                    clickedActivite.Type = dialog.Type;
                    clickedActivite.PrixOrganisation = dialog.PrixOrg;
                    clickedActivite.PrixVente = dialog.PrixVente;
                }
                else if (result == ContentDialogResult.Secondary)
                {
                    listeActivite.Remove(clickedActivite);
                }
            }
        }
        private async void Gv_Affichage_Seance_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Seance clickedSeance)
            {
                var dialog = new DialogAjoutSeance
                {
                    DateOrg = clickedSeance.Date,
                    NbPlaces = clickedSeance.NbPlaces.ToString(),
                    Heure = clickedSeance.Heure,
                    NoteAppreciation = clickedSeance.Note,
                    XamlRoot = this.XamlRoot,
                    PrimaryButtonText = "Modifier",
                    SecondaryButtonText = "Supprimer"
                };
                //dialog.SetComboBoxSelection(dialog.NoteAppreciation);
                var result = await dialog.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    clickedSeance.Date = dialog.DateOrg;
                    clickedSeance.NbPlaces = Int32.Parse(dialog.NbPlaces);
                    clickedSeance.Heure = dialog.Heure;
                    clickedSeance.Note = dialog.NoteAppreciation;
                }
                else if (result == ContentDialogResult.Secondary)
                {
                    listeSeance.Remove(clickedSeance);
                }
                else
                {
                    Debug.WriteLine("Annulé (320)");
                }
            }
        }

        private void btnAdherent_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = listeAdherent;
            if (Gv_Affichage_Adherent.Visibility == Visibility.Visible)
            {
                Gv_Affichage_Adherent.Visibility = Visibility.Collapsed;
                btnAdherentAjout.Visibility = Visibility.Collapsed;
            }
            else
            {
                Gv_Affichage_Adherent.Visibility = Visibility.Visible;
                btnAdherentAjout.Visibility = Visibility.Visible;
            }
            Gv_Affichage_Activite.Visibility = Visibility.Collapsed;
            Gv_Affichage_Seance.Visibility = Visibility.Collapsed;

        }
        private void btnActivite_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = listeActivite;
            if (Gv_Affichage_Activite.Visibility == Visibility.Visible)
            {
                Gv_Affichage_Activite.Visibility = Visibility.Collapsed;
                btnActiviteAjout.Visibility = Visibility.Collapsed;
            }
            else
            {
                Gv_Affichage_Activite.Visibility = Visibility.Visible;
                btnActiviteAjout.Visibility = Visibility.Visible;
            }
            Gv_Affichage_Adherent.Visibility = Visibility.Collapsed;
            Gv_Affichage_Seance.Visibility = Visibility.Collapsed;
        }
        private void btnSeance_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = listeSeance;
            if (Gv_Affichage_Seance.Visibility == Visibility.Visible)
            {
                Gv_Affichage_Seance.Visibility = Visibility.Collapsed;
                btnSeanceAjout.Visibility = Visibility.Collapsed;
            }
            else
            {
                Gv_Affichage_Seance.Visibility = Visibility.Visible;
                btnSeanceAjout .Visibility = Visibility.Visible;
            }
            Gv_Affichage_Adherent.Visibility = Visibility.Collapsed;
            Gv_Affichage_Activite.Visibility = Visibility.Collapsed;
        }

        private async void sauvgarderActivite_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileSavePicker();

            var window = (Application.Current as App)?.MainWindow;
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            picker.SuggestedFileName = "activite";
            picker.FileTypeChoices.Add("Fichier texte", new List<string>() { ".csv" });

            Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();
            List<Activite> liste = new List<Activite>();
            if (monFichier != null) 
            {
                liste = SingletonBD.getInstance().Liste.ToList();
            }
            else
            {
                return;
            }

            await Windows.Storage.FileIO.WriteLinesAsync(monFichier, liste.ConvertAll(x => x.StringCSV), Windows.Storage.Streams.UnicodeEncoding.Utf8);

        }

        private async void sauvgarderAdherent_Click(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileSavePicker();

            var window = (Application.Current as App)?.MainWindow;
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
            WinRT.Interop.InitializeWithWindow.Initialize(picker, hWnd);

            picker.SuggestedFileName = "adherent";
            picker.FileTypeChoices.Add("Fichier texte", new List<string>() { ".csv" });

            Windows.Storage.StorageFile monFichier = await picker.PickSaveFileAsync();
            List<Adherent> liste = new List<Adherent>();
            if (monFichier != null)
            {
                liste = SingletonBD.getInstance().ListeAdherent.ToList();
            }
            else
            {
                return;
            }

            await Windows.Storage.FileIO.WriteLinesAsync(monFichier, liste.ConvertAll(x => x.StringCSV), Windows.Storage.Streams.UnicodeEncoding.Utf8);
        }
    }
}
