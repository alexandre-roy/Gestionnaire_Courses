using System.Windows;
using _420_14B_FX_A24_TP2.classes;
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
        public const string CHEMIN_FICHIER_COUREURS = @"C:\data\420-14B-FX\TP1\coureurs.csv";

        /// <summary>
        /// Le chemin d'accès pour accèder au fichier des courses.
        /// </summary>
        public const string CHEMIN_FICHIER_COURSES = @"C:\data\420-14B-FX\TP1\courses.csv";

        #endregion

        #region ATTRIBUTS

        private GestionCourse _gestionCourse;


        #endregion

        #region CONSTRUCTEUR
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region WINDOW_LOADED
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //FormCoureur formCoureur = new FormCoureur(enums.EtatFormulaire.Ajouter);
            //formCoureur.ShowDialog()
            //AfficherListeCourses();
        }

        #endregion

        #region MÉTHODES

        //private void AfficherListeCourses()
        //{
        //    lstCourses.Items.Clear();

        //    lstCourses.Items.Add(Courses.Items[0]);
        //}

        #endregion

        #region ACTIONS-FORMULAIRE
        private void btnNouveau_Click(object sender, RoutedEventArgs e)
        {
            FormCourse formCourseWindow = new FormCourse();
            formCourseWindow.Show();
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (lstCourses.SelectedItem != null)
            {
                Course course = (Course)lstCourses.SelectedItem;
                FormCourse formCourseWindow = new FormCourse(course);
                formCourseWindow.Show();
            }
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            
        }

        #endregion
    }
}