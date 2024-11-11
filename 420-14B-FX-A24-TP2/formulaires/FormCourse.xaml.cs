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
        private Course _course;
        private EtatFormulaire _etat;
      
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

        public Course Course
        {
            get { return _course; }
            set { _course = value; }
        }

        public FormCourse(EtatFormulaire etat, Course course = null)
        {
            InitializeComponent();
            txtTempsMoyen.IsEnabled = false;
            txtParticipants.IsEnabled = false;
       
            cboProvince.ItemsSource = Enum.GetValues(typeof(Province));
            cboType.ItemsSource = Enum.GetValues(typeof(TypeCourse));
            Etat = etat;
            Course = course;
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

        private void btnConfirmation_Click_1(object sender, RoutedEventArgs e)
        {         
            if (btnConfirmation.Content.ToString() == "Ajouter")
            {
                if (ValidationAjout())
                {
                    try
                    {
                        Course = new Course(Guid.NewGuid(), txtNom.Text, DateOnly.FromDateTime(dpDate.SelectedDate.Value), txtVille.Text, (Province)cboProvince.SelectedItem, (TypeCourse)cboType.SelectedItem, ushort.Parse(txtDistance.Text));
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("Erreur lors de la création de la course");
                    }
                }
                this.DialogResult = true;F
            }
            else if (btnConfirmation.Content.ToString() == "Modifier")
            {
                Course.Nom = txtNom.Text;
                Course.Ville = txtVille.Text;
                Course.Province = (Province)cboProvince.SelectedItem;
                Course.Date = DateOnly.FromDateTime(dpDate.SelectedDate.Value);
                Course.TypeCourse = (TypeCourse)cboType.SelectedItem;
                Course.Distance = ushort.Parse(txtDistance.Text);
                this.DialogResult = true;
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
            if (!ushort.TryParse(txtDistance.Text, out distance))
            {
                if (distance < Course.DISTANCE_VAL_MIN)
                {
                    message += $"La distance doit être supérieure à {Course.DISTANCE_VAL_MIN}.\n";
                }
            }
            else
            {
                message += "La distance ne peut pas etre null";
            }
            if (!string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show(message);
                return false;
            }
            return true;
        }
    }
}
