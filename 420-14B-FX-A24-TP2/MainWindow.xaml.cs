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

        /// <summary>
        /// Le gestionnaire de course.
        /// </summary>
        private GestionCourse _gestionCourse;

        #endregion

        #region CONSTRUCTEUR

        public MainWindow()
        {
            _gestionCourse = new GestionCourse(CHEMIN_FICHIER_COURSES, CHEMIN_FICHIER_COUREURS);
            InitializeComponent();
        }

        #endregion

        #region MÉTHODES    

        /// <summary>
        /// Affiche la liste des courses.
        /// </summary>
        public void AfficherListeCourses()
        {
            lstCourses.Items.Clear();
            _gestionCourse.Courses.Sort();
            for (int i = 0;i < _gestionCourse.Courses.Count; i++)
            {
                lstCourses.Items.Add(_gestionCourse.Courses[i]);
            }
        }

        #endregion

        #region ACTIONS-FORMULAIRE

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AfficherListeCourses();
        }

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
                        MessageBox.Show("Impossible d'ajouter cette course, car elle existe déja.", "Ajout d'une Course", MessageBoxButton.OK);
                        return;
                    }
                }
                _gestionCourse.AjouterCourse(formCourseWindow.Course);
                AfficherListeCourses();
                MessageBox.Show("Course ajoutée avec succès!", "Ajout d'une course", MessageBoxButton.OK);
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
                    int pareil = 0;
                    for (int i = 0; i < _gestionCourse.Courses.Count; i++)
                    {
                        if (Course.Equals(formCourseWindow.Course, _gestionCourse.Courses[i]))
                        {
                            pareil++;
                            if (pareil > 1)
                            {
                                MessageBox.Show("Impossible de modifier cette course, car elle existe déja.", "Ajout d'une Course", MessageBoxButton.OK);
                                
                            }                            
                        }
                    }
                    AfficherListeCourses();
                    MessageBox.Show("Course modifiée avec succès!", "Modification d'une course", MessageBoxButton.OK);
                    _gestionCourse.EnregistrerCourses(CHEMIN_FICHIER_COURSES, CHEMIN_FICHIER_COUREURS);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une course à modifier.", "Modification d'une course");
                return;
            }
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (lstCourses.SelectedItem != null)
            {
                EtatFormulaire etat = EtatFormulaire.Supprimer;
                Course course = (Course)lstCourses.SelectedItem;
                FormCourse formCourseWindow = new FormCourse(etat, course);
                formCourseWindow.ShowDialog();
                if (formCourseWindow.DialogResult == true)
                {
                    _gestionCourse.SupprimerCourse(course);
                    AfficherListeCourses();
                    MessageBox.Show("Course supprimée avec succès!", "Suppression d'une course", MessageBoxButton.OK);
                    _gestionCourse.EnregistrerCourses(CHEMIN_FICHIER_COURSES, CHEMIN_FICHIER_COUREURS);
                }
            }
        }
        #endregion
    }
}