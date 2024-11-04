using _420_14B_FX_A24_TP2.enums;

namespace _420_14B_FX_A24_TP2.classes
{
    /// <summary>
    /// Classe représentant une course à pied.
    /// </summary>
    public class Course
    {
        #region CONSTANTES

        public const int NOM_NB_CAR_MIN = 3;

        public const int VILLE_NB_CAR_MIN = 4;

        public const float DISTANCE_VAL_MIN = 1;

        #endregion

        #region ATTRIBUTS


        /// <summary>
        /// Identifiant unique de la course
        /// </summary>
        private Guid _id;


        /// <summary>
        /// Nom de la course
        /// </summary>
        private string _nom;

        /// <summary>
        /// Date de la course
        /// </summary>
        private DateOnly _date;

        /// <summary>
        /// Ville où a lieu la course
        /// </summary>
        private string _ville;

        /// <summary>
        /// Province où a lieu la course
        /// </summary>
        private Province _province;

        /// <summary>
        /// Type de course
        /// </summary>
        private TypeCourse _typeCourse;


        /// <summary>
        /// Distance de la course
        /// </summary>
        private ushort _distance;


        /// <summary>
        /// Liste des coureurs 
        /// </summary>
        private List<Coureur> _coureurs;

        #endregion

        #region PROPRIÉTÉS

        /// <summary>
        /// Obtient ou définit l'identifiant unique d'une course
        /// </summary>
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }


        /// <summary>
        ///Obtien ou modifie le nom de la course.
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _nom.</value>
        /// <exception cref="System.ArgumentNullException">Lancée lorsque que le nom est nul ou n'a aucune valeur.</exception>
        /// <exception cref="System.ArgumentException">Lancé lors que le nom a moins de NOM_NB_CAR_MIN caractères.</exception>

        public string Nom
        {
            get { return _nom; }

            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Le nom ne peut pas être nul ou n'avoir aucune valeur.");
                if (value.Length < NOM_NB_CAR_MIN)
                    throw new ArgumentException("Le nom doit contenir au moins 3 caractères.");
                _nom = value.Trim().ToUpper(); 
            }
        }


        /// <summary>
        ///Obtien ou modifie la date de la course
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _date.</value>
        public DateOnly Date
        {
            get { return _date; }
            set { _date = value; }
        }


        /// <summary>
        ///Obtien ou modifie la ville où a lieu la course
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _ville.</value>
        /// <exception cref="System.ArgumentNullException">Lancée lorsque que la ville est nulle ou n'a aucune valeur.</exception>
        /// <exception cref="System.ArgumentException">Lancé lors que la ville a moins de VILLE_NB_CAR_MIN caractères.</exception>
        public string Ville
        {
            get { return _ville; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("La ville ne peut pas être nul ou n'avoir aucune valeur.");
                if (value.Length < VILLE_NB_CAR_MIN)
                    throw new ArgumentException("La ville doit contenir au moins 4 caractères.");
                _ville = value.Trim(); 
            }
        }


        /// <summary>
        ///Obtien ou modifie la province où a lieu la course
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _province.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Lancée lorsque la valeur de la province n'est pas entre PROVINCE_MIN_VAL et PROVINCE_MAX_VAL.</exception>
        public Province Province
        {
            get { return _province; }
            set 
            {
                if (!Province.TryParse(value.ToString(), out _province))
                    throw new ArgumentOutOfRangeException("La valeur de la province ne correspond pas à ceux attribué aux provinces.");
                _province = value; 
            }
        }


        /// <summary>
        ///Obtien ou modifie le type de course.
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _type.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Lancée lorsque que le type de course n'est pas entre TYPE_COURSE_MIN_VAL et TYPE_COURSE_MAX_VAL.</exception>
        public TypeCourse TypeCourse
        {
            get { return _typeCourse; }
            set 
            {
                if (!TypeCourse.TryParse(value.ToString(), out _typeCourse))
                    throw new ArgumentOutOfRangeException("La valeur de la course ne correspond pas à ceux attribué aux courses.");
                _typeCourse = value; 
            }
        }

        /// <summary>
        ///Obtien ou modifie la distance de la course en km
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _distance.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Lancée lorsque que la distance est inférieure à DISTANCE_VAL_MIN.</exception>
        public ushort Distance
        {
            get { return _distance; }
            set 
            {
               if (_distance < DISTANCE_VAL_MIN)
                    throw new ArgumentOutOfRangeException("La distance ne peut pas être inférieure à la distance minimale.");
                _distance = value; 
            }
        }

        /// <summary>
        ///Obtien ou modifie la liste des coureurs
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _coureurs.</value>
        public List<Coureur> Coureurs
        {
            get { return _coureurs; }
            set { _coureurs = value; }
        }


     

        /// <summary>
        ///Obtien le nombre de coureurs participants à la course
        /// </summary>
        /// <value>Obtien la valeur de l'attribut :  _coureurs.Count.</value>
        public int NbParticipants
        {
            get {
                throw new NotImplementedException();
            }
      
        }

        /// <summary>
        ///Obtien le temps de course moyen
        /// </summary>
        /// <value>Obtien la valeur retourné par la méthode : CalculerTempsCourseMoyen() </value>
        public TimeSpan TempCourseMoyen
        {
            get { 
                throw new NotImplementedException(); 
            }
          
        }

        #endregion

        #region CONSTRUCTEUR

        /// <summary>
        /// Permet de constuire un objet de type Course
        /// </summary>
        /// <param name="nom">Nom de la course</param>
        /// <param name="date">Date à laquelle a lieu la course</param>
        /// <param name="ville">Ville où a lieu la course</param>
        /// <param name="province">Province ou a lieu la course</param>
        /// <param name="typeCourse">Type de course</param>
        /// <param name="distance">Distance de la course</param>
        /// <remarks>Initialise une liste de coureurs vide</remarks>
        public Course(Guid id, string nom, DateOnly date, string ville, Province province, TypeCourse typeCourse, ushort distance )
        {
            Id = id;
            Nom = nom;
            Date = date;
            Ville = ville;
            Province = province;
            TypeCourse = typeCourse;
            Distance = distance;
        }

        #endregion

        #region MÉTHODES

        public void AjouterCoureur(Coureur coureur)
        {
           List<Coureur> coureurs = new List<Coureur>();
           Coureur nouvcoureur = new Coureur();
           nouvcoureur = 
           if (nouvcoureur == null)
                throw new ArgumentNullException("Le coureur ne peut pas être nul.");
           for (int i = 0; i < coureurs.Count; i++)
           {
                if (nouvcoureur.Dossard == coureur.Dossard)
                    throw new ArgumentException("Le numéro de dossard ne peut pas être deja utilise.");
                if (nouvcoureur == coureur)
                    throw new ArgumentException("Le coureur ne peut pas être deja inscrit.");
           }
            coureurs.Add(nouvcoureur);
            TrierCoureurs();
        }

        private TimeSpan CalculerTempsCourseMoyen()
        {
            int index = 0;
            TimeSpan tempsTotal = TimeSpan.Zero;

            foreach (var coureur in Coureurs)
            {
                if (!coureur.Abandon)
                {
                    TimeSpan temps = coureur.Temps;
                    tempsTotal += temps;
                    index++;
                }
            }
            return tempsTotal / index;
        }   

        public int CompareTo(Course other)
        {
            if  (Nom == other.Nom && Date == other.Date && Ville == other.Ville && Province == other.Province && TypeCourse == other.TypeCourse && Distance == other.Distance)
                return 0;
            return 1;

        }


        public override bool Equals(object obj)
        {
            if (obj is Course other)
            {
                return CompareTo(other) == 0;
            }
            return false;
        }

        public Coureur ObtenirCoureurParNoDossard(ushort dossard)
        {
            List<Coureur> coureurs = new List<Coureur>();
            foreach (var coureur in coureurs)
            {
                if (coureur.Dossard == dossard)
                    return coureur;
            }
            return null;

        }

        public void SupprimerCoureur(Coureur coureur)
        {
            List<Coureur> coureurs = new List<Coureur>();
            if (coureur == null)
                throw new ArgumentNullException("Le coureur ne peut pas être nul.");
            if (!coureurs.Contains(coureur))
                throw new ArgumentException("Le coureur ne peut pas être inexistant.");
            coureurs.Remove(coureur);
            TrierCoureurs();
        }

        public override string ToString()
        {

        }

        public void TrierCoureurs()
        {
            List<Coureur> coureurs = new List<Coureur>();
            for (int i = 0; i < coureurs.Count; i++)
            {
                for (int j = i + 1; j < coureurs.Count; j++)
                {
                    if (coureurs[i].Temps > coureurs[j].Temps)
                    {
                        Coureur temp = coureurs[i];
                        coureurs[i] = coureurs[j];
                        coureurs[j] = temp;
                    }
                }
            }
            for (int i = 0; i < coureurs.Count; i++)
            {
                coureurs[i].Rang = (ushort)(i + 1);
            }
        }


        #endregion
    }
}
