using _420_14B_FX_A24_TP2.classes;
using System.Windows;
using System.Windows.Controls;

namespace _420_14B_FX_A24_TP2.formulaires
{
    /// <summary>
    /// Logique d'interaction pour FormCourse.xaml
    /// </summary>
    public partial class FormCourse : Window
    {
        public FormCourse(Course course = null)
        {
            InitializeComponent();

            Course selectedcourse = course;
            if (course != null)
            {
                txtNom.Text = course.Nom;
                txtVille.Text = course.Ville;
                cboProvince.Text = course.Province;
                dpDate = course.Date;


            }
        }
    }
}
