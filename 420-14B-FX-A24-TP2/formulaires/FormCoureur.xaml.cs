using System.Windows;
using _420_14B_FX_A24_TP2.classes;
using _420_14B_FX_A24_TP2.enums;

namespace _420_14B_FX_A24_TP2.formulaires
{
    /// <summary>
    /// Logique d'interaction pour FormCoureur.xaml
    /// </summary>
    public partial class FormCoureur : Window
    {
        #region ATTRIBUTS 

        /// <summary>
        /// Champ pour stocker l'objet Coureur.
        /// </summary>
        private Coureur _coureur;

        /// <summary>
        /// L'état du formulaire.
        /// </summary>
        EtatFormulaire _etat;

        #endregion

        #region PROPRIÉTÉS

        /// <summary>
        /// Obtient ou définis l'état du formulaire.
        /// </summary>
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

        /// <summary>
        /// Propriete qui permet d'obtenier et de definir l'objet Coureur du formulaire.
        /// </summary>
        public Coureur Coureur
        {
            get { return _coureur; }
            set { _coureur = value; }
        }

        #endregion

        #region CONSTRUCTEUR

        /// <summary>
        /// Constructeur pour initialiser le formulaire avec l'etat et optionellement le coureur.
        /// </summary>
        /// <param name="etat"></param>
        /// <param name="coureur"></param>
        public FormCoureur(EtatFormulaire etat, Coureur coureur = null)
        {
            InitializeComponent();

            Etat = etat;     
            Coureur = coureur;
        }

        #endregion

        #region MÉTHODES

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

        #endregion

        #region ACTIONS-FORMULAIRE
        private void Window_Loaded(object sender, RoutedEventArgs e)
        { 
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

            switch (Etat)
            {
                case EtatFormulaire.Ajouter:
                    tbTitre.Text = "Ajouter un coureur";
                    btnConfirmation.Content = "Ajouter";
                    cboCategorie.SelectedItem = Coureur.Categorie.GetDescription();
                    cboProvince.SelectedItem = Coureur.Province.GetDescription();
                    break;

                case EtatFormulaire.Modifier:
                    tbTitre.Text = "Modification d'un coureur";
                    btnConfirmation.Content = "Modifier";
                    txtDossard.Text = Coureur.Dossard.ToString();
                    txtNom.Text = Coureur.Nom;
                    txtPrenom.Text = Coureur.Prenom;
                    txtVille.Text = Coureur.Ville;
                    cboCategorie.SelectedItem = Coureur.Categorie.GetDescription();
                    cboProvince.SelectedItem = Coureur.Province.GetDescription();
                    tsTemps.Text = Coureur.Temps.ToString();

                    txtDossard.IsEnabled = false;
                    break;

                case EtatFormulaire.Supprimer:
                    tbTitre.Text = "Suppression d'un coureur";
                    btnConfirmation.Content = "Supprimer";
                    txtDossard.Text = Coureur.Dossard.ToString();
                    txtNom.Text = Coureur.Nom;
                    txtPrenom.Text = Coureur.Prenom;
                    txtVille.Text = Coureur.Ville;
                    cboCategorie.SelectedItem = Coureur.Categorie.GetDescription();
                    cboProvince.SelectedItem = Coureur.Province.GetDescription();
                    tsTemps.Text = Coureur.Temps.ToString();

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

        private void btnConfirmation_Click(object sender, RoutedEventArgs e)
{
            if (btnConfirmation.Content.ToString() == "Ajouter")
            {        
                if (ValiderCoureur() == "")
                {
                    if (ushort.TryParse(txtDossard.Text, out ushort dossard)) 
                    {
                        Coureur nouveauCoureur = new Coureur(ushort.Parse(txtDossard.Text), txtNom.Text, txtPrenom.Text, (Categorie)cboCategorie.SelectedItem, txtVille.Text, (Province)cboProvince.SelectedItem, tsTemps.Value.Value);
                        nouveauCoureur.Rang = 0;
                        if (chkAbandon.IsChecked == true)
                        {
                            nouveauCoureur.Abandon = true;
                        }
                        this.DialogResult = true;
                    }
                    else
                    {
                        MessageBox.Show("Le numéro de dossard est invalide. Veuillez entrer un nombre valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    this.DialogResult = true;
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
                        Coureur.Dossard = ushort.Parse(txtDossard.Text);
                        Coureur.Nom = txtNom.Text;
                        Coureur.Prenom = txtPrenom.Text;
                        string categorie = cboCategorie.SelectedItem.ToString();
                        if (Enum.TryParse(categorie, out Categorie selectedCategorie))
                        {
                            Coureur.Categorie = selectedCategorie;
                        }
                        Coureur.Ville = txtVille.Text;
                        Coureur.Rang = 0;
                        string province = cboProvince.SelectedItem.ToString();
                        if (Enum.TryParse(province, out Province selectedProvince))
                        {
                            Coureur.Province = selectedProvince;
                        }
                        Coureur.Temps = tsTemps.Value.Value;
                        if (chkAbandon.IsChecked == true)
                        {
                            Coureur.Abandon = true;
                        }
                        this.DialogResult = true;
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
                        this.DialogResult = true;
                        break;
                    case MessageBoxResult.No:
                        this.DialogResult = false;
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
