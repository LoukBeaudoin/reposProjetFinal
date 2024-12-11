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
using System.ComponentModel;
using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinal
{
    public sealed partial class DialogAjoutSeance : ContentDialog, INotifyPropertyChanged
    {
        public DateTimeOffset inputDateOrg;
        public int inputNbPlaces;
        public TimeSpan inputHeure;
        public string inputNoteAppreciation;

        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<Activite> activites;
        public int parsedNbPlaces;
        public int parsedNoteApp;
        public DialogAjoutSeance()
        {
            this.InitializeComponent();
            this.DataContext = this;
            activites = SingletonListeActivites.GetInstance().Liste;
            foreach (var item in activites)
            {
                ComboBoxItem comboBoxItem = new ComboBoxItem();
                comboBoxItem.Content = item.Nom;
                idActivite.Items.Add(comboBoxItem);
            }
        }



        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void OnPrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (DateOrg == default)
            {
                erreur_dateOrganisation.Visibility = Visibility.Visible;
                erreur_dateOrganisation.Text = "Veuillez entrer une date valide (YYYY/MM/DD).";
                args.Cancel = true;
            }
            else
            {
                erreur_dateOrganisation.Visibility = Visibility.Collapsed;
            }

            if (!Int32.TryParse(NbPlaces.Trim(), out parsedNbPlaces))
            { 
                erreur_nbPlaceDispo.Visibility = Visibility.Visible;
                erreur_nbPlaceDispo.Text = "Veuillez entrer un nombre de places valide (nombre)";
                args.Cancel = true;
            }
            else
            {
                erreur_nbPlaceDispo.Visibility = Visibility.Collapsed;
            }

            if (Heure == default)
            {
                erreur_HeureSeance.Visibility = Visibility.Visible;
                erreur_HeureSeance.Text = "Veuillez choisir une heure valide.";
                args.Cancel = true;
            }
            else
            {
                erreur_HeureSeance.Visibility = Visibility.Collapsed;
            }

            //if (string.IsNullOrEmpty(inputNoteAppreciation) || cbbx_Note_App.SelectedIndex == -1 || !Int32.TryParse(inputNoteAppreciation, out parsedNoteApp))
            //{
            //    erreur_NoteApp.Visibility = Visibility.Visible;
            //    erreur_NoteApp.Text = "Veuillez noter.";
            //    args.Cancel = true;
            //}
            //else
            //{
            //    erreur_NoteApp.Visibility = Visibility.Collapsed;
            //}

            if (!args.Cancel)
            {
                
                inputHeure = Heure;
            }


        }
        
        public DateTimeOffset DateOrg
        {
            get => inputDateOrg;
            set => inputDateOrg = value;
        }
        public string NbPlaces
        {
            get => parsedNbPlaces.ToString();
            set => parsedNbPlaces = Int32.Parse(value);
        }
        public TimeSpan Heure
        {
            get => inputHeure;
            set => inputHeure = value;
        }
        public int NoteAppreciation
        {
            get => parsedNoteApp;
            set => parsedNoteApp = value;
        }
    }
}
