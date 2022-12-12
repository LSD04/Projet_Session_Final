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
    public sealed partial class CreerCompte : Page
    {
        public CreerCompte()
        {
            this.InitializeComponent();
        }
        private void reset()
        {
            ErreurN.Visibility = Visibility.Collapsed;
            ErreurP.Visibility = Visibility.Collapsed;
            ErreurC.Visibility = Visibility.Collapsed;
            ErreurM.Visibility = Visibility.Collapsed;
            ErreurT.Visibility = Visibility.Collapsed;
            ErreurCA.Visibility = Visibility.Collapsed;


            n.Text = " ";
            p.Text = " ";
            c.Text = " ";
            m.Text = " ";
            t.Text = " ";
            ca.Text = " ";

        }
        private void Creer_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;

            if (n.Text.Trim() == "")
            {
                ErreurN.Visibility = Visibility.Visible;
                valide = false;
            }
            else
            {
                ErreurN.Visibility = Visibility.Collapsed;
                valide = true;
            }

            if (p.Text.Trim() == "")
            {
                ErreurP.Visibility = Visibility.Visible;
                valide = false;
            }
            else
            {
                ErreurP.Visibility = Visibility.Collapsed;
                valide = true;
            }
            if (c.Text.Trim() == "")
            {
                ErreurC.Visibility = Visibility.Visible;
                valide = false;
            }
            else
            {
                ErreurC.Visibility = Visibility.Collapsed;
                valide = true;
            }
            if (m.Text.Trim() == "")
            {
                ErreurM.Visibility = Visibility.Visible;
                valide = false;
            }
            else
            {
                ErreurM.Visibility = Visibility.Collapsed;
                valide = true;
            }
            if (t.Text.Trim() == "")
            {
                ErreurT.Visibility = Visibility.Visible;
                valide = false;
            }
            else
            {
                ErreurT.Visibility = Visibility.Collapsed;
                valide = true;
            }
            if (ca.Text.Trim() == "")
            {
                ErreurCA.Visibility = Visibility.Visible;
                valide = false;
            }
            else
            {
                ErreurCA.Visibility = Visibility.Collapsed;
                valide = true;
            }


            if (valide == true)
            {
                User cc = new User()
                {
                    Categorie = Convert.ToString(ca.Text),
                    Nom = Convert.ToString(n.Text),
                    Prenom = Convert.ToString(p.Text),
                    Courriel = Convert.ToString(c.Text),
                    MotDePasse = Convert.ToString(m.Text),
                    NoTelephone = Convert.ToString(t.Text),
                };

                GestionBD.getInstance().insererUser(cc);

                reset();
            }

        }
    }
}
