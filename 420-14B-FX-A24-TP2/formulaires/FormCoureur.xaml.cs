using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using _420_14B_FX_A24_TP2.classes;
using _420_14B_FX_A24_TP2.enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _420_14B_FX_A24_TP2.formulaires
{
    /// <summary>
    /// Logique d'interaction pour FormCoureur.xaml
    /// </summary>
    public partial class FormCoureur : Window
    {
        #region ATTRIBUTS 

        EtatFormulaire _etat;

        #endregion

        #region PROPRIÉTÉS

        public EtatFormulaire Etat
        {
            get { return _etat; }
            set {
                if (Enum.IsDefined(typeof(EtatFormulaire), value))
                {
                    _etat = value;
                }
            }
        }

        #endregion

        #region CONSTRUCTEUR

        public FormCoureur(EtatFormulaire etat)
        {
            InitializeComponent();

            Etat = etat;

            switch (etat)
            {
                case EtatFormulaire.Ajouter:
                    tbTitre.Text = "Ajouter un coureur";
                    btnConfirmation.Content = "Ajouter";
                    
                    break;

                case EtatFormulaire.Modifier:
                    tbTitre.Text = "Modification d'un coureur";
                    btnConfirmation.Content = "Modifier";
                    break;

                case EtatFormulaire.Supprimer:
                    tbTitre.Text = "Suppression d'un coureur";
                    btnConfirmation.Content = "Supprimer";
                    txtDossard.IsEnabled = false;
                    txtNom.IsEnabled = false;
                    txtPrenom.IsEnabled = false;
                    txtVille.IsEnabled = false;
                    cboCategorie.IsEnabled = false;
                    cboProvince.IsEnabled = false;
                    tsTemps.IsEnabled = false;
                    chkAbandon.IsEnabled = false;
                    break;
            }         
        }

        #endregion

        #region ACTIONS-FORMULAIRE
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
        }
        
        private void btnConfirmation_Click(object sender, RoutedEventArgs e)
        {
            if (btnConfirmation.Content == "Ajouter")
            {
                Coureur nouveauCoureur = new Coureur();

                //nouveauCoureur.Dossard = ushort.Parse(txtDossard.Text);
                //nouveauCoureur.Nom = txtNom.Text;
                //nouveauCoureur.Prenom = txtPrenom.Text;
                //nouveauCoureur.Categorie = ;
                //nouveauCoureur.Ville = txtVille.Text;
                //nouveauCoureur.Province = ;
                //nouveauCoureur.Temps = 
                //nouveauCoureur.Rang = ;
                //nouveauCoureur.Abandon = ;
            }
            else if (btnConfirmation.Content == "Modifier")
            {
                
            }
            else if (btnConfirmation.Content == "Supprimer")
            {
                MessageBoxResult resultat = MessageBox.Show("Désirez-vous vraiment supprimer ce coureur?", "Suppression d'un coureur", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

                switch (resultat)
                {
                    case MessageBoxResult.Yes:
                        MessageBox.Show("Le coureur a été supprimé avec succès", "Suppression d'un coureur", MessageBoxButton.OK, MessageBoxImage.Information);
                        //Code pour suppression
                        this.Close();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
                
            }
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }        

        private void chkAbandon_Checked(object sender, RoutedEventArgs e)
        {
            tsTemps.IsEnabled = false;    
        }        

        private void chkAbandon_Unchecked(object sender, RoutedEventArgs e)
        {
            tsTemps.IsEnabled = true;
        }

        #endregion
    }
}
