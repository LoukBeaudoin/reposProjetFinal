using Microsoft.UI.Xaml.Controls;
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
using static System.Net.Mime.MediaTypeNames;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinal
{
    public sealed partial class SessionAdherent : ContentDialog
    {
        public SessionAdherent()
        {
            this.InitializeComponent();
        }



        private void ContentDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            string identifiant = tbx_identifiantsession.Text;
            if (args.Result == ContentDialogResult.Primary)
            {
                args.Cancel = true;

                if (Authentification.getInstance().Connecter)
                {
                    erreurIdentifiant.Text = "Veuillez vous déconnecter de administrateur!";
                }
                 else if (string.IsNullOrWhiteSpace(identifiant))
                {
                    erreurIdentifiant.Text = "Le champs Identifiant ne peut pas être vide!";
                }
                else
                {

                    try
                    {
                        string idIdentifiant = SingletonBD.getInstance().getIdentifiantSession(identifiant);

                        if (!string.IsNullOrEmpty(idIdentifiant))
                        {
                            //erreurIdentifiant.Text = "";
                            args.Cancel = false;
                            Adherent adherent = new Adherent(idIdentifiant);
                            Adherent.CurrentAdherent = adherent;


                        }
                        else
                        {
                            erreurIdentifiant.Text = "L'identifiant est incorrect!";
                        }



                    }
                    catch (Exception ex)
                    {
                        erreurIdentifiant.Text = "Une Erreur c'est produit";
                    }
                }

            }
            if (args.Result == ContentDialogResult.Secondary)
            {
                Adherent adherent = new Adherent();
                Adherent.CurrentAdherent = adherent;
            }
        }


        private void tbx_identifiantsession_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbx_identifiantsession.Text))
            {
                erreurIdentifiant.Text = "";
            }
        }




    }
}
