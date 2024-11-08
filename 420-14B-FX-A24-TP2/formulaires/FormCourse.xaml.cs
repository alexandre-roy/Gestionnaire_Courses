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
        public const string cheminFichierCoureurs = @"C:\data\420-14B-FX\TP2\coureurs.csv";
        public const string cheminFichierCourses = @"C:\data\420-14B-FX\TP2\courses.csv";
        private Course _course;
        private EtatFormulaire _etat;
        private GestionCourse _gestionCourse;
        private MainWindow _mainWindow;
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
            _gestionCourse = new GestionCourse(cheminFichierCourses, cheminFichierCoureurs);
            txtTempsMoyen.IsEnabled = false;
            txtParticipants.IsEnabled = false;
            _mainWindow = new MainWindow();
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
                Course course = new Course(Guid.NewGuid(), txtNom.Text, DateOnly.FromDateTime(dpDate.SelectedDate.Value), txtVille.Text, (Province)cboProvince.SelectedItem, (TypeCourse)cboType.SelectedItem, ushort.Parse(txtDistance.Text));
                _gestionCourse.AjouterCourse(course);
                MessageBox.Show("Course ajoutée avec succès");
                _gestionCourse.EnregistrerCourses(cheminFichierCourses, cheminFichierCoureurs);
                _mainWindow.AfficherListeCourses();
                this.DialogResult = true;
                this.Close();
            }
            else if (btnConfirmation.Content.ToString() == "Modifier")
            {
                Course newcourse = new Course(_course.Id, txtNom.Text, DateOnly.FromDateTime(dpDate.SelectedDate.Value), txtVille.Text, (Province)cboProvince.SelectedItem, (TypeCourse)cboType.SelectedItem, ushort.Parse(txtDistance.Text));
                for (int i = 0; i < _gestionCourse.Courses.Count; i++)
                {
                    if (_gestionCourse.Courses[i].Id == newcourse.Id)
                    {
                        _gestionCourse.Courses[i] = newcourse;
                        break;
                    }
                }
                MessageBox.Show("Course modifiée avec succès");
                _gestionCourse.EnregistrerCourses(cheminFichierCourses, cheminFichierCoureurs);
                _mainWindow.AfficherListeCourses();
                this.DialogResult = true;
                this.Close();
            }
        }

        private void btnAnnuler_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
