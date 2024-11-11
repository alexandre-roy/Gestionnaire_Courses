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
                Course  = new Course(Guid.NewGuid(), txtNom.Text, DateOnly.FromDateTime(dpDate.SelectedDate.Value), txtVille.Text, (Province)cboProvince.SelectedItem, (TypeCourse)cboType.SelectedItem, ushort.Parse(txtDistance.Text));
                this.DialogResult = true;
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
    }
}
