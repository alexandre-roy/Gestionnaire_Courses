using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents.Serialization;
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

            string[] provinces = UtilEnum.GetAllDescriptions<Province>();
            for (int i = 0; i < provinces.Length; i++)
            {
                cboProvince.Items.Add(provinces[i]);
            }

            string[] categories = UtilEnum.GetAllDescriptions<Categorie>();
            for (int i = 0; i < categories.Length; i++)
            {
                cboCategorie.Items.Add(categories[i]);
            }
        }

        private void btnConfirmation_Click(object sender, RoutedEventArgs e)
{
        if (btnConfirmation.Content.ToString() == "Ajouter")
        {        
            if (ValiderCoureur() == "")
            {
                if (ushort.TryParse(txtDossard.Text, out ushort dossard)) 
                {
                    Coureur nouveauCoureur = new Coureur();
                    nouveauCoureur.Dossard = ushort.Parse(txtDossard.Text);
                    nouveauCoureur.Nom = txtNom.Text;
                    nouveauCoureur.Prenom = txtPrenom.Text;
                    nouveauCoureur.Categorie = (Categorie)cboCategorie.SelectedItem;
                    nouveauCoureur.Ville = txtVille.Text;
                    nouveauCoureur.Rang = 0;
                    nouveauCoureur.Province = (Province)cboProvince.SelectedItem;
                    nouveauCoureur.Temps = tsTemps.Value.Value;
                    if (chkAbandon.IsChecked == true)
                    {
                        nouveauCoureur.Abandon = true;
                    }
                    MessageBox.Show("Le coureur a été ajouté avec succès.", "Ajout d'un coureur", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Le numéro de dossard est invalide. Veuillez entrer un nombre valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
              MessageBox.Show(ValiderCoureur(), "Ajout d'un coureur");
            }         
        }
            else if (btnConfirmation.Content.ToString() == "Modifier")
            {
                if (ValiderCoureur() == "")
                {
                    if (ushort.TryParse(txtDossard.Text, out ushort dossard))
                    {
                        
                        //.Dossard = ushort.Parse(txtDossard.Text);
                        //.Nom = txtNom.Text;
                        //.Prenom = txtPrenom.Text;
                        //.Categorie = (Categorie)cboCategorie.SelectedItem;
                        //.Ville = txtVille.Text;
                        //.Rang = 0;
                        //.Province = (Province)cboProvince.SelectedItem;
                        //.Temps = tsTemps.Value.Value;
                        if (chkAbandon.IsChecked == true)
                        {
                            //.Abandon = true;
                        }
                        MessageBox.Show("Le coureur a été ajouté avec succès.", "Modification d'un coureur", MessageBoxButton.OK);
                    }
                    else
                    {
                        MessageBox.Show("Le numéro de dossard est invalide. Veuillez entrer un nombre valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show(ValiderCoureur(), "Modification d'un coureur");
                }
            }
        else if (btnConfirmation.Content.ToString() == "Supprimer")
        {
            MessageBoxResult resultat = MessageBox.Show("Désirez-vous vraiment supprimer ce coureur?", "Suppression d'un coureur", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

            switch (resultat)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Le coureur a été supprimé avec succès", "Suppression d'un coureur", MessageBoxButton.OK);
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
                }
            }
        }

        private string ValiderCoureur()
        {
            string messageErreur = "";

            if (string.IsNullOrWhiteSpace(txtDossard.Text))
            {
                messageErreur += "Vous devez inscrire le dossard du coureur.\n";
            }

            if (string.IsNullOrWhiteSpace(txtDossard.Text) || ushort.Parse(txtDossard.Text) < Coureur.DOSSARD_VAL_MIN)
            {
                messageErreur += $"Le dossard doit être une valeur supérieure ou égale à {Coureur.DOSSARD_VAL_MIN}.\n";
            }

            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                messageErreur += "Vous devez inscrire le nom du client.\n";
            }

            if (txtNom.Text.Length < Coureur.NOM_NB_CARC_MIN)
            {
                messageErreur += $"Le nom doit contenir au moins {Coureur.NOM_NB_CARC_MIN} caractères.\n";
            }

            if (string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                messageErreur += "Vous devez inscrire le prénom du client.\n";
            }

            if (txtPrenom.Text.Length < Coureur.PRENOM_NB_CARC_MIN)
            {
                messageErreur += $"Le prénom doit contenir au moins {Coureur.PRENOM_NB_CARC_MIN} caractères.\n";
            }

            if (string.IsNullOrWhiteSpace(txtVille.Text))
            {
                messageErreur += "Vous devez inscrire la ville du coureur.\n";
            }

            if (txtVille.Text.Length < Coureur.VILLE_NB_CARC_MIN)
            {
                messageErreur += $"La ville doit contenir au moins {Coureur.VILLE_NB_CARC_MIN} caractères.\n";
            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(cboProvince.SelectedItem)))
            {
                messageErreur += "Vous devez sélectionner une province.\n";
            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(cboCategorie.SelectedItem)))
            {
                messageErreur += "Vous devez sélectionner une catégorie.\n";
            }

            return messageErreur;          
        }

        private void btnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }        

        private void chkAbandon_Checked(object sender, RoutedEventArgs e)
        {
            tsTemps.Value = TimeSpan.Zero;
            tsTemps.IsEnabled = false;    
        }        

        private void chkAbandon_Unchecked(object sender, RoutedEventArgs e)
        {
            tsTemps.IsEnabled = true;
        }

        #endregion
    }
}
