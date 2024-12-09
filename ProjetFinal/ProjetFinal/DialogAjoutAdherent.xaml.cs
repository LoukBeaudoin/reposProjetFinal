using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinal
{
    public sealed partial class DialogAjoutAdherent : ContentDialog
    {
        DateTime parsedDateNaissance;
        string inputNom;
        string inputPrenom;
        string inputAdresse;
        string inputDateNaissance;
        public DialogAjoutAdherent()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        private void OnPrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            inputNom = tbx_nom.Text.Trim();
            inputPrenom = tbx_prenom.Text.Trim();
            inputAdresse = tbx_adresse.Text.Trim();
            inputDateNaissance = tbx_dateNaissance.Text;

            if (inputNom == string.Empty)
            {
                erreur_nom.Visibility = Visibility.Visible;
                erreur_nom.Text = "Veuillez entrer un nom valide.";
                args.Cancel = true;
            }
            else
            {
                erreur_nom.Visibility = Visibility.Collapsed;
            }
            if (inputPrenom == string.Empty)
            {
                erreur_prenom.Visibility = Visibility.Visible;
                erreur_prenom.Text = "Veuillez entrer un prénom valide.";
                args.Cancel = true;
            }
            else
            {
                erreur_prenom.Visibility= Visibility.Collapsed;
            }
            if (!DateTime.TryParse(inputDateNaissance, out parsedDateNaissance))
            {
                erreur_dateNaissance.Visibility = Visibility.Visible;
                erreur_dateNaissance.Text = "Veuillez entrer une date de naissance valide (YYYY/MM/DD).";
                args.Cancel = true;
            }
            else
            {
                erreur_dateNaissance.Visibility = Visibility.Collapsed;
            }
            if (inputAdresse == string.Empty)
            {
                erreur_adresse.Visibility = Visibility.Visible;
                erreur_adresse.Text = "Veuillez entrer une adresse.";
                args.Cancel = true;
            }
            else
            {
                erreur_adresse.Visibility = Visibility.Collapsed;
            }
        }
        public DateTime DateNaissance
        {
            get => parsedDateNaissance;
            set => parsedDateNaissance = value;
        }
        public string Nom
        {
            get => inputNom;
            set => inputNom = value;
        }
        public string Prenom
        {
            get => inputPrenom;
            set => inputPrenom = value;
        }
        public string Adresse
        {
            get => inputAdresse;
            set => inputAdresse = value;
        }
    }
}
