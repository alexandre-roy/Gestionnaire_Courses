using _420_14B_FX_A24_TP2.classes;
using _420_14B_FX_A24_TP2.enums;
using System.Windows;
namespace _420_14B_FX_A24_TP2.formulaires
{
    /// <summary>
    /// Logique d'interaction pour FormCourse.xaml
    /// </summary>
    public partial class FormCourse : Window
    {
        #region ATTRIBUTS

        /// <summary>
        /// Champ pour stocker l'objet Course.
        /// </summary>
        private Course _course;

        /// <summary>
        /// Champ pour stocker l'etat du formulaire.
        /// </summary>
        private EtatFormulaire _etat;

        #endregion

        #region PROPRIÉTÉS

        /// <summary>
        /// Propriete qui permet d'obtenir et de definir l'etat du formulaire.
        /// </summary>
        public EtatFormulaire Etat
        {
            get { return _etat; }
            set
            {
                if (Enum.IsDefined(typeof(EtatFormulaire), value))
                {
                    _etat = value;
                }
            }
        }

        /// <summary>
        /// Propriete qui permet d'obtenier et de definir l'objet Course du formulaire.
        /// </summary>
        public Course Course
        {
            get { return _course; }
            set { _course = value; }
        }

        #endregion

        #region CONSTRUCTEUR

        /// <summary>
        /// Constructeur pour initialiser le formulaire avec l'etat et optionellement la course.
        /// </summary>
        /// <param name="etat"> Etat du formulaire, soit Ajouter ou Modifier</param>
        public FormCourse(EtatFormulaire etat, Course course = null)
        {
            InitializeComponent();
          
            Etat = etat;
            Course = course;                  
        }

        #endregion

        #region MÉTHODES

        /// <summary>
        /// Affiche la liste des coureurs.
        /// </summary>
        /// <param name="course">Une course</param>
        public void AfficherListeCoureurs(Course course = null)
        {
            if (course != null && course.Coureurs != null)
            {
                lstCoureurs.Items.Clear();
                Course.TrierCoureurs();
                for (int i = 0; i < course.Coureurs.Count; i++)
                {
                    lstCoureurs.Items.Add(course.Coureurs[i]);
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Valide les paramètres de la course.
        /// </summary>
        /// <returns>Un bool qui indique si la course est valide</returns>
        private bool ValidationAjout()
        {
            ushort distance;
            string message = "";
            if (!string.IsNullOrWhiteSpace(txtNom.Text.Trim()))
            {
                if (txtNom.Text.Trim().Length < Course.NOM_NB_CAR_MIN)
                {
                    message += $"Le nom de la course doit contenir au moins {Course.NOM_NB_CAR_MIN} caractères\n";
                }
            }
            else
            {
                message += "Le nom de la course ne peut pas etre null\n";
            }
            if (!string.IsNullOrWhiteSpace(txtVille.Text.Trim()))
            {
                if (txtVille.Text.Trim().Length < Course.VILLE_NB_CAR_MIN)
                {
                    message += $"Le nom de la ville doit contenir au moins {Course.VILLE_NB_CAR_MIN} caractères\n";
                }
            }
            else
            {
                message += "Le nom de la ville ne peut pas etre null\n";
            }
            if (dpDate.SelectedDate == null)
            {
                message += "Veuillez choisir une date pour la course\n";
            }

            if (ushort.TryParse(txtDistance.Text, out distance))
            {
                if (distance < Course.DISTANCE_VAL_MIN)
                {
                    message += $"La distance doit être supérieure à {Course.DISTANCE_VAL_MIN}.\n";
                }
            }
            else
            {
                message += "La distance ne peut pas etre nulle";
            }
            if (!string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show(message, "Erreur de parametre");
                return false;
            }
            return true;
        }

        #endregion

        #region ACTIONS-FORMULAIRE

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtTempsMoyen.IsEnabled = false;
            txtParticipants.IsEnabled = false;

            string[] provinces = UtilEnum.GetAllDescriptions<Province>();
            for (int i = 0; i < provinces.Length; i++)
            {
                cboProvince.Items.Add(provinces[i]);
            }

            string[] typeCourse = UtilEnum.GetAllDescriptions<Categorie>();
            for (int i = 0; i < typeCourse.Length; i++)
            {
                cboType.Items.Add(typeCourse[i]);
            }

            switch (Etat)
            {
                case EtatFormulaire.Ajouter:
                    tbTitre.Text = "Ajouter une course";
                    btnConfirmation.Content = "Ajouter";
                    break;

                case EtatFormulaire.Modifier:
                    if (Course != null)
                    {
                        tbTitre.Text = "Modification d'une course";
                        btnConfirmation.Content = "Modifier";
                        txtNom.Text = Course.Nom;
                        txtVille.Text = Course.Ville;
                        cboProvince.SelectedItem = Course.Province.GetDescription();
                        DateOnly dateOnly = Course.Date;
                        dpDate.SelectedDate = dateOnly.ToDateTime(TimeOnly.MinValue);
                        txtDistance.Text = Course.Distance.ToString();
                        txtParticipants.Text = Course.NbParticipants.ToString();
                        txtTempsMoyen.Text = Course.TempCourseMoyen.ToString(@"hh\:mm\:ss");
                    }
                    break;
                case EtatFormulaire.Supprimer:
                    if (Course != null)
                    {
                        tbTitre.Text = "Suppression d'une course";
                        btnConfirmation.Content = "Supprimer";
                        txtNom.Text = Course.Nom;
                        txtVille.Text = Course.Ville;
                        cboProvince.SelectedItem = Course.Province.GetDescription();
                        DateOnly dateOnly = Course.Date;
                        dpDate.SelectedDate = dateOnly.ToDateTime(TimeOnly.MinValue);
                        txtDistance.Text = Course.Distance.ToString();
                        txtParticipants.Text = Course.NbParticipants.ToString();
                        txtTempsMoyen.Text = Course.TempCourseMoyen.ToString(@"hh\:mm\:ss");

                        txtNom.IsEnabled = false;
                        txtVille.IsEnabled = false;
                        txtDistance.IsEnabled = false;
                        cboProvince.IsEnabled = false;
                        dpDate.IsEnabled = false;
                        cboType.IsEnabled = false;
                    }
                    break;
            }

            AfficherListeCoureurs(Course);
        }

        private void btnConfirmation_Click_1(object sender, RoutedEventArgs e)
        {
            if (btnConfirmation.Content.ToString() == "Ajouter")
            {
                if (ValidationAjout())
                {
                    Course = new Course(Guid.NewGuid(), txtNom.Text, DateOnly.FromDateTime(dpDate.SelectedDate.Value), txtVille.Text, (Province)cboProvince.SelectedItem, (TypeCourse)cboType.SelectedItem, ushort.Parse(txtDistance.Text));
                    this.DialogResult = true;
                }
                else
                {
                    return;
                }
            }
            else if (btnConfirmation.Content.ToString() == "Modifier")
            {
                if (ValidationAjout())
                {
                    Course.Nom = txtNom.Text;
                    Course.Ville = txtVille.Text;
                    Course.Province = (Province)cboProvince.SelectedItem;
                    Course.Date = DateOnly.FromDateTime(dpDate.SelectedDate.Value);
                    Course.TypeCourse = (TypeCourse)cboType.SelectedItem;
                    Course.Distance = ushort.Parse(txtDistance.Text);
                    this.DialogResult = true;
                }
                else
                {
                    return;
                }
            }
            else if (btnConfirmation.Content.ToString() == "Supprimer")
            {
                if (ValidationAjout())
                {
                    MessageBoxResult reponse = MessageBox.Show($"Êtes-vous certain de vouloir supprimer la course ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    switch (reponse)
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
        }

        private void btnAnnuler_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnAjouterCoureur_Click(object sender, RoutedEventArgs e)
        {
            FormCoureur formCoureurWindow = new FormCoureur(EtatFormulaire.Ajouter);
            formCoureurWindow.ShowDialog();
            if (formCoureurWindow.DialogResult == true)
            {
                //for (int i = 0; i < Course.Coureurs.Count; i++)
                //{
                //    if (Coureur.Equals(formCoureurWindow.Coureur, Coureur[i]))
                //    {
                //        MessageBox.Show("Impossible d'ajouter ce coureur car elle existe deja", "Ajout d'un coureur", MessageBoxButton.OK);
                //        return;
                //    }
                //}
                AfficherListeCoureurs();
                MessageBox.Show("Le coureur a été ajouté avec succès.", "Ajout d'un coureur", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnModifierCoureur_Click(object sender, RoutedEventArgs e)
        {
            if (lstCoureurs.SelectedItem != null)
            {
                EtatFormulaire etat = EtatFormulaire.Modifier;
                Coureur coureur = (Coureur)lstCoureurs.SelectedItem;
                FormCoureur formCoureurWindow = new FormCoureur(etat, coureur);
                formCoureurWindow.ShowDialog();
                if (formCoureurWindow.DialogResult == true)
                {
                    MessageBox.Show("Coureur modifiée avec succès", "Modification d'un coureur", MessageBoxButton.OK, MessageBoxImage.Information);
                    AfficherListeCoureurs();
                }
            }
            else
            {
                MessageBox.Show("Selectionner le coureur a modifier", "Modification d'un coureur");
                return;
            }
        }

        private void btnSupprimerCoureur_Click(object sender, RoutedEventArgs e)
        {
            if (lstCoureurs.SelectedItem != null)
            {
                Coureur coureur = (Coureur)lstCoureurs.SelectedItem;
                EtatFormulaire etat = EtatFormulaire.Supprimer;               
                FormCoureur formCoureurWindow = new FormCoureur(etat, coureur);
                formCoureurWindow.ShowDialog();
                if (formCoureurWindow.DialogResult == true)
                {
                    Course.SupprimerCoureur(coureur);
                    AfficherListeCoureurs();
                    MessageBox.Show("Le coureur a été supprimée avec succès.", "Suppression d'un coureur", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        #endregion
    }
}
