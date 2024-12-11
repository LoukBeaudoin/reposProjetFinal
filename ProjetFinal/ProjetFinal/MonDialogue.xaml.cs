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
    public sealed partial class MonDialogue : ContentDialog
    {
        public String Nom { get; set; }
        public String Mdp { get; set; }

        bool fermer = false;

        //public bool connecter = false;

        public MonDialogue()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            

        }

        private void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
                string Nom = tbx_user.Text;
                string Mdp = pwd_user.Password;
            if (args.Result == ContentDialogResult.Primary)
            {
                args.Cancel = true;
                if (string.IsNullOrWhiteSpace(Nom))
                {
                    erreurnom.Text = "Le champs Identifiant ne peut pas être vide!";
                }
                if (string.IsNullOrWhiteSpace(Mdp))
                {
                    erreurmdp.Text = "Le champs Mot de passe ne peut pas être vide!";
                }
                else
                {
                    bool authentification = SingletonBD.getInstance().Connexion(Nom, Mdp);

                    if (authentification)
                    {
                        args.Cancel = false;
                        Authentification.getInstance().Connecter = true;
                    }
                    else
                    {
                        erreurmdp.Text = "L'identifiant ou le mot de passe est incorrect";
                    }      
                }


            }
            if (args.Result == ContentDialogResult.Secondary)
            {
                Authentification.getInstance().Connecter = false;
            }

        }

        private void pwd_user_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pwd_user.Password))
            {
                erreurmdp.Text = "";
            }
        }

        private void tbx_user_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbx_user.Text))
            {
                erreurnom.Text = "";
            }
        }
    }
}
