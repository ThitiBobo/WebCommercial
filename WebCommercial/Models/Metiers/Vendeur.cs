using System;

namespace WebCommercial.Models.Metiers
{
    /// <summary>
    /// Class représentant les enregistrements de la table VENDEUR
    /// </summary>
    public class Vendeur
    {
        //Définition des properties
        #region Properties
        public string NoVendeur { get; set; }
        public Vendeur VendeurChefEq { get; set; }
        public string NomVend { get; set; }
        public string PrenomVend { get; set; }
        public DateTime DateEmbau { get; set; }
        public string VilleVend { get; set; }
        public float SalaireVend { get; set; }
        public float Commission { get; set; }
        #endregion

        //Définitions des constructeurs
        #region Constructors
        public Vendeur(string noVendeur, Vendeur vendeurChefEq, string nomVend,
            string prenomVend, DateTime dateEmbau, string villeVend,
            float salaireVend, float commission)
        {
            NoVendeur = noVendeur;
            VendeurChefEq = vendeurChefEq;
            NomVend = nomVend;
            PrenomVend = prenomVend;
            DateEmbau = dateEmbau;
            VilleVend = villeVend;
            SalaireVend = salaireVend;
            Commission = commission;
        }

        public Vendeur()
        { }
        #endregion


    }
}