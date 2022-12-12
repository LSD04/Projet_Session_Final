using Google.Protobuf.WellKnownTypes;
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
    public sealed partial class CreerTrajet : Page
    {

        bool valide = true;
        public CreerTrajet()
        {
            this.InitializeComponent();
            villeDepart.ItemsSource = GestionBD.getInstance().AfficherVille();
            villeArrive.ItemsSource = GestionBD.getInstance().AfficherVille();
        }


        private void creer_Click(object sender, RoutedEventArgs e)
        {
            try
            {   
                if (valide == true)
                {


                    Trajet t = new Trajet
                    {

                        HeureDepart = heureDepart.Time.ToString(),
                        HeureArrivee = heureArrive.Time.ToString(),
                        VilleDepart = villeDepart.SelectedItem.ToString(),
                        VilleArrivee = villeArrive.SelectedItem.ToString(),
                        Date = date.Date.Value.ToString("yyyy-MM-dd"),
                        Arret= arret.SelectedItem.ToString(),
                        Montant = Convert.ToInt32(montant.Text),
                        Vehicule = vehicule.SelectedItem.ToString(),
                        NbrPlace = Convert.ToInt32(nbrPlace.Text)

                    };

                    GestionBD.getInstance().ajouter_trajet(t);
                }
            }
            catch (FormatException ex)
            {
                
            }
        }   
    }
}
