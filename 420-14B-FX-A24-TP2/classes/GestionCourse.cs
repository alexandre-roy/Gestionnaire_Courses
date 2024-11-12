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
            
        public GestionCourse(string cheminFichierCourses, string cheminFichierCoureurs)
        {
            ChargerCourses(cheminFichierCourses, cheminFichierCoureurs);
        }
        #endregion

        #region MÉTHODES

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
                        MessageBox.Show($"Erreur de format lors du chargement de la course a la ligne {i}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show($"Erreur lors du chargement de la course a la ligne {i}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Le fichier de courses n'a pas ete trouve", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Une erreur est survenue lors du chargement des courses", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
           
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
                        MessageBox.Show($"Erreur de format lors du chargement du coureur a la ligne {i}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show($"Erreur d'argument lors du chargement du coureur a la ligne {i}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Le fichier des coureurs n'a pas ete trouve", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Une erreur est survenue lors du chargement des coureurs", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AjouterCourse(Course course)
        {
            Courses.Add(course);
        }

        public void SupprimerCourse(Course course)
        {
            Courses.Remove(course);
        }

        public void EnregistrerCourses(string cheminFichierCourses, string cheminFicherCoureurs)
        {
            try
            {
                string donneesSerialises = "Id;nom;ville;province;date;type;distance\r\n";
                foreach (var course in Courses)
                {
                    donneesSerialises += $"{course.Id};{course.Nom};{course.Ville};{course.Province};{course.Date};{course.TypeCourse};{course.Distance};\n";
                }
                Utilitaire.EnregistrerDonnees(cheminFichierCourses, donneesSerialises);
            }
            catch (Exception)
            {
                MessageBox.Show("Une erreur est survenue lors de l'enregistrement des courses", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        #endregion
    }
}
