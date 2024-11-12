using _420_14B_FX_A24_TP2.classes;
using _420_14B_FX_A24_TP2.enums;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _420_14B_FX_A24_TP2.formulaires
{
    /// <summary>
    /// Logique d'interaction pour FormCourse.xaml
    /// </summary>
    public partial class FormCourse : Window
    {
        /// <summary>
        /// Champ pour stocker l'objet Course
        /// </summary>
        private Course _course;

        /// <summary>
        /// Champ pour stocker l'etat du formulaire
        /// </summary>
        private EtatFormulaire _etat;

        /// <summary>
        /// Propriete qui permet d'obtenir et de definir l'etat du formulaire
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
        /// Propriete qui permet d'obtenier et de definir l'object Course du formulaire
        /// </summary>
        public Course Course
        {
            get { return _course; }
            set { _course = value; }
        }

        /// <summary>
        /// Constructeur pour initialiser le formulaire avec l'etat et optionellement la course
        /// </summary>
        /// <param name="etat"> Etat du formulaire, soit Ajouter ou Modifier</
        public FormCourse(EtatFormulaire etat, Course course = null)
        {
            InitializeComponent();
            txtTempsMoyen.IsEnabled = false;
            txtParticipants.IsEnabled = false;
       
            cboProvince.ItemsSource = Enum.GetValues(typeof(Province));
            cboType.ItemsSource = Enum.GetValues(typeof(TypeCourse));
            Etat = etat;
            Course = course;
            AfficherListeCoureurs(course);
            switch (etat)
            {
                case EtatFormulaire.Ajouter:
                    tbTitre.Text = "Ajouter une course";
                    btnConfirmation.Content = "Ajouter";
                    break;

                case EtatFormulaire.Modifier:
                    if (course != null)
                    {
                        tbTitre.Text = "Modification d'une course";
                        btnConfirmation.Content = "Modifier";
                        txtNom.Text = course.Nom;
                        txtVille.Text = course.Ville;
                        cboProvince.Text = course.Province.ToString();
                        DateOnly dateOnly = course.Date;
                        dpDate.SelectedDate = dateOnly.ToDateTime(TimeOnly.MinValue);
                        txtDistance.Text = course.Distance.ToString();
                    }
                    break;
            }
        }

        public void AfficherListeCoureurs(Course course = null)
        {

            if (course != null && course.Coureurs != null)
            {
                lstCoureurs.Items.Clear();
                course.Coureurs.Sort();
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
        }

        private void btnAnnuler_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private bool ValidationAjout()
        {
            ushort distance;
            string message ="";
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
    }
}
