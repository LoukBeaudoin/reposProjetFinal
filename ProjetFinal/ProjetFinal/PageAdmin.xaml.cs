using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
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
            Adherent adherentTest = new Adherent("mil", "mea", "assds", new DateTime(2006 / 07 / 19));
            listeAdherent.Add(adherentTest);
            Activite activiteTest = new Activite("as", "ass", 12, 13);
            listeActivite.Add(activiteTest);
        }

        private async void btn_ajout_adherent_Click(object sender, RoutedEventArgs e)
        {
            DialogAjoutAdherent dialog = new DialogAjoutAdherent();
            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Nouveau adhérent";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();
            if (resultat == ContentDialogResult.Primary)
            {
                try
                {
                    Adherent adherent = new Adherent(dialog.Nom, dialog.Prenom, dialog.Adresse, dialog.DateNaissance);
                    SingletonListeAdherent.GetInstance().Ajouter(adherent);
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
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();
            if (resultat == ContentDialogResult.Primary)
            {
                try
                {
                    new Activite(dialog.Nom, dialog.Type, double.Parse(dialog.PrixOrg), double.Parse(dialog.PrixVente));
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
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();
            Console.WriteLine(resultat);
            if (resultat == ContentDialogResult.Primary)
            {
                try
                {
                    new Seance(dialog.DateOrg, dialog.HeureSeance, dialog.NbPlaces, int.Parse( dialog.NoteAppr));
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

        private async void BtnModifierAdherent(Adherent adherent)
        {
            DialogAjoutAdherent dialog = new DialogAjoutAdherent();
            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Modifier Adhérent";
            dialog.PrimaryButtonText = "Modifier";
            dialog.SecondaryButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Close; 

            dialog.Nom = adherent.Nom;
            dialog.Prenom = adherent.Prenom;
            dialog.Adresse = adherent.Adresse;
            dialog.DateNaissance = adherent.DateNaissance;

            ContentDialogResult resultat = await dialog.ShowAsync();

            if (resultat == ContentDialogResult.Primary)
            {
                try
                {
                    new Adherent(dialog.Nom, dialog.Prenom, dialog.Adresse, dialog.DateNaissance);
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

        private async void btn_modifier_activite_Click(object sender, RoutedEventArgs e)
        {
            DialogModifierActivite dialog = new DialogModifierActivite();
            dialog.XamlRoot = this.XamlRoot;
            dialog.PrimaryButtonText = "Modifier";
            dialog.CloseButtonText = "Annuler";
            dialog.Title = "Modifier Activité";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();
        }
        private async void btn_modifier_seance_Click(object sender, RoutedEventArgs e)
        {
            DialogModifierSeance dialog = new DialogModifierSeance();
            dialog.XamlRoot = this.XamlRoot;
            dialog.PrimaryButtonText = "Modifier";
            dialog.CloseButtonText = "Annuler";
            dialog.Title = "Modifier Séance";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();
        }

        private async void btn_supprimer_adherent_Click(object sender, RoutedEventArgs e)
        {
            DialogSupprimerAdherent dialog = new DialogSupprimerAdherent();
            dialog.XamlRoot = this.XamlRoot;
            dialog.PrimaryButtonText = "Supprimer";
            dialog.CloseButtonText = "Annuler";
            dialog.Title = "Supprimer Adhérent";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();
        }

        private async void btn_supprimer_activite_Click(object sender, RoutedEventArgs e)
        {
            DialogSupprimerActivite dialog = new DialogSupprimerActivite();
            dialog.XamlRoot = this.XamlRoot;
            dialog.PrimaryButtonText = "Supprimer";
            dialog.CloseButtonText = "Annuler";
            dialog.Title = "Supprimer Activité";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();
        }

        private async void btn_supprimer_seance_Click(object sender, RoutedEventArgs e)
        {
            DialogSupprimerSeance dialog = new DialogSupprimerSeance();
            dialog.XamlRoot = this.XamlRoot;
            dialog.PrimaryButtonText = "Supprimer";
            dialog.CloseButtonText = "Annuler";
            dialog.Title = "Supprimer Séance";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();
        }

        private void btnAdherent_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = listeAdherent;
            Gv_Affichage_Adherent.Visibility = Visibility.Visible;
            Gv_Affichage_Activite.Visibility = Visibility.Collapsed;
            Gv_Affichage_Seance.Visibility = Visibility.Collapsed;
        }

        private void btnActivite_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = listeActivite;
            Gv_Affichage_Activite.Visibility = Visibility.Visible;
            Gv_Affichage_Adherent.Visibility = Visibility.Collapsed;
            Gv_Affichage_Seance.Visibility = Visibility.Collapsed;
        }

        private void btnSeance_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = listeSeance;
            Gv_Affichage_Seance.Visibility = Visibility.Visible;
            Gv_Affichage_Adherent.Visibility = Visibility.Collapsed;
            Gv_Affichage_Activite.Visibility = Visibility.Collapsed;
        }




        private async void btn_test_Click(object sender, RoutedEventArgs e)
        {
            MonDialogue dialog = new MonDialogue();
            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Authentification";
            dialog.PrimaryButtonText = "Annuler";
            dialog.CloseButtonText = "Se connecter";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();


        }

        private void supprimerAdherent_Click(object sender, RoutedEventArgs e)
        {

        }
        private void modifierAdherent_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            // Get the item (Adherent) associated with the clicked button
            var clickedItem = button?.DataContext as Adherent;

            // Get the index of the clicked item in the ObservableCollection
            if (clickedItem != null)
            {
                var index = listeAdherent.IndexOf(clickedItem);
                Debug.WriteLine($"Item clicked: {clickedItem.NoIdentification}");
                Debug.WriteLine($"Item index: {index}");
            }
        }
        private void supprimerActivite_Click(object sender, RoutedEventArgs e)
        {

        }

        private void modifierActivite_Click(object sender, RoutedEventArgs e)
        {

        }

        private void supprimerSeance_Click(object sender, RoutedEventArgs e)
        {

        }

        private void modifierSeance_Click(object sender, RoutedEventArgs e)
        {

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
                };
                dialog.XamlRoot = this.XamlRoot;
                var result = await dialog.ShowAsync();
                if (result == ContentDialogResult.Primary)
                {
                    // Save changes back to the collection
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
    }
}
