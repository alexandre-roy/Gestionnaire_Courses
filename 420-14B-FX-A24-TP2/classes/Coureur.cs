using System.CodeDom;
using _420_14B_FX_A24_TP2.enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _420_14B_FX_A24_TP2.classes
{
    /// <summary>
    /// Classe représentant un coureur.
    /// </summary>
    public class Coureur : IComparable<Coureur>
    {
        #region CONSTANTES

        /// <summary>
        /// Constante qui représente le nombre minimal sur un dossard.
        /// </summary>
        public const int DOSSARD_VAL_MIN = 1;

        /// <summary>
        /// Constante qui représente le nombre de caractères minimal dans un nom.
        /// </summary>
        public const int NOM_NB_CARC_MIN = 3;

        /// <summary>
        /// Constante qui représente le nombre de caractères minimal dans un prénom.
        /// </summary>
        public const int PRENOM_NB_CARC_MIN = 3;

        /// <summary>
        /// Constante qui représente le nombre de caractères minimal dans une ville.
        /// </summary>
        public const int VILLE_NB_CARC_MIN =  4;

        #endregion

        #region ATTRIBUTS

        /// <summary>
        /// Numéro du dossard
        /// </summary>
        private ushort _dossard;

        /// <summary>
        /// Nom du coureur
        /// </summary>
        private string _nom;

        /// <summary>
        /// Prénom du coureur
        /// </summary>
        private string _prenom;

     
        /// <summary>
        /// Catégorie d'âge du coureur
        /// </summary>
        private Categorie _categorie;

        /// <summary>
        /// Ville d'origine du courreur
        /// </summary>
        private string _ville;

        /// <summary>
        /// Province d'origine du coureur.
        /// </summary>
        private Province _province;


        /// <summary>
        /// Temps de course
        /// </summary>
        private TimeSpan _temps;

        /// <summary>
        /// Rang du coureur
        /// </summary>
        private ushort _rang;

       
        /// <summary>
        /// Indicateur d'abandon de la course
        /// </summary>
        private bool _abandon;

        #endregion

        #region PROPRIÉTÉS

        /// <summary>
        ///Obtien ou modifie le numéro du dossard.
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _dossard.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Lancée lorsque que le numéro du dossard est inférieur à 1.</exception>
        public ushort Dossard
        {
            get { return _dossard; }
            set 
            {
                if (value < DOSSARD_VAL_MIN)
                {
                    throw new ArgumentOutOfRangeException($"Le numéro du dossard ne doit pas être inférieur à {DOSSARD_VAL_MIN}.");
                }
                _dossard = value;           
            }
        }

        /// <summary>
        ///Obtien ou modifie le nom du coureur.
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _nom.</value>
        /// <exception cref="System.ArgumentNullException">Lancée lorsque que le nom est nul ou n'a aucune valeur.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Lancée lors que le nom a moins de caractères que NOM_NB_CARC_MIN .</exception>
        public string Nom
        {
            get { return _nom; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Le nom ne peut pas être nul ou n'avoir aucune valeur.");
                }
                if (value.Trim().Length < NOM_NB_CARC_MIN)
                {
                    throw new ArgumentOutOfRangeException($"Le nom doit contenir au moins {NOM_NB_CARC_MIN} caractères.");
                }
                _nom = value.Trim();          
            }
        }

        /// <summary>
        ///Obtien ou modifie le prénom du coureur.
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _prenom.</value>
        /// <exception cref="System.ArgumentNullException">Lancée lorsque que le prénom est nul ou n'a aucune valeur.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Lancée lors que le prénom a moins de caractères que PRENON_NB_CARC_MIN .</exception>

        public string Prenom
        {
            get { return _prenom; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Le prénom ne peut pas être nul ou n'avoir aucune valeur.");
                }
                if (value.Trim().Length < PRENOM_NB_CARC_MIN)
                {
                    throw new ArgumentOutOfRangeException($"Le prénom doit contenir au moins {PRENOM_NB_CARC_MIN} caractères.");
                }
                _prenom = value.Trim(); 
            }
        }


        /// <summary>
        ///Obtien ou modifie la catégorie du coureur.
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _categorie.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">Lancée lorsque la valeur de la catégorie n'existe pas dans les plages de valeurs possibles.</exception>
        public Categorie Categorie
        {
            get { return _categorie; }
            set 
            {
                if (!Enum.IsDefined(typeof(Categorie), value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "La valeur de la catégorie n'existe pas dans les plages de valeurs possibles.");
                }
                _categorie = value;
            }
        }

        /// <summary>
        ///Obtien ou modifie la ville d'origine du coureur.
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _ville.</value>
        /// <exception cref="System.ArgumentNullException">Lancée lorsque que la ville est nul ou n'a aucune valeur.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Lancée lors que la ville a moins de caractères que VILLE_NB_CARC_MIN .</exception>
        public string Ville
        {
            get { return _ville; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("La ville ne peut pas être nul ou n'avoir aucune valeur.");
                }
                if (value.Trim().Length < VILLE_NB_CARC_MIN)
                {
                    throw new ArgumentOutOfRangeException($"La ville doit contenir au moins {VILLE_NB_CARC_MIN} caractères.");
                }

                _ville = value.Trim(); 
            }
        }

        /// <summary>
        ///Obtien ou modifie la province d'origine du coureur
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
        ///Obtien ou modifie la temps de course du coureur
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _temps.</value>
        public TimeSpan Temps
        {
            get { return _temps; }
            set  { _temps = value; }
        }

        /// <summary>
        /// Obtient ou défini le rang du coureur
        /// </summary>
        public ushort Rang
        {
            get { return _rang; }
            set { _rang = value; }
        }


        /// <summary>
        ///Obtien ou modifie l'indicateur d'abandon du coureur.
        /// </summary>
        /// <value>Obtien ou modifie la valeur de l'attribut :  _abandon.</value>
        public bool Abandon
        {
            get { return _abandon; }
            set { _abandon = value; }
        }

        #endregion

        #region CONSTRUCTEUR

        /// <summary>
        /// Permet de construire un objet Coureur
        /// </summary>
        /// <param name="dossard">No. de dossard du coureur</param>
        /// <param name="nom">Nom du coureur</param>
        /// <param name="prenom">Prénom du coureur</param>
        /// <param name="categorie">Catégorie à laquelle appartient le coureur</param>
        /// <param name="ville">Ville du coureur</param>
        /// <param name="province">Province du coureur</param>
        /// <param name="temps">Temps de course du coureur</param>
        /// <param name="abandon">Indicateur d'abandon de la course. Faux par défaut</param>
        public Coureur(ushort dossard, string nom, string prenom, Categorie categorie, string ville, Province province, TimeSpan temps)
        {
            Dossard = dossard;
            Nom = nom;
            Prenom = prenom;
            Categorie = categorie;
            Ville = ville;
            Province = province;
            Temps = temps;
        }

        public Coureur()
        {

        }

        #endregion

        #region MÉTHODES

        public int CompareTo(Coureur other)
        {
            if (other == null)
            {
                return 1;
            }
            return this.Temps.CompareTo(other.Temps);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Coureur other)
            {
                return Nom == other.Nom && Prenom == other.Prenom && Ville == other.Ville && Province == other.Province;
            }
                return false;
        }

        //public static bool operator ==(Coureur coureurGauche, Coureur coureurDroit)
        //{

        //}

        //public static bool operator !=(Coureur coureurGauche, Coureur coureurDroit)
        //{

        //}

        public override string ToString()
        {
            string padRight15 = "".PadRight(15, ' ');
            string padRight30 = "".PadRight(30, ' ');
            return $"{Dossard}{padRight15}{Nom}, {Prenom}{padRight30}{Categorie}{padRight15}{Temps}{padRight15}{Rang}";
        }

        #endregion
    }
}
