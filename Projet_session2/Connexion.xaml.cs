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

namespace Projet_session2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Connexion : Page
    {
        public Connexion()
        {
            this.InitializeComponent();
            liste.ItemsSource = GestionBD.getInstance().getTrajet();

        }


        private void Logup_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreerCompte));
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;

            if (username.Text.Trim() == "")
            {
                erreurUser.Visibility = Visibility.Visible;
                valide = false;
            }
            else
            {
                erreurUser.Visibility = Visibility.Collapsed;
                valide = true;
            }

            if (password.Password.Trim() == "")
            {
                erreurMdp.Visibility = Visibility.Visible;
                valide = false;
            }
            else
            {
                erreurMdp.Visibility = Visibility.Collapsed;
                valide = true;
            }


            if (valide == true)
            {

                if (GestionBD.getInstance().IsValid(username.Text, password.Password) == true) {
                    if (GestionBD.getInstance().Categorie == "admin")
                    {
                        this.Frame.Navigate(typeof(TrajetEnCours));

                    }
                    else if (GestionBD.getInstance().Categorie == "chauffeur")
                    {
                        this.Frame.Navigate(typeof(CreerTrajet));
                    }
                    else
                    {
                        this.Frame.Navigate(typeof(Inscription));
                    }
                    //reset();
                }
            }
        }
    }
}
