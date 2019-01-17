using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCommercial.Models.Metiers
{
    public class Clientel
    {
        //Definition des properties
        #region Properties
        public string Societe { get; set; }
        public string NomCl { get; set; }
        public string NoClient { get; set; }
        public string PrenomCl { get; set; }
        public string AdresseCl { get; set; }
        public string VilleCl { get; set; }
        public string CodePostCl { get; set; }
        #endregion

        //Définition des constructeurs
        #region Constructors
        /// <summary>
        /// Initialisation avec les paramètres
        /// </summary>
        public Clientel(string no, string soc, string nom, string prenom, string adresse, string
       ville, string codePostal)
        {
            NoClient = no;
            Societe = soc;
            NomCl = nom;
            PrenomCl = prenom;
            AdresseCl = adresse;
            VilleCl = ville;
            CodePostCl = codePostal;
        }

        /// <summary>
        /// Initialisation
        /// </summary>
        public Clientel()
        { }
        #endregion

        public override string ToString()
        {
            return string.Format("noCl: {0}, : nomCl{1}, prenomCl: {2}, socite: {3}, adresseCl: {4}, villeCl: {5}, codePosCl: {6}",
                NoClient, NomCl, PrenomCl, Societe, AdresseCl, VilleCl, CodePostCl);
        }


    }
}