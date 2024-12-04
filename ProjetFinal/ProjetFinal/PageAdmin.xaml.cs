using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
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
        public PageAdmin()
        {
            this.InitializeComponent();
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


        private async void btn_ajout_adherent_Click(object sender, RoutedEventArgs e)
        {
            DialogAjoutAdherent dialog = new DialogAjoutAdherent();
            dialog.XamlRoot = this.XamlRoot;
            dialog.PrimaryButtonText = "Ajouter";
            dialog.CloseButtonText = "Annuler";
            dialog.Title = "Nouveau adhérent";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();
        }

        private async void btn_ajout_activite_Click(object sender, RoutedEventArgs e)
        {
            DialogAjoutActivite dialog = new DialogAjoutActivite();
            dialog.XamlRoot = this.XamlRoot;
            dialog.PrimaryButtonText = "Ajouter";
            dialog.CloseButtonText = "Annuler";
            dialog.Title = "Nouvelle activité";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();
        }

        private async void btn_ajout_seance_Click(object sender, RoutedEventArgs e)
        {
            DialogAjoutSeance dialog = new DialogAjoutSeance();
            dialog.XamlRoot = this.XamlRoot;
            dialog.PrimaryButtonText = "Ajouter";
            dialog.CloseButtonText = "Annuler";
            dialog.Title = "Nouvelle séance";
            dialog.DefaultButton = ContentDialogButton.Close;

            ContentDialogResult resultat = await dialog.ShowAsync();
        }
    }
}
