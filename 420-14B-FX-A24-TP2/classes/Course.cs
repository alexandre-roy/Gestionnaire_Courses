using _420_14B_FX_A24_TP2.enums;

namespace _420_14B_FX_A24_TP2.classes
{
    /// <summary>
    /// Classe représentant une course à pied.
    /// </summary>
    public class Course : IComparable<Course>
    {
        #region CONSTANTES

        /// <summary>
        /// Constante qui représente le nombre minimal de caractères dans le nom d'une course.
        /// </summary>
        public const int NOM_NB_CAR_MIN = 3;

        /// <summary>
        /// Constante qui représente le nombre minimal de caractères dans la ville d'une course.
        /// </summary>
        public const int VILLE_NB_CAR_MIN = 4;

        /// <summary>
        /// Constante qui représente la distance minimale d'une course.
        /// </summary>
        public const ushort DISTANCE_VAL_MIN = 1;

        #endregion

        #region ATTRIBUTS

        /// <summary>
        /// Identifiant unique de la course.
        /// </summary>
        private Guid _id;

        /// <summary>
        /// Nom de la course.
        /// </summary>
        private string _nom;

        /// <summary>
        /// Date de la course.
        /// </summary>
        private DateOnly _date;

        /// <summary>
        /// Ville où a lieu la course.
        /// </summary>
        private string _ville;

        /// <summary>
        /// Province où a lieu la course.
        /// </summary>
        private Province _province;

        /// <summary>
        /// Type de course.
        /// </summary>
        private TypeCourse _typeCourse;


        /// <summary>
        /// Distance de la course.
        /// </summary>
        private ushort _distance;


        /// <summary>
        /// Liste des coureurs qui participent à la course.
        /// </summary>
        private List<Coureur> _coureurs;

        #endregion

        #region PROPRIÉTÉS

        /// <summary>
        /// Obtient ou définit l'identifiant unique d'une course
        /// </summary>
        /// <value>Obtient ou modifie la valeur de l'attribut :  _guid.</value>
        /// <exception cref="System.ArgumentException">Lancée lorsque que le guid est nul ou n'a aucune valeur.</exception>
        public Guid Id
        {
            get { return _id; }
            set { 
                if (value == Guid.Empty)
                {
                    throw new ArgumentException("Le ID ne peut pas être nul ou n'avoir aucune valeur.");
                }
                _id = value; 
            }
        }

        /// <summary>
        /// Obtient ou modifie le nom de la course.
        /// </summary>
        /// <value>Obtient ou modifie la valeur de l'attribut :  _nom.</value>
        /// <exception cref="System.ArgumentNullException">Lancée lorsque que le nom est nul ou n'a aucune valeur.</exception>
        /// <exception cref="System.ArgumentException">Lancé lors que le nom a moins de NOM_NB_CAR_MIN caractères.</exception>

        public string Nom
        {
            get { return _nom; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Le nom ne peut pas être nul ou n'avoir aucune valeur.");
                }
                    
                if (value.Length < NOM_NB_CAR_MIN)
                {
                    throw new ArgumentOutOfRangeException("Le nom doit contenir au moins 3 caractères.");
                }
                    
                _nom = value.Trim().ToUpper(); 
            }
        }


        /// <summary>
        /// Obtient ou modifie la date de la course
        /// </summary>
        /// <value>Obtient ou modifie la valeur de l'attribut :  _date.</value>
        public DateOnly Date
        {
            get { return _date; }
            set { _date = value; }
        }


        /// <summary>
        /// Obtient ou modifie la ville où a lieu la course
        /// </summary>
        /// <value>Obtient ou modifie la valeur de l'attribut :  _ville.</value>
        /// <exception cref="System.ArgumentNullException">Lancée lorsque que la ville est nulle ou n'a aucune valeur.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Lancé lors que la ville a moins de VILLE_NB_CAR_MIN caractères.</exception>
        public string Ville
        {
            get { return _ville; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("La ville ne peut pas être nulle ou n'avoir aucune valeur.");
                }
                    
                if (value.Trim().Length < VILLE_NB_CAR_MIN)
                {
                    throw new ArgumentOutOfRangeException($"La ville doit contenir au moins {VILLE_NB_CAR_MIN} caractères.");
                }
                    
                _ville = value.Trim(); 
            }
        }


        /// <summary>
        /// Obtient ou modifie la province où a lieu la course
        /// </summary>
        /// <value>Obtient ou modifie la valeur de l'attribut :  _province.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Lancée lorsque la valeur de la province n'est pas entre PROVINCE_MIN_VAL et PROVINCE_MAX_VAL.</exception>
        public Province Province
        {
            get { return _province; }
            set 
            {
                if (!Enum.IsDefined(typeof(Province), value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "La valeur de la province n'existe pas dans les plages de valeurs possibles.");
                }
                _province = value; 
            }
        }


        /// <summary>
        /// Obtient ou modifie le type de course.
        /// </summary>
        /// <value>Obtient ou modifie la valeur de l'attribut :  _type.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Lancée lorsque que le type de course n'est pas entre TYPE_COURSE_MIN_VAL et TYPE_COURSE_MAX_VAL.</exception>
        public TypeCourse TypeCourse
        {
            get { return _typeCourse; }
            set 
            {
                if (!Enum.IsDefined(typeof(TypeCourse), value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "La valeur de la course ne corresponds pas à ceux attribué aux courses.");      
                }
                _typeCourse = value;
            }
        }

        /// <summary>
        /// Obtient ou modifie la distance de la course en km
        /// </summary>
        /// <value>Obtient ou modifie la valeur de l'attribut :  _distance.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Lancée lorsque que la distance est inférieure à DISTANCE_VAL_MIN.</exception>
        public ushort Distance
        {
            get { return _distance; }
            set 
            {
               if (value < DISTANCE_VAL_MIN)
                    throw new ArgumentOutOfRangeException("La distance ne peut pas être inférieure à la distance minimale.");
                _distance = value; 
            }
        }

        /// <summary>
        /// Obtient ou modifie la liste des coureurs
        /// </summary>
        /// <value>Obtient ou modifie la valeur de l'attribut :  _coureurs.</value>
        public List<Coureur> Coureurs
        {
            get { return _coureurs; }
            set { _coureurs = value; }
        }
     
        /// <summary>
        /// Obtient le nombre de coureurs participants à la course
        /// </summary>
        /// <value>Obtient la valeur de l'attribut :  _coureurs.Count.</value>
        public int NbParticipants
        {
            get {
                return _coureurs.Count;
                    
                throw new NotImplementedException();
            }    
        }

        /// <summary>
        /// Obtient le temps de course moyen
        /// </summary>
        /// <value>Obtient la valeur retourné par la méthode : CalculerTempsCourseMoyen() </value>
        public TimeSpan TempCourseMoyen
        {
            get {

                return CalculerTempsCourseMoyen();

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
        public Course(Guid id, string nom, DateOnly date, string ville, Province province, TypeCourse typeCourse, ushort distance)
        {
            Id = id;
            Nom = nom;
            Date = date;
            Ville = ville;
            Province = province;
            TypeCourse = typeCourse;
            Distance = distance;
            Coureurs = new List<Coureur>();
        }

        #endregion

        #region MÉTHODES

        /// <summary>
        /// Permet l'ajout d'un coureur à la liste des coureurs.
        /// </summary>
        /// <param name="coureur"></param>
        /// <exception cref="ArgumentNullException">Le coureur ne peut pas être nul.</exception>
        /// <exception cref="InvalidOperationException">Le numéro de dossard du coureur ne doit pas être utilisé par un autre coureur.</exception>
        /// <exception cref="ArgumentException">Un coureur avec les mêmes informations (sans le numéro de dossard) existe déjà.</exception>
        public void AjouterCoureur(Coureur coureur)
        {
            if (coureur == null)
                throw new ArgumentNullException("Le coureur ne peut pas être nul.");
            for (int i = 0; i < Coureurs.Count; i++)
            {
                if (coureur == Coureurs[i])
                    throw new InvalidOperationException("Le coureur ne peut pas être déjà inscrit.");
                if (coureur.Dossard == Coureurs[i].Dossard)
                    throw new ArgumentException("Le numéro de dossard ne peut pas être déjà utilisé.");  
            }
            Coureurs.Add(coureur);
            TrierCoureurs();
        }

        /// <summary>
        /// Permet d'obtenir un coureur à partir de son numéro de dossard.
        /// </summary>
        /// <param name="dossard">Le dossard du coureur</param>
        /// <returns>Si aucun coureur ne porte le numéro de dossard  recherché, alors la valeur nulle est retournée sinon le coureur trouvé est retourné.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Cette méthode doit lancer une exception si le numéro du dossard est plus petit que 1.</exception>
        public Coureur ObtenirCoureurParNoDossard(ushort dossard)
        {
            if (dossard < Coureur.DOSSARD_VAL_MIN)
            {
                throw new ArgumentOutOfRangeException($"Le numéro du dossard ne doit pas être inférieur à {Coureur.DOSSARD_VAL_MIN}.");
            }
            foreach (Coureur coureur in Coureurs)
            {
                if (coureur.Dossard == dossard)
                    return coureur;
            }
            return null;
        }

        /// <summary>
        /// Permet de retirer un coureur de la liste de coureurs.
        /// </summary>
        /// <param name="coureur">Un coureur</param>
        /// <exception cref="ArgumentNullException">Le coureur ne doit pas être nul.</exception>
        /// <exception cref="InvalidOperationException">Le coureur doit exister dans la liste.</exception>
        public void SupprimerCoureur(Coureur coureur)
        {
            if (coureur == null)
                throw new ArgumentNullException("Le coureur ne peut pas être nul.");
            if (!Coureurs.Contains(coureur))
                throw new InvalidOperationException("Le coureur ne peut pas être inexistant.");
            Coureurs.Remove(coureur);
            TrierCoureurs();
        }

        /// <summary>
        /// Permet de calculer le temps moyen de la course. Les coureurs ayant abandonné la course sont exclus du calcul.
        /// </summary>
        /// <returns>Retourne le temps moyen de la course.</returns>
        private TimeSpan CalculerTempsCourseMoyen()
        {
            if (Coureurs.Count > 1)
            {
                int index = 0;
                double tempsTotal = 0;

                foreach (Coureur coureur in Coureurs)
                {
                    if (!coureur.Abandon && coureur.Temps != TimeSpan.Zero)
                    {
                        tempsTotal += coureur.Temps.TotalMilliseconds;
                        index++;
                    }
                }

                return TimeSpan.FromMilliseconds(tempsTotal / index);
            }
            else 
            { 
                return TimeSpan.Zero;
            }
        }

        /// <summary>
        /// Permet de trier la liste des coureurs selon le temps de course en ajustant le rang des coureurs.
        /// </summary>
        public void TrierCoureurs()
        {
            Coureurs.Sort();
            for (int i = 0; i < Coureurs.Count; i++)
            {
                if (Coureurs[i].Temps == TimeSpan.Zero)
                {
                    Coureurs[i].Abandon = true;
                }
                else
                {
                    Coureurs[i].Abandon = false;
                }
                if (Coureurs[i].Abandon != true)
                {
                    Coureurs[i].Rang = (ushort)(i + 1);
                }
                else
                {
                    Coureurs[i].Rang = 0;
                }
            }
        }

        /// <summary>
        /// Retourne la représentation d'une course sous forme de chaîne de caractère de la manière.
        /// </summary>
        /// <returns>la représentation d'une course sous forme de chaîne de caractère de la manière</returns>
        public override string ToString()
        {
            return $"{Nom.PadRight(40)}{Ville.PadRight(25)}{Province.GetDescription().PadRight(25)}{Date}";
        }

        /// <summary>
        /// Compare deux courses.
        /// </summary>
        /// <param name="other">Une course</param>
        /// <returns>Un int qui représente sa place comparé a l'autre</returns>
        public int CompareTo(Course other)
        {
            int comparaison = other.Date.CompareTo(Date);
            if (comparaison == 0)
            {
                return string.Compare(Nom, other.Nom);
            }
            return comparaison;
        }

        /// <summary>
        /// Permet de comparer deux courses. Deux courses sont identiques s’ils ont le même nom, date, ville, province, type et distance.
        /// </summary>
        /// <param name="obj">Une autre course</param>
        /// <returns>Un bool qui indique si les courses sont identiques</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Course other)
            {
                return this.Nom == other.Nom && this.Date == other.Date && this.Ville == other.Ville && this.Province == other.Province && this.TypeCourse == other.TypeCourse && this.Distance == other.Distance;
              
            }
            return false;
        }

        /// <summary>
        /// Permet de comparer deux courses.
        /// </summary>
        /// <param name="courseGauche">Une course</param>
        /// <param name="courseDroit">Une autre course</param>
        /// <returns>Un bool qui indique si les courses sont identiques</returns>
        public static bool operator ==(Course courseGauche, Course courseDroit)
        {
            if (ReferenceEquals(courseGauche, courseDroit))
            {
                return true;
            }
            if (ReferenceEquals(courseGauche, null) || ReferenceEquals(courseDroit, null))
            {
                return false;
            }
            return courseGauche.Id == courseDroit.Id && courseGauche.Nom == courseDroit.Nom && courseGauche.Ville == courseDroit.Ville && courseGauche.Province == courseDroit.Province && courseGauche.Date == courseDroit.Date && courseGauche.TypeCourse == courseDroit.TypeCourse && courseGauche.Distance == courseDroit.Distance;
        }

        /// <summary>
        /// Permet de comparer deux courses.
        /// </summary>
        /// <param name="courseGauche">Une course</param>
        /// <param name="courseDroit">Une autre course</param>
        /// <returns>Un bool qui indique si les courses sont identiques</returns>
        public static bool operator !=(Course courseGauche, Course courseDroit)
        {
            if (ReferenceEquals(courseGauche, courseDroit))
            {
                return false;
            }
            if (ReferenceEquals(courseGauche, null) || ReferenceEquals(courseDroit, null))
            {
                return true;
            }
            return !(courseGauche == courseDroit);
        }

        #endregion
    }
}
