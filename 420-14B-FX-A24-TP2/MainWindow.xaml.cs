﻿using System.Windows;

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


        #endregion

        #region CONSTRUCTEUR
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region MÉTHODES
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void AfficherListeCourses()
        {
           
        }

        #endregion

        #region ACTIONS-FORMULAIRE
        private void btnNouveau_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            
        }

        #endregion
    }
}