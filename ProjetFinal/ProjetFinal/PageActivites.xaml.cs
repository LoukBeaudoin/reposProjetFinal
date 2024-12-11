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
    public sealed partial class PageActivites : Page
    {
        public PageActivites()
        {
            this.InitializeComponent();
            //this.DataContext = SingletonBD.getInstance();
            SingletonBD.getInstance().getActiviteAccueil();
            SingletonBD.getInstance().getAdherentAccueil();
        }

        public ObservableCollection<Activite> Liste
        {
            get { return SingletonBD.getInstance().Liste; }
        }

        private async void btn_test_Click(object sender, RoutedEventArgs e)
        {
            MonDialogue dialog = new MonDialogue();
            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Authentification";
            dialog.PrimaryButtonText = "Se Connecter";
            dialog.SecondaryButtonText = "Déconnexion";
            dialog.CloseButtonText = "Annuler";
            dialog.DefaultButton = ContentDialogButton.Close;
            ContentDialogResult resultat = await dialog.ShowAsync();
        }

        //public ObservableCollection<Adherent> ListeAdherent
        //{
        //    get { return SingletonBD.getInstance().ListeAdherent; }
        //}


    }
}
