using _420_14B_FX_A24_TP2.enums;

namespace _420_14B_FX_A24_TP2.classes
{
    /// <summary>
    /// Représente le système de gestion d'une course.
    /// </summary>
    public class GestionCourse
    {
        #region ATTRIBUTS

        private List<Course> _courses;

        #endregion

        #region PROPRIÉTÉS

        public List<Course> Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }

        #endregion

        #region CONSTRUCTEUR
            
        public GestionCourse()
        {
            //ChargerCourses()
        }
        #endregion

        #region MÉTHODES

        private void ChargerCourses(string cheminFichierCourses, string cheminFichierCoureurs)
        {
            string[] vectLignes = Utilitaire.ChargerDonnees(cheminFichierCourses);

            Courses = new List<Course>();

            for (int i = 1; i < vectLignes.Length; i++)
            {
                string[] detailsCourse = vectLignes[i].Split(';');

                Guid id = Guid.Parse(detailsCourse[0]);
                string nom = detailsCourse[1];
                DateOnly date = DateOnly.Parse(detailsCourse[2]);
                string ville = detailsCourse[3];
                Province province = (Province)Enum.Parse(typeof(Province), detailsCourse[4]);
                TypeCourse typeCourse = (TypeCourse)Enum.Parse(typeof(TypeCourse), detailsCourse[5]);
                ushort distance = ushort.Parse(detailsCourse[6]);

                Course course = new Course(id, nom, date, ville, province, typeCourse, distance);

                Courses.Add(course);
            }
        }

        private void ChargerCoureurs(Course course, string cheminFichierCoureurs)
        {
            string[] vectLignes = Utilitaire.ChargerDonnees(cheminFichierCoureurs);

            //Courses = new List<Coureur>();

            for (int i = 1; i < vectLignes.Length; i++)
            {
                if (course.Coureurs[i].Nom != null)
                {
                }
            }

            #endregion
        }
    }
}
