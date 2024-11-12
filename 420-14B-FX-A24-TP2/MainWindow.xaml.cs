using System.Windows;
using _420_14B_FX_A24_TP2.classes;
using _420_14B_FX_A24_TP2.enums;
using _420_14B_FX_A24_TP2.formulaires;

namespace _420_14B_FX_A24_TP2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region CONSTANTES

        /// <summary>
        /// Le chemin d'accès pour accèder au fichier des coureurs.
        /// </summary>
        public const string CHEMIN_FICHIER_COUREURS = @"C:\data\420-14B-FX\TP2\coureurs.csv";

        /// <summary>
        /// Le chemin d'accès pour accèder au fichier des courses.
        /// </summary>
        public const string CHEMIN_FICHIER_COURSES = @"C:\data\420-14B-FX\TP2\courses.csv";

        #endregion

        #region ATTRIBUTS

        private GestionCourse _gestionCourse;


        #endregion

        #region CONSTRUCTEUR
        public MainWindow()
        {
            _gestionCourse = new GestionCourse(CHEMIN_FICHIER_COURSES, CHEMIN_FICHIER_COUREURS);
            InitializeComponent();

        }

        #endregion

        #region WINDOW_LOADED
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AfficherListeCourses();

            FormCoureur blabla = new FormCoureur(EtatFormulaire.Ajouter);
            blabla.ShowDialog();
        }

        #endregion

        #region MÉTHODES

        public void AfficherListeCourses()
        {
            lstCourses.Items.Clear();
            for (int i = 0;i < _gestionCourse.Courses.Count; i++)
            {
                lstCourses.Items.Add(_gestionCourse.Courses[i]);
            }
        }

        #endregion

        #region ACTIONS-FORMULAIRE
        private void btnNouveau_Click(object sender, RoutedEventArgs e)
        {
            EtatFormulaire etat = EtatFormulaire.Ajouter;
            FormCourse formCourseWindow = new FormCourse(etat);
            formCourseWindow.ShowDialog();
            if (formCourseWindow.DialogResult == true)
            {
                for (int i = 0; i < _gestionCourse.Courses.Count; i++)
                {
                    if (Course.Equals(formCourseWindow.Course, _gestionCourse.Courses[i]))
                    {
                        MessageBox.Show("Impossible d'ajouter cette course car elle existe deja", "Ajout d'une Course", MessageBoxButton.OK);
                        return;
                    }
                }
                _gestionCourse.AjouterCourse(formCourseWindow.Course);
                MessageBox.Show("Course ajoutée avec succès");
                AfficherListeCourses();
                _gestionCourse.EnregistrerCourses(CHEMIN_FICHIER_COURSES, CHEMIN_FICHIER_COUREURS);
            }
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (lstCourses.SelectedItem != null)
            {
                EtatFormulaire etat = EtatFormulaire.Modifier;
                Course course = (Course)lstCourses.SelectedItem;
                FormCourse formCourseWindow = new FormCourse(etat,course);
                formCourseWindow.ShowDialog();
                if (formCourseWindow.DialogResult == true)
                {
                    MessageBox.Show("Course modifiée avec succès");
                    AfficherListeCourses();
                    _gestionCourse.EnregistrerCourses(CHEMIN_FICHIER_COURSES, CHEMIN_FICHIER_COUREURS);
                }
            }
            else
            {
                MessageBox.Show("Selectionner la course a modifier", "Modification d'une course");
                return;
            }
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            
        }

        #endregion
    }
}