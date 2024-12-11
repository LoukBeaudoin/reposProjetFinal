using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinal
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private XamlRoot XamlRoot;

        public MainWindow()
        {
            this.InitializeComponent();
            mainWindow.Navigate(typeof(PageActivites));
            //Authentification.getInstance().PropertyChanged += Authentification_PropertyChanged;
            //ModifierVisibilite();
        }

        private void navView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;

            switch (item.Name)
            {
                case "pageActivite":
                    mainWindow.Navigate(typeof(PageActivites));
                    break;
                case "pageAdmin":
                    mainWindow.Navigate(typeof(PageAdmin));
                    break;
                case "pageStats":
                    mainWindow.Navigate(typeof(PageStats));
                    break;
                default:
                    break;
            }
        }


        //private void Authentification_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName == nameof(Authentification.Connecter))
        //    {
        //        ModifierVisibilite();
        //    }
        //}

        //private void ModifierVisibilite()
        //{
        //    bool estConnecter = Authentification.getInstance().Connecter;
        //    if (estConnecter)
        //    {
        //        pageAdmin.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        pageAdmin.Visibility = Visibility.Collapsed;
        //    }
        //}

    }
}
