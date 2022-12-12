using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
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

namespace Projet_session2
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            this.InitializeComponent();
            mainFrame.Navigate(typeof(Connexion));
        }

    

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {

            var item = (NavigationViewItem)args.SelectedItem;
            Header.Text = item.Tag.ToString();

            switch (item.Content)
            {
                case "Ajouter Villes":
                    mainFrame.Navigate(typeof(AjouterVille));
                    break;
                case "Trajets en cours":
                    mainFrame.Navigate(typeof(TrajetEnCours));
                    break;
                case "Recherche trajets":
                    mainFrame.Navigate(typeof(RechercheTrajet));
                    break;
                case "Afficher montant":
                    mainFrame.Navigate(typeof(AfficherMontant));
                    break;
                case "Creer un tajet":
                    mainFrame.Navigate(typeof(CreerTrajet));
                    break;
                case "Historique":
                    mainFrame.Navigate(typeof(AfficherTrajet));
                    break;
                case "S'inscrire":
                    mainFrame.Navigate(typeof(Inscription));
                    break;
                default:
                    break;
            }
        }
       
    }
}
