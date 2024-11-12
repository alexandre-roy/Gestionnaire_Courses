using System;
using _420_14B_FX_A24_TP2.enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _420_14B_FX_A24_TP2.classes
{
    /// <summary>
    /// Classe représentant une course à pied.
    /// </summary>
    public class Course : IComparable<Course>
    {
        #region CONSTANTES

        public const int NOM_NB_CAR_MIN = 3;

        public const int VILLE_NB_CAR_MIN = 4;

        public const ushort DISTANCE_VAL_MIN = 1;

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
            set { 
                if (value == Guid.Empty)
                {
                    throw new ArgumentException("Le ID ne peut pas être nul ou n'avoir aucune valeur.");
                }
                _id = value; 
            }
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
        /// <exception cref="System.ArgumenOutOfRangetException">Lancé lors que la ville a moins de VILLE_NB_CAR_MIN caractères.</exception>
        public string Ville
        {
            get { return _ville; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("La ville ne peut pas être nul ou n'avoir aucune valeur.");
                }
                    
                if (value.Trim().Length < VILLE_NB_CAR_MIN)
                {
                    throw new ArgumentOutOfRangeException($"La ville doit contenir au moins {VILLE_NB_CAR_MIN} caractères.");
                }
                    
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
                if (!Enum.IsDefined(typeof(Province), value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "La valeur de la province n'existe pas dans les plages de valeurs possibles.");
                }
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
                if (!Enum.IsDefined(typeof(TypeCourse), value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "La valeur de la course ne correspond pas à ceux attribué aux courses.");      
                }
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
               if (value < DISTANCE_VAL_MIN)
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
            if (coureur == null)
                throw new ArgumentNullException("Le coureur ne peut pas être nul.");
            Coureur nouvcoureur = new Coureur();
            if (nouvcoureur == null)
                throw new ArgumentNullException("Le coureur ne peut pas être nul.");

            for (int i = 0; i < Coureurs.Count; i++)
            {
                if (nouvcoureur.Dossard == Coureurs[i].Dossard)
                    throw new ArgumentException("Le numéro de dossard ne peut pas être deja utilise.");
                if (nouvcoureur == Coureurs[i])
                    throw new ArgumentException("Le coureur ne peut pas être deja inscrit.");
            }
            Coureurs.Add(nouvcoureur);
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
            int comparaison = Date.CompareTo(other.Date);
            if (comparaison == 0)
            {
                return string.Compare(Nom, other.Nom);
            }
            return comparaison;
        }


        public override bool Equals(object obj)
        {
            if (obj is Course other)
            {
                return this == other;
            }
            return false;
        }

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

        public void SupprimerCoureur(Coureur coureur)
        {
            if (coureur == null)
                throw new ArgumentNullException("Le coureur ne peut pas être nul.");
            if (!Coureurs.Contains(coureur))
                throw new InvalidOperationException("Le coureur ne peut pas être inexistant.");
            Coureurs.Remove(coureur);
            TrierCoureurs();
        }

        public override string ToString()
        {
            return $"{Nom.PadRight(40, ' ')}{Ville.PadRight(25, ' ')}{Province.ToString().PadRight(25, ' ')}{Date}";
        }

        public void TrierCoureurs()
        {
            for (int i = 0; i < Coureurs.Count; i++)
            {
                for (int j = i + 1; j < Coureurs.Count; j++)
                {
                    Coureurs.Sort();
                }
            }
            for (int i = 0; i < Coureurs.Count; i++)
            {
                Coureurs[i].Rang = (ushort)(i + 1);
            }
        }
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
