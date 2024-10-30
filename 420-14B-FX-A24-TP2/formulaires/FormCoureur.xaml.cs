using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
            etat = Etat;

            InitializeComponent();

            switch (etat)
            {
                case EtatFormulaire.Ajouter:
                    tbTitre.Text = "Ajouter un coureur";
                    break;

                case EtatFormulaire.Modifier:
                    tbTitre.Text = "Modification d'un coureur";
                    break;

                case EtatFormulaire.Supprimer:
                    tbTitre.Text = "Suppression d'un coureur";
                    break;
            }
        }

        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
        }

    }
}
