using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
namespace WebCommercial.Models.Metiers
{
    /// <summary>
    /// Class représentant les enregistrements de la table Utilisateur
    /// </summary>
    public class Utilisateur
    {
        //Définition des properties
        #region Properties
        public int NumUtil { get; set; }
        public string NomUtil { get; set; }
        public string PrenomUtil { get; set; }
        public string MotPasse { get; set; }
        public string Role { get; set; }
        #endregion

        //Définition des constructeurs
        #region Constructors
        public Utilisateur(int num, String nom, String prenom, String MP, String role)
        {
            NumUtil = num;
            NomUtil = nom;
            PrenomUtil = prenom;
            MotPasse = MP;
            Role = role;
        }

        public Utilisateur()
        { }
        #endregion

    }
}