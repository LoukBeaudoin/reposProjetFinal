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
using Org.BouncyCastle.Utilities;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinal
{
    public sealed partial class DialogAjoutSeance : ContentDialog
    {
        DateTime parsedDateOrg;
        int parsedNbPlaces;
        int selectedHour;
        int selectedMinutes;
        public DialogAjoutSeance()
        {
            this.InitializeComponent();
        }

        private void OnPrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            string inputDate = tbx_dateOrganisation.Text;
            string inputNbPlaces = tbx_nbPlaceDispo.Text;

            if (!DateTime.TryParse(inputDate, out parsedDateOrg))
            {
                erreur_dateOrganisation.Visibility = Visibility.Visible;
                erreur_dateOrganisation.Text = "Veuillez entrer une date valide (YYYY/MM/DD).";
                args.Cancel = true;
            }
            else
            {
                erreur_dateOrganisation.Visibility = Visibility.Collapsed;
            }
            if (inputNbPlaces.Trim() == string.Empty || !Int32.TryParse(inputNbPlaces, out parsedNbPlaces))
            { 
                erreur_nbPlaceDispo.Visibility = Visibility.Visible;
                erreur_nbPlaceDispo.Text = "Veuillez entrer un nombre de places valide (nombre)";
                args.Cancel = true;
            }
            else
            {
                erreur_nbPlaceDispo.Visibility = Visibility.Collapsed;
            }
            if (tp_heureSeance.SelectedTime is TimeSpan selectedTime)
            {
                selectedHour = selectedTime.Hours;
                selectedMinutes = selectedTime.Minutes;
                erreur_HeureSeance.Visibility = Visibility.Collapsed;
            }
            else
            {
                erreur_HeureSeance.Visibility = Visibility.Visible;
                erreur_HeureSeance.Text = "Veuillez sélectionner une heure valide";
                args.Cancel = true;
            }
            if (noteApp.SelectedIndex == -1) 
            { 
                erreur_NoteApp.Visibility = Visibility.Visible;
                erreur_NoteApp.Text = "Veuillez choisir une note (/5)";
                args.Cancel = true;
            }
            else
            {
                erreur_NoteApp.Visibility = Visibility.Collapsed;
            }
        }
        public DateTime DateOrg => parsedDateOrg;
        public string HeureSeance => $"{selectedHour}:{selectedMinutes}";
        public int NbPlaces => parsedNbPlaces;
        public string NoteAppr => noteApp.SelectedItem.ToString();
    }
}
