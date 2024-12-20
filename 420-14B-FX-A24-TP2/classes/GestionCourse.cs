﻿using _420_14B_FX_A24_TP2.enums;
using System.IO;
using System.Windows;

namespace _420_14B_FX_A24_TP2.classes
{
    /// <summary>
    /// Représente le système de gestion d'une course.
    /// </summary>
    public class GestionCourse
    {
        #region ATTRIBUTS

        /// <summary>
        /// Les courses.
        /// </summary>
        private List<Course> _courses;

        #endregion

        #region PROPRIÉTÉS

        /// <summary>
        /// Obtient ou définit la course.
        /// </summary>
        public List<Course> Courses
        {
            get { return _courses; }
            set { _courses = value; }
        }

        #endregion

        #region CONSTRUCTEUR

        /// <summary>
        /// Un seul constructeur ayant comme paramètre le chemin d’accès au fichier de courses et celui des coureurs et qui charge les courses.
        /// </summary>
        /// <param name="cheminFichierCourses"></param>
        /// <param name="cheminFichierCoureurs"></param>
        public GestionCourse(string cheminFichierCourses, string cheminFichierCoureurs)
        {
            ChargerCourses(cheminFichierCourses, cheminFichierCoureurs);
        }

        #endregion

        #region MÉTHODES

        /// <summary>
        /// Permet de charger les données de la course et ses coureurs.
        /// </summary>
        /// <param name="cheminFichierCourses"></param>
        /// <param name="cheminFichierCoureurs"></param>
        public void ChargerCourses(string cheminFichierCourses, string cheminFichierCoureurs)
        {
            try
            {
                string[] vectLignes = Utilitaire.ChargerDonnees(cheminFichierCourses);
                Courses = new List<Course>();

                for (int i = 1; i < vectLignes.Length; i++)
                {
                    try
                    {
                        string[] detailsCourse = vectLignes[i].Split(';');
                        Guid id = Guid.Parse(detailsCourse[0]);
                        string nom = detailsCourse[1];
                        string ville = detailsCourse[2];
                        Province province = (Province)Enum.Parse(typeof(Province), detailsCourse[3]);
                        DateOnly date = DateOnly.Parse(detailsCourse[4]);
                        TypeCourse typeCourse = (TypeCourse)Enum.Parse(typeof(TypeCourse), detailsCourse[5]);
                        ushort distance = ushort.Parse(detailsCourse[6]);
                        Course course = new Course(id, nom, date, ville, province, typeCourse, distance);
                        ChargerCoureurs(course, cheminFichierCoureurs);
                        Courses.Add(course);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show($"Erreur de format lors du chargement de la course à la ligne {i}.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show($"Erreur lors du chargement de la course à la ligne {i}.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Le fichier de courses n'a pas été trouvé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Une erreur est survenue lors du chargement des courses.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Permet de charger les coureurs dans la course.
        /// </summary>
        /// <param name="course"></param>
        /// <param name="cheminFichierCoureurs"></param>
        public void ChargerCoureurs(Course course, string cheminFichierCoureurs)
        {
            try
            {
                string[] vectLignes = Utilitaire.ChargerDonnees(cheminFichierCoureurs);

                course.Coureurs = new List<Coureur>();

                for (int i = 1; i < vectLignes.Length; i++)
                {
                    try
                    {
                        string[] detailsCoureur = vectLignes[i].Split(';');
                        Guid idCourse = Guid.Parse(detailsCoureur[0]);
                        ushort dossard = ushort.Parse(detailsCoureur[1]);
                        string nom = detailsCoureur[2];
                        string prenom = detailsCoureur[3];
                        string ville = detailsCoureur[4];
                        Province province = (Province)Enum.Parse(typeof(Province), detailsCoureur[5]);
                        Categorie categorie = (Categorie)Enum.Parse(typeof(Categorie), detailsCoureur[6]);
                        TimeSpan temps = TimeSpan.Parse(detailsCoureur[7]);
                        Coureur coureur = new Coureur(dossard, nom, prenom, categorie, ville, province, temps);
                        if (idCourse == course.Id)
                        {
                            coureur.Abandon = bool.Parse(detailsCoureur[8]);
                            course.Coureurs.Add(coureur);
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show($"Erreur de format lors du chargement du coureur à la ligne {i}.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show($"Erreur d'argument lors du chargement du coureur à la ligne {i}.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Le fichier des coureurs n'a pas été trouvé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Une erreur est survenue lors du chargement des coureurs.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        ///  Permet l’ajout de la couse à la liste des courses.
        /// </summary>
        /// <param name="course"></param>
        public void AjouterCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course), "La course ne peut pas être nulle.");
            }
            foreach (var Course in Courses)
            {
                if (course.Equals(Course))
                {
                    throw new InvalidOperationException($"Cette course existe déjà.");
                }
                if (Course.Id == course.Id)
                {
                    throw new InvalidOperationException($"Une course possède déjà cet Id.");
                }
            }
            
            if (string.IsNullOrEmpty(course.Nom) || course.Date == default)
            {
                throw new ArgumentException("La course n'a pas des propriétées valides.");
            }
            Courses.Add(course);
            Courses.Sort();
        }

        /// <summary>
        /// Permet de retirer une course de la liste des courses.
        /// </summary>
        /// <param name="course"></param>
        public void SupprimerCourse(Course course)
        {
            if (course == null)
                throw new ArgumentNullException("La course à supprimer ne peut pas être nulle.");
            if (!Courses.Contains(course))
                throw new InvalidOperationException("La course à supprimer n'existe pas dans la liste des courses");
            Courses.Remove(course);
        }

        /// <summary>
        /// Permet l'enregistrement des données de la course et les données des coureurs dans les fichiers correspondants.
        /// </summary>
        /// <param name="cheminFichierCourses"></param>
        /// <param name="cheminFicherCoureurs"></param>
        public void EnregistrerCourses(string cheminFichierCourses, string cheminFicherCoureurs)
        {
            if (string.IsNullOrWhiteSpace(cheminFicherCoureurs))
                throw new ArgumentNullException("cheminFichierCoureurs ne peut pas être nul.");
            if (string.IsNullOrWhiteSpace(cheminFichierCourses))
                throw new ArgumentNullException("cheminFichierCourses ne peut pas être nul.");
            try
            {
                string donneesSerialises = "Id;nom;ville;province;date;type;distance\r\n";
                string donneesSerialisesD = "IdCourse;dossard;nom;prenom;ville;province;categorie;temps;abandon\r\n";
                foreach (var course in Courses)
                {
                    donneesSerialises += $"{course.Id};{course.Nom};{course.Ville};{(int)course.Province};{course.Date};{(int)course.TypeCourse};{course.Distance};\n";
                    foreach (var coureur in course.Coureurs)
                    {
                        donneesSerialisesD += $"{course.Id};{coureur.Dossard};{coureur.Nom};{coureur.Prenom};{coureur.Ville};{(int)coureur.Province};{(int)coureur.Categorie};{coureur.Temps};{coureur.Abandon};\n";
                    }
                }
                Utilitaire.EnregistrerDonnees(cheminFichierCourses, donneesSerialises);
                Utilitaire.EnregistrerDonnees(cheminFicherCoureurs, donneesSerialisesD);
            }
            catch (Exception)
            {
                MessageBox.Show("Une erreur est survenue lors de l'enregistrement des courses et des coureurs.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        #endregion
    }
}
