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
    public sealed partial class DialogAjoutActivite : ContentDialog
    {
        public string inputNom;
        public string inputType;
        public string inputPrixOrg;
        public string inputPrixVente;
        public double parsedPrixOrg;
        public double parsedPrixVente;
        public DialogAjoutActivite()
        {
            this.InitializeComponent();
        }
        private void OnPrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            inputNom = tbx_nom.Text.Trim();
            inputType = cbbx_categorie.SelectedItem.ToString();
            inputPrixOrg = tbx_coutOrganisation.Text.Trim();
            inputPrixVente = tbx_prixDeVente.Text.Trim();

            if (string.IsNullOrEmpty(inputNom))
            {
                erreur_nom.Visibility = Visibility.Visible;
                erreur_nom.Text = "Veuillez entrer un nom valide.";
                args.Cancel = true;
            }
            else
            {
                erreur_nom.Visibility = Visibility.Collapsed;
            }
            if (cbbx_categorie.SelectedIndex == -1)
            {
                erreur_idCategorie.Visibility = Visibility.Visible;
                erreur_idCategorie.Text = "Veuillez choisir une catégorie.";
                args.Cancel = true;
            }
            else
            {
                erreur_idCategorie.Visibility = Visibility.Collapsed;
            }
            if (!double.TryParse(inputPrixOrg, out parsedPrixOrg))
            {
                erreur_coutOrganisation.Visibility = Visibility.Visible;
                erreur_coutOrganisation.Text = "Veuillez entrer un prix valide.";
                args.Cancel = true;
            }
            else
            {
                erreur_coutOrganisation.Visibility = Visibility.Collapsed;
            }
            if (!double.TryParse(inputPrixVente, out parsedPrixVente))
            {
                erreur_prixDeVente.Visibility = Visibility.Visible;
                erreur_prixDeVente.Text = "Veuillez entrer un prix de vente valide.";
                args.Cancel = true;
            }
            else
            {
                erreur_prixDeVente.Visibility = Visibility.Collapsed;
            }
        }
        public string Nom
        {
            get => inputNom;
            set => inputNom = value;
        }
        public string Type
        {
            get => inputType;
            set => inputType = value;
        }
        public double PrixOrg
        {
            get => parsedPrixOrg;
            set => parsedPrixOrg = value;
        }
        public double PrixVente
        {
            get => parsedPrixVente;
            set => parsedPrixVente = value;
        }
    }
}
